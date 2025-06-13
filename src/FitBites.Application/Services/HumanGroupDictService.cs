using FitBites.Application.DTOs;
using FitBites.Application.Services.Interfaces;
using FitBites.Domain.Entities;
using FitBites.Domain.IRepositories;
using FitBites.Core.Interfaces;
using FitBites.Core.Constants;
using Microsoft.Extensions.Logging;
using System;

namespace FitBites.Application.Services
{
    /// <summary>
    /// 人群标签字典应用服务实现
    /// </summary>
    public class HumanGroupDictService : IHumanGroupDictService
    {
        private readonly IHumanGroupDictRepository _humanGroupDictRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICacheService _cacheService;
        private readonly ILogger<HumanGroupDictService> _logger;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="humanGroupDictRepository">人群标签仓储</param>
        /// <param name="unitOfWork">工作单元</param>
        /// <param name="cacheService">缓存服务</param>
        /// <param name="logger">日志服务</param>
        public HumanGroupDictService(
            IHumanGroupDictRepository humanGroupDictRepository,
            IUnitOfWork unitOfWork,
            ICacheService cacheService,
            ILogger<HumanGroupDictService> logger)
        {
            _humanGroupDictRepository = humanGroupDictRepository;
            _unitOfWork = unitOfWork;
            _cacheService = cacheService;
            _logger = logger;
        }

        /// <summary>
        /// 获取所有人群标签
        /// </summary>
        /// <returns>人群标签列表</returns>
        public async Task<List<HumanGroupDictDto>> GetAllAsync()
        {
            var cacheKey = CacheConstants.GetHumanGroupDictCacheKey();
            
            try
            {
                // 尝试从缓存获取所有数据
                var cachedItems = await _cacheService.GetAsync<List<HumanGroupDictDto>>(cacheKey);
                
                if (cachedItems == null)
                {
                    // 缓存未命中，从数据库加载
                    _logger.LogInformation("Redis缓存未命中，从数据库加载人群标签数据");
                    var entities = await _humanGroupDictRepository.GetAllAsync();
                    cachedItems = entities.Select(ToDto).ToList();
                    
                    // 将数据写入缓存
                    await _cacheService.SetAsync(cacheKey, cachedItems, CacheConstants.HUMAN_GROUP_DICT_CACHE_EXPIRY);
                    _logger.LogInformation("已将人群标签数据写入Redis缓存，共{Count}条", cachedItems.Count);
                }
                else
                {
                    _logger.LogInformation("从Redis缓存获取人群标签数据成功，共{Count}条", cachedItems.Count);
                }
                
                return cachedItems;
            }
            catch (Exception ex)
            {
                // 缓存异常时，回退到数据库查询
                _logger.LogError(ex, "从Redis获取人群标签数据失败，回退到数据库查询");
                var entities = await _humanGroupDictRepository.GetAllAsync();
                return entities.Select(ToDto).ToList();
            }
        }

        /// <summary>
        /// 根据ID获取人群标签
        /// </summary>
        /// <param name="id">标签ID</param>
        /// <returns>人群标签</returns>
        public async Task<HumanGroupDictDto> GetByIdAsync(Guid id)
        {
            // 尝试从缓存获取所有数据，然后在内存中过滤
            var allItems = await GetAllAsync();
            return allItems.FirstOrDefault(x => x.Id == id);
        }

        /// <summary>
        /// 创建人群标签
        /// </summary>
        /// <param name="dto">创建人群标签DTO</param>
        /// <returns>创建后的人群标签</returns>
        public async Task<HumanGroupDictDto> CreateAsync(CreateHumanGroupDictDto dto)
        {
            // 检查名称是否已存在
            if (await _humanGroupDictRepository.ExistsByNameAsync(dto.Name))
            {
                throw new ApplicationException($"人群标签名称 '{dto.Name}' 已存在");
            }

            // 使用实体的Create方法创建实体，体现充血模型
            var entity = HumanGroupDict.Create(dto.Name, dto.Description);

            await _humanGroupDictRepository.AddAsync(entity);
            await _unitOfWork.SaveChangesAsync();

            // 刷新缓存
            await RefreshCacheAsync();

            return ToDto(entity);
        }

        /// <summary>
        /// 更新人群标签
        /// </summary>
        /// <param name="id">标签ID</param>
        /// <param name="dto">更新人群标签DTO</param>
        /// <returns>更新后的人群标签</returns>
        public async Task<HumanGroupDictDto> UpdateAsync(Guid id, UpdateHumanGroupDictDto dto)
        {
            var entity = await _humanGroupDictRepository.GetByIdAsync(id);
            if (entity == null)
            {
                throw new ApplicationException($"ID为 '{id}' 的人群标签不存在");
            }

            // 检查名称是否已存在
            if (await _humanGroupDictRepository.ExistsByNameAsync(dto.Name, id))
            {
                throw new ApplicationException($"人群标签名称 '{dto.Name}' 已存在");
            }

            // 使用实体的Update方法更新，体现充血模型
            entity.Update(dto.Name, dto.Description);

            await _humanGroupDictRepository.UpdateAsync(entity);
            await _unitOfWork.SaveChangesAsync();

            // 刷新缓存
            await RefreshCacheAsync();

            return ToDto(entity);
        }

        /// <summary>
        /// 删除人群标签
        /// </summary>
        /// <param name="id">标签ID</param>
        /// <returns>任务</returns>
        public async Task DeleteAsync(Guid id)
        {
            var entity = await _humanGroupDictRepository.GetByIdAsync(id);
            if (entity == null)
            {
                throw new ApplicationException($"ID为 '{id}' 的人群标签不存在");
            }

            // 检查该标签是否被引用
            if (entity.UserHumanGroups.Any() || entity.IngredientHumanGroups.Any())
            {
                throw new ApplicationException("该人群标签已被引用，无法删除");
            }

            await _humanGroupDictRepository.DeleteAsync(id);
            await _unitOfWork.SaveChangesAsync();

            // 刷新缓存
            await RefreshCacheAsync();
        }

        /// <summary>
        /// 刷新人群标签缓存
        /// </summary>
        public async Task RefreshCacheAsync()
        {
            try
            {
                _logger.LogInformation("开始刷新人群标签缓存");
                
                var entities = await _humanGroupDictRepository.GetAllAsync();
                var items = entities.Select(ToDto).ToList();
                
                var cacheKey = CacheConstants.GetHumanGroupDictCacheKey();
                await _cacheService.SetAsync(cacheKey, items, CacheConstants.HUMAN_GROUP_DICT_CACHE_EXPIRY);
                
                _logger.LogInformation("人群标签缓存刷新完成，共{Count}条", items.Count);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "刷新人群标签缓存失败");
                throw;
            }
        }

        /// <summary>
        /// 将实体转换为DTO
        /// </summary>
        /// <param name="entity">实体</param>
        /// <returns>DTO</returns>
        private static HumanGroupDictDto ToDto(HumanGroupDict entity)
        {
            return new HumanGroupDictDto
            {
                Id = entity.Id,
                Name = entity.Name,
                Description = entity.Description,
                CreatedAt = entity.CreatedAt,
                UpdatedAt = entity.UpdatedAt
            };
        }
    }
} 