using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FitBites.Core.Enums;
using FitBites.Domain.Entities;

namespace FitBites.Domain.Services
{
    /// <summary>
    /// 菜式领域服务接口
    /// </summary>
    public interface IRecipeDomainService
    {
        /// <summary>
        /// 创建菜式
        /// </summary>
        Task<Recipe> CreateRecipeAsync(
            string recipeName, 
            string description, 
            Guid? cuisineId,
            Guid? cookingMethodId, 
            Guid? tasteId, 
            DifficultyLevel difficultyLevel,
            RecipeSource source,
            Guid? sourceId);
            
        /// <summary>
        /// 更新菜式基本信息
        /// </summary>
        Task<Recipe> UpdateRecipeBasicInfoAsync(
            Recipe recipe,
            string recipeName,
            string description,
            Guid? cuisineId,
            Guid? cookingMethodId,
            Guid? tasteId,
            DifficultyLevel difficultyLevel);
            
        /// <summary>
        /// 设置菜式图片
        /// </summary>
        Task<Recipe> SetRecipeImageAsync(Recipe recipe, string imageUrl);
        
        /// <summary>
        /// 设置菜式时间信息
        /// </summary>
        Task<Recipe> SetRecipeTimeInfoAsync(Recipe recipe, int? prepTime, int? cookTime, int? servings);
        
        /// <summary>
        /// 添加菜式食材
        /// </summary>
        Task<Recipe> AddRecipeIngredientAsync(
            Recipe recipe, 
            Guid ingredientId, 
            decimal amount, 
            string unit, 
            int order = 0, 
            string remark = null);
        
        /// <summary>
        /// 添加菜式烹饪步骤
        /// </summary>
        Task<Recipe> AddRecipeCookingStepAsync(
            Recipe recipe, 
            int stepOrder,
            string title,
            string description, 
            string imageUrl = null, 
            string tips = null);
            
        /// <summary>
        /// 批量添加菜式食材
        /// </summary>
        Task<Recipe> AddRecipeIngredientsAsync(
            Recipe recipe, 
            IEnumerable<(Guid IngredientId, decimal Amount, string Unit, int Order, string Remark)> ingredients);
            
        /// <summary>
        /// 批量添加菜式烹饪步骤
        /// </summary>
        Task<Recipe> AddRecipeCookingStepsAsync(
            Recipe recipe, 
            IEnumerable<(int StepOrder, string Title, string Description, string ImageUrl, string Tips)> cookingSteps);
            
        /// <summary>
        /// 设置菜式推荐状态
        /// </summary>
        Task<Recipe> SetRecipeRecommendationAsync(Recipe recipe, bool isRecommended);
        
        /// <summary>
        /// 启用菜式
        /// </summary>
        Task<Recipe> EnableRecipeAsync(Recipe recipe);
        
        /// <summary>
        /// 禁用菜式
        /// </summary>
        Task<Recipe> DisableRecipeAsync(Recipe recipe);
    }
} 