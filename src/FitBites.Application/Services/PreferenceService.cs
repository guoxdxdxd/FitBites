using FitBites.Application.Dtos.Preference;
using FitBites.Application.Services.Interfaces;
using FitBites.Core.Constants;
using FitBites.Core.Enums;
using FitBites.Core.Interfaces;
using FitBites.Domain.Entities;
using FitBites.Domain.Entities.Base;
using FitBites.Domain.IRepositories;
using Microsoft.Extensions.Logging;

namespace FitBites.Application.Services
{
    /// <summary>
    /// 偏好服务
    /// </summary>
    public class PreferenceService : IPreferenceService
    {
        private readonly ICuisineRepository _cuisineRepository;
        private readonly ICookingMethodRepository _cookingMethodRepository;
        private readonly ITasteRepository _tasteRepository;
        private readonly ICacheService _cacheService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<PreferenceService> _logger;

        /// <summary>
        /// 构造函数
        /// </summary>
        public PreferenceService(
            ICuisineRepository cuisineRepository,
            ICookingMethodRepository cookingMethodRepository,
            ITasteRepository tasteRepository,
            ICacheService cacheService,
            IUnitOfWork unitOfWork,
            ILogger<PreferenceService> logger)
        {
            _cuisineRepository = cuisineRepository;
            _cookingMethodRepository = cookingMethodRepository;
            _tasteRepository = tasteRepository;
            _cacheService = cacheService;
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        /// <summary>
        /// 查询偏好列表
        /// </summary>
        /// <param name="queryDto">查询参数</param>
        /// <returns>偏好项目列表</returns>
        public async Task<List<PreferenceItemDto>> GetPreferenceItemsAsync(PreferenceQueryDto queryDto)
        {
            switch (queryDto.TargetType)
            {
                case PreferenceTargetType.Cuisine:
                    return await GetPreferenceItemsAsync<CuisineDict>(
                        queryDto.Name, 
                        _cuisineRepository.QueryListAsync);
                    
                case PreferenceTargetType.CookingMethod:
                    return await GetPreferenceItemsAsync<CookingMethodDict>(
                        queryDto.Name, 
                        _cookingMethodRepository.QueryListAsync);
                    
                case PreferenceTargetType.Taste:
                    return await GetPreferenceItemsAsync<TasteDict>(
                        queryDto.Name, 
                        _tasteRepository.QueryListAsync);
                    
                default:
                    throw new ArgumentException($"不支持的偏好类型: {queryDto.TargetType}");
            }
        }
        
        /// <summary>
        /// 创建偏好项
        /// </summary>
        /// <param name="createDto">创建参数</param>
        /// <returns>创建的偏好项</returns>
        public async Task<PreferenceItemDto> CreatePreferenceAsync(PreferenceCreateDto createDto)
        {
            // 检查编码是否已存在
            var existsDto = new PreferenceQueryDto
            {
                TargetType = createDto.Type
            };
            
            var existingItems = await GetPreferenceItemsAsync(existsDto);
            if (existingItems.Any(x => x.Code.Equals(createDto.Code, StringComparison.OrdinalIgnoreCase)))
            {
                throw new ArgumentException($"编码 {createDto.Code} 已存在");
            }

            var id = createDto.Type switch {
                PreferenceTargetType.Cuisine => await CreateCuisineAsync(createDto),
                PreferenceTargetType.CookingMethod => await CreateCookingMethodAsync(createDto),
                PreferenceTargetType.Taste => await CreateTasteAsync(createDto),
                _ => throw new ArgumentException($"不支持的偏好类型: {createDto.Type}")
            };
       
            await _unitOfWork.SaveChangesAsync();
            
            return new PreferenceItemDto(id, createDto.Code, createDto.Name, createDto.Description);
        }
        
        /// <summary>
        /// 创建菜系
        /// </summary>
        private async Task<Guid> CreateCuisineAsync(PreferenceCreateDto createDto)
        {
            // 创建实体
            var cuisine = CuisineDict.Create(createDto.Code,  createDto.Name, createDto.Description ?? string.Empty, createDto.SortOrder);
            
            // 保存到数据库
            await _cuisineRepository.AddAsync(cuisine);

            return cuisine.Id;
        }
        
        /// <summary>
        /// 创建烹饪方式
        /// </summary>
        private async Task<Guid> CreateCookingMethodAsync(PreferenceCreateDto createDto)
        {
            // 创建实体
            var cookingMethod = CookingMethodDict.Create(createDto.Code, createDto.Name,
                createDto.Description ?? string.Empty, createDto.SortOrder);
            
            // 保存到数据库
            await _cookingMethodRepository.AddAsync(cookingMethod);
            
            return cookingMethod.Id;
        }
        
        /// <summary>
        /// 创建口味
        /// </summary>
        private async Task<Guid> CreateTasteAsync(PreferenceCreateDto createDto)
        {
            // 创建实体
            var taste = TasteDict.Create(createDto.Code, createDto.Name,
                createDto.Description ?? string.Empty, createDto.SortOrder);
                
            // 保存到数据库
            await _tasteRepository.AddAsync(taste);
            
            return taste.Id;
        }
        
        /// <summary>
        /// 更新偏好项
        /// </summary>
        /// <param name="id">偏好项ID</param>
        /// <param name="updateDto">更新参数</param>
        public async Task UpdatePreferenceAsync(Guid id, PreferenceUpdateDto updateDto)
        {
            switch (updateDto.Type)
            {
                case PreferenceTargetType.Cuisine:
                    var cuisineItem = await _cuisineRepository.GetByIdAsync(id);
                    await UpdateCuisineAsync(cuisineItem, updateDto);
                    break;
                case PreferenceTargetType.CookingMethod:
                    var cookingMethodItem = await _cookingMethodRepository.GetByIdAsync(id);
                    await UpdateCookingMethodAsync(cookingMethodItem, updateDto);
                    
                    break;
                case PreferenceTargetType.Taste:
                    var tasteItem = await _tasteRepository.GetByIdAsync(id);
                    await UpdateTasteAsync(tasteItem, updateDto);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
            
            await _unitOfWork.SaveChangesAsync();
        }
        
        /// <summary>
        /// 更新菜系
        /// </summary>
        private async Task UpdateCuisineAsync(CuisineDict cuisine, PreferenceUpdateDto updateDto)
        {
            // 更新实体
            cuisine.Update(updateDto.Name, updateDto.Description, updateDto.SortOrder);
        }
        
        /// <summary>
        /// 更新烹饪方式
        /// </summary>
        private async Task UpdateCookingMethodAsync(CookingMethodDict cookingMethod, PreferenceUpdateDto updateDto)
        {
            // 更新实体
            cookingMethod.Update(updateDto.Name, updateDto.Description, updateDto.SortOrder);
        }
        
        /// <summary>
        /// 更新口味
        /// </summary>
        private async Task UpdateTasteAsync(TasteDict taste, PreferenceUpdateDto updateDto)
        {
            // 更新实体
            taste.Update(updateDto.Name, updateDto.Description, updateDto.SortOrder);
        }
        
        /// <summary>
        /// 删除偏好项
        /// </summary>
        /// <param name="id">偏好项ID</param>
        /// <param name="type">偏好类型</param>
        public async Task DeletePreferenceAsync(Guid id, PreferenceTargetType type)
        {
            switch (type)
            {
                case PreferenceTargetType.Cuisine:
                    await DeleteCuisineAsync(id);
                    break;
                    
                case PreferenceTargetType.CookingMethod:
                    await DeleteCookingMethodAsync(id);
                    break;
                    
                case PreferenceTargetType.Taste:
                    await DeleteTasteAsync(id);
                    break;
                    
                default:
                    throw new ArgumentException($"不支持的偏好类型: {type}");
            }
            await _unitOfWork.SaveChangesAsync();
        }
        
        /// <summary>
        /// 删除菜系
        /// </summary>
        private async Task DeleteCuisineAsync(Guid id)
        {
            var cuisine = await _cuisineRepository.GetByIdAsync(id);
            if (cuisine == null)
            {
                throw new ArgumentException($"未找到ID为 {id} 的菜系");
            }
            
            // 软删除
            cuisine.Delete();
        }
        
        /// <summary>
        /// 删除烹饪方式
        /// </summary>
        private async Task DeleteCookingMethodAsync(Guid id)
        {
            var cookingMethod = await _cookingMethodRepository.GetByIdAsync(id);
            if (cookingMethod == null)
            {
                throw new ArgumentException($"未找到ID为 {id} 的烹饪方式");
            }
            
            // 软删除
            cookingMethod.Delete();
        }
        
        /// <summary>
        /// 删除口味
        /// </summary>
        private async Task DeleteTasteAsync(Guid id)
        {
            var taste = await _tasteRepository.GetByIdAsync(id);
            if (taste == null)
            {
                throw new ArgumentException($"未找到ID为 {id} 的口味");
            }
            
            // 软删除
            taste.Delete();
        }
        
        /// <summary>
        /// 启用偏好项
        /// </summary>
        /// <param name="id">偏好项ID</param>
        /// <param name="type">偏好类型</param>
        public async Task EnablePreferenceAsync(Guid id, PreferenceTargetType type)
        {
            switch (type)
            {
                case PreferenceTargetType.Cuisine:
                    await EnableCuisineAsync(id);
                    break;
                    
                case PreferenceTargetType.CookingMethod:
                    await EnableCookingMethodAsync(id);
                    break;
                    
                case PreferenceTargetType.Taste:
                    await EnableTasteAsync(id);
                    break;
                    
                default:
                    throw new ArgumentException($"不支持的偏好类型: {type}");
            }
            await _unitOfWork.SaveChangesAsync();
        }
        
        /// <summary>
        /// 启用菜系
        /// </summary>
        private async Task EnableCuisineAsync(Guid id)
        {
            var cuisine = await _cuisineRepository.GetByIdAsync(id);
            if (cuisine == null)
            {
                throw new ArgumentException($"未找到ID为 {id} 的菜系");
            }
            
            // 启用
            cuisine.Enable();
        }
        
        /// <summary>
        /// 启用烹饪方式
        /// </summary>
        private async Task EnableCookingMethodAsync(Guid id)
        {
            var cookingMethod = await _cookingMethodRepository.GetByIdAsync(id);
            if (cookingMethod == null)
            {
                throw new ArgumentException($"未找到ID为 {id} 的烹饪方式");
            }
            
            // 启用
            cookingMethod.Enable();
        }
        
        /// <summary>
        /// 启用口味
        /// </summary>
        private async Task EnableTasteAsync(Guid id)
        {
            var taste = await _tasteRepository.GetByIdAsync(id);
            if (taste == null)
            {
                throw new ArgumentException($"未找到ID为 {id} 的口味");
            }
            
            // 启用
            taste.Enable();
        }
        
        /// <summary>
        /// 禁用偏好项
        /// </summary>
        /// <param name="id">偏好项ID</param>
        /// <param name="type">偏好类型</param>
        public async Task DisablePreferenceAsync(Guid id, PreferenceTargetType type)
        {
            switch (type)
            {
                case PreferenceTargetType.Cuisine:
                    await DisableCuisineAsync(id);
                    break;
                    
                case PreferenceTargetType.CookingMethod:
                    await DisableCookingMethodAsync(id);
                    break;
                    
                case PreferenceTargetType.Taste:
                    await DisableTasteAsync(id);
                    break;
                    
                default:
                    throw new ArgumentException($"不支持的偏好类型: {type}");
            }
            await _unitOfWork.SaveChangesAsync();
        }
        
        /// <summary>
        /// 禁用菜系
        /// </summary>
        private async Task DisableCuisineAsync(Guid id)
        {
            var cuisine = await _cuisineRepository.GetByIdAsync(id);
            if (cuisine == null)
            {
                throw new ArgumentException($"未找到ID为 {id} 的菜系");
            }
            
            // 禁用
            cuisine.Disable();
        }
        
        /// <summary>
        /// 禁用烹饪方式
        /// </summary>
        private async Task DisableCookingMethodAsync(Guid id)
        {
            var cookingMethod = await _cookingMethodRepository.GetByIdAsync(id);
            if (cookingMethod == null)
            {
                throw new ArgumentException($"未找到ID为 {id} 的烹饪方式");
            }
            
            // 禁用
            cookingMethod.Disable();
        }
        
        /// <summary>
        /// 禁用口味
        /// </summary>
        private async Task DisableTasteAsync(Guid id)
        {
            var taste = await _tasteRepository.GetByIdAsync(id);
            if (taste == null)
            {
                throw new ArgumentException($"未找到ID为 {id} 的口味");
            }
            
            // 禁用
            taste.Disable();
        }

        /// <summary>
        /// 通用偏好项目查询方法
        /// </summary>
        /// <typeparam name="T">偏好字典实体类型</typeparam>
        /// <param name="name">名称过滤条件</param>
        /// <param name="queryFunc">数据库查询委托</param>
        /// <returns>偏好项目列表</returns>
        private async Task<List<PreferenceItemDto>> GetPreferenceItemsAsync<T>(
            string name,
            Func<string, Task<List<PreferenceDictBase>>> queryFunc) where T : PreferenceDictBase
        {
            var typeName = typeof(T).Name;
            var cacheKey = CacheConstants.GetPreferenceCacheKey(typeName);
            
            try
            {
                // 尝试从缓存获取所有数据
                var cachedItems = await _cacheService.GetAsync<List<PreferenceItemDto>>(cacheKey);
                
                if (cachedItems == null)
                {
                    // 缓存未命中，从数据库加载
                    _logger.LogInformation("Redis缓存未命中，从数据库加载{TypeName}数据", typeName);
                    var entities = await queryFunc(null);
                    cachedItems = entities.Select(o => new PreferenceItemDto(o.Id, o.Code, o.Name, o.Description)).ToList();
                    
                    // 将数据写入缓存
                    await _cacheService.SetAsync(cacheKey, cachedItems, CacheConstants.PREFERENCE_CACHE_EXPIRY);
                    _logger.LogInformation("已将{TypeName}数据写入Redis缓存，共{Count}条", typeName, cachedItems.Count);
                }
                else
                {
                    _logger.LogInformation("从Redis缓存获取{TypeName}数据成功，共{Count}条", typeName, cachedItems.Count);
                }
                
                // 在内存中过滤数据
                if (!string.IsNullOrEmpty(name))
                {
                    return cachedItems.Where(x => x.Name.Contains(name, StringComparison.OrdinalIgnoreCase)).ToList();
                }
                
                return cachedItems;
            }
            catch (Exception ex)
            {
                // 缓存异常时，回退到数据库查询
                _logger.LogError(ex, "从Redis获取{TypeName}数据失败，回退到数据库查询", typeName);
                var entities = await queryFunc(name);
                return entities.Select(o => new PreferenceItemDto(o.Id, o.Code, o.Name, o.Description)).ToList();
            }
        }

        /// <summary>
        /// 刷新所有偏好缓存
        /// 当偏好数据发生变更时调用此方法
        /// </summary>
        public async Task RefreshPreferenceCacheAsync()
        {
            try
            {
                _logger.LogInformation("开始刷新所有偏好缓存");

                // 刷新菜系缓存
                await RefreshCacheAsync<CuisineDict>( _cuisineRepository.QueryListAsync);
                
                // 刷新烹饪方式缓存
                await RefreshCacheAsync<CookingMethodDict>( _cookingMethodRepository.QueryListAsync);
                
                // 刷新口味缓存
                await RefreshCacheAsync<TasteDict>(_tasteRepository.QueryListAsync);
                
                _logger.LogInformation("所有偏好缓存刷新完成");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "刷新偏好缓存失败");
                throw;
            }
        }
        
        /// <summary>
        /// 刷新指定类型的偏好缓存
        /// </summary>
        /// <typeparam name="T">偏好字典实体类型</typeparam>
        /// <param name="queryFunc">数据库查询委托</param>
        public async Task RefreshCacheAsync<T>(
            Func<string, Task<List<PreferenceDictBase>>> queryFunc) where T : PreferenceDictBase
        {
            var typeName = typeof(T).Name;
            var cacheKey = CacheConstants.GetPreferenceCacheKey(typeName);
            
            var entities = await queryFunc(null);
            var items = entities.Select(o => new PreferenceItemDto(o.Id, o.Code, o.Name, o.Description)).ToList();
            
            await _cacheService.SetAsync(cacheKey, items, CacheConstants.PREFERENCE_CACHE_EXPIRY);
            
            _logger.LogInformation("{TypeName}缓存刷新完成，共{Count}条", typeName, items.Count);
        }
    }
} 