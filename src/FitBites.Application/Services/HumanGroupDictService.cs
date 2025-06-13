using FitBites.Application.DTOs;
using FitBites.Application.Services.Interfaces;
using FitBites.Domain.Entities;
using FitBites.Domain.IRepositories;
using FitBites.Core.Interfaces;

namespace FitBites.Application.Services
{
    /// <summary>
    /// 人群标签字典应用服务实现
    /// </summary>
    public class HumanGroupDictService : IHumanGroupDictService
    {
        private readonly IHumanGroupDictRepository _humanGroupDictRepository;
        private readonly IUnitOfWork _unitOfWork;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="humanGroupDictRepository">人群标签仓储</param>
        /// <param name="unitOfWork">工作单元</param>
        public HumanGroupDictService(
            IHumanGroupDictRepository humanGroupDictRepository,
            IUnitOfWork unitOfWork)
        {
            _humanGroupDictRepository = humanGroupDictRepository;
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// 获取所有人群标签
        /// </summary>
        /// <returns>人群标签列表</returns>
        public async Task<List<HumanGroupDictDto>> GetAllAsync()
        {
            var entities = await _humanGroupDictRepository.GetAllAsync();
            return entities.Select(ToDto).ToList();
        }

        /// <summary>
        /// 根据ID获取人群标签
        /// </summary>
        /// <param name="id">标签ID</param>
        /// <returns>人群标签</returns>
        public async Task<HumanGroupDictDto> GetByIdAsync(Guid id)
        {
            var entity = await _humanGroupDictRepository.GetByIdAsync(id);
            return entity != null ? ToDto(entity) : null;
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

            return ToDto(entity);
        }

        /// <summary>
        /// 更新人群标签
        /// </summary>
        /// <param name="dto">更新人群标签DTO</param>
        /// <returns>更新后的人群标签</returns>
        public async Task<HumanGroupDictDto> UpdateAsync(UpdateHumanGroupDictDto dto)
        {
            var entity = await _humanGroupDictRepository.GetByIdAsync(dto.Id);
            if (entity == null)
            {
                throw new ApplicationException($"ID为 '{dto.Id}' 的人群标签不存在");
            }

            // 检查名称是否已存在
            if (await _humanGroupDictRepository.ExistsByNameAsync(dto.Name, dto.Id))
            {
                throw new ApplicationException($"人群标签名称 '{dto.Name}' 已存在");
            }

            // 使用实体的Update方法更新，体现充血模型
            entity.Update(dto.Name, dto.Description);

            await _humanGroupDictRepository.UpdateAsync(entity);
            await _unitOfWork.SaveChangesAsync();

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