using FitBites.Application.DTOs;
using FitBites.Application.DTOs.Ingredient;
using FitBites.Core.Enums;
using FitBites.Core.DependencyInjection;

namespace FitBites.Application.Services.Interfaces
{
    /// <summary>
    /// 食材应用服务接口
    /// </summary>
    public interface IIngredientService : IScopedDependency
    {
        /// <summary>
        /// 获取所有食材类别
        /// </summary>
        /// <returns>食材类别列表</returns>
        Task<List<EnumValueDto>> GetIngredientCategoriesAsync();
        
        /// <summary>
        /// 分页查询食材列表
        /// </summary>
        /// <param name="queryDto">查询条件</param>
        /// <returns>分页食材列表</returns>
        Task<PaginationResponseDto<IngredientDto>> GetPagedIngredientsAsync(IngredientQueryDto queryDto);
        
        /// <summary>
        /// 获取食材列表
        /// </summary>
        /// <returns>食材列表</returns>
        Task<List<IngredientDto>> GetIngredientsAsync();
        
        /// <summary>
        /// 根据分类获取食材列表
        /// </summary>
        /// <param name="category">食材分类</param>
        /// <returns>食材列表</returns>
        Task<List<IngredientDto>> GetIngredientsByCategoryAsync(IngredientCategory category);
        
        /// <summary>
        /// 获取食材详情（包含关联数据）
        /// </summary>
        /// <param name="id">食材ID</param>
        /// <returns>食材详情</returns>
        Task<IngredientDto> GetIngredientAsync(Guid id);
        
        /// <summary>
        /// 创建食材
        /// </summary>
        /// <param name="dto">创建食材DTO</param>
        /// <returns>创建的食材</returns>
        Task<IngredientDto> CreateIngredientAsync(CreateIngredientDto dto);
        
        /// <summary>
        /// 更新食材
        /// </summary>
        /// <param name="dto">更新食材DTO</param>
        /// <returns>更新后的食材</returns>
        Task<IngredientDto> UpdateIngredientAsync(UpdateIngredientDto dto);
        
        /// <summary>
        /// 删除食材
        /// </summary>
        /// <param name="id">食材ID</param>
        /// <returns>任务</returns>
        Task DeleteIngredientAsync(Guid id);
        
        #region 营养成分相关操作
        
        /// <summary>
        /// 添加食材营养成分
        /// </summary>
        /// <param name="dto">添加营养成分DTO</param>
        /// <returns>添加的营养成分</returns>
        Task<IngredientNutritionDto> AddNutritionAsync(AddIngredientNutritionDto dto);
        
        /// <summary>
        /// 更新食材营养成分
        /// </summary>
        /// <param name="dto">更新营养成分DTO</param>
        /// <returns>更新后的营养成分</returns>
        Task<IngredientNutritionDto> UpdateNutritionAsync(UpdateIngredientNutritionDto dto);
        
        /// <summary>
        /// 删除食材营养成分
        /// </summary>
        /// <param name="nutritionId">营养成分ID</param>
        /// <returns>任务</returns>
        Task DeleteNutritionAsync(Guid nutritionId);
        
        #endregion
        
        #region 人群适宜/忌用相关操作
        
        /// <summary>
        /// 添加食材人群适宜/忌用映射
        /// </summary>
        /// <param name="dto">添加人群映射DTO</param>
        /// <returns>添加的人群映射</returns>
        Task<IngredientHumanGroupDto> AddHumanGroupAsync(AddIngredientHumanGroupDto dto);
        
        /// <summary>
        /// 更新食材人群适宜/忌用映射
        /// </summary>
        /// <param name="dto">更新人群映射DTO</param>
        /// <returns>更新后的人群映射</returns>
        Task<IngredientHumanGroupDto> UpdateHumanGroupAsync(UpdateIngredientHumanGroupDto dto);
        
        /// <summary>
        /// 删除食材人群适宜/忌用映射
        /// </summary>
        /// <param name="humanGroupId">人群映射ID</param>
        /// <returns>任务</returns>
        Task DeleteHumanGroupAsync(Guid humanGroupId);
        
        #endregion
        
        #region 预处理方法相关操作
        
        /// <summary>
        /// 添加食材预处理方法
        /// </summary>
        /// <param name="dto">添加预处理方法DTO</param>
        /// <returns>添加的预处理方法</returns>
        Task<IngredientPreprocessDto> AddPreprocessAsync(AddIngredientPreprocessDto dto);
        
        /// <summary>
        /// 更新食材预处理方法
        /// </summary>
        /// <param name="dto">更新预处理方法DTO</param>
        /// <returns>更新后的预处理方法</returns>
        Task<IngredientPreprocessDto> UpdatePreprocessAsync(UpdateIngredientPreprocessDto dto);
        
        /// <summary>
        /// 删除食材预处理方法
        /// </summary>
        /// <param name="preprocessId">预处理方法ID</param>
        /// <returns>任务</returns>
        Task DeletePreprocessAsync(Guid preprocessId);
        
        #endregion
    }
} 