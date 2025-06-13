using FitBites.Application.DTOs;
using FitBites.Application.DTOs.Recipe;
using FitBites.Core.DependencyInjection;

namespace FitBites.Application.Services.Interfaces
{
    /// <summary>
    /// 菜式应用服务接口
    /// </summary>
    public interface IRecipeApplicationService: IScopedDependency
    {
        /// <summary>
        /// 获取菜式详情
        /// </summary>
        Task<RecipeDto> GetRecipeAsync(Guid id);
        
        /// <summary>
        /// 创建菜式
        /// </summary>
        Task<RecipeDto> CreateRecipeAsync(CreateRecipeDto dto);
        
        /// <summary>
        /// 创建菜式基础信息
        /// </summary>
        Task<RecipeDto> CreateRecipeBaseInfoAsync(CreateRecipeBaseDto dto);
        
        /// <summary>
        /// 批量添加菜式食材
        /// </summary>
        Task<RecipeDto> BatchAddRecipeIngredientsAsync(Guid id, List<CreateRecipeIngredientDto> ingredients);
        
        /// <summary>
        /// 删除菜式食材
        /// </summary>
        Task<RecipeDto> RemoveRecipeIngredientAsync(Guid id, Guid ingredientId);
        
        /// <summary>
        /// 更新菜式食材
        /// </summary>
        Task<RecipeDto> UpdateRecipeIngredientAsync(Guid id, Guid ingredientId, UpdateRecipeIngredientDto dto);
        
        /// <summary>
        /// 替换所有烹饪步骤
        /// </summary>
        Task<RecipeDto> ReplaceCookingStepsAsync(Guid id, List<CreateRecipeCookingStepDto> cookingSteps);
        
        /// <summary>
        /// 更新菜式基本信息
        /// </summary>
        Task<RecipeDto> UpdateRecipeBasicInfoAsync(UpdateRecipeDto dto);
        
        /// <summary>
        /// 设置菜式图片
        /// </summary>
        Task<RecipeDto> SetRecipeImageAsync(Guid id, string imageUrl);
        
        /// <summary>
        /// 设置菜式时间信息
        /// </summary>
        Task<RecipeDto> SetRecipeTimeInfoAsync(Guid id, int? prepTime, int? cookTime, int? servings);
        
        /// <summary>
        /// 添加菜式食材
        /// </summary>
        Task<RecipeDto> AddRecipeIngredientAsync(Guid id, CreateRecipeIngredientDto dto);
        
        /// <summary>
        /// 添加菜式烹饪步骤
        /// </summary>
        Task<RecipeDto> AddRecipeCookingStepAsync(Guid id, CreateRecipeCookingStepDto dto);
        
        /// <summary>
        /// 设置菜式推荐状态
        /// </summary>
        Task<RecipeDto> SetRecipeRecommendationAsync(Guid id, bool isRecommended);
        
        /// <summary>
        /// 启用菜式
        /// </summary>
        Task<RecipeDto> EnableRecipeAsync(Guid id);
        
        /// <summary>
        /// 禁用菜式
        /// </summary>
        Task<RecipeDto> DisableRecipeAsync(Guid id);
        
        /// <summary>
        /// 获取推荐菜式列表
        /// </summary>
        Task<List<RecipeDto>> GetRecommendedRecipesAsync(int count);
        
        /// <summary>
        /// 分页获取菜式列表
        /// </summary>
        Task<PaginationResponseDto<RecipeDto>> GetRecipeListAsync(int page, int pageSize, string keyword);
    }
} 