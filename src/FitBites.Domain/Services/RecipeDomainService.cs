using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FitBites.Core.DependencyInjection;
using FitBites.Core.Enums;
using FitBites.Domain.Entities;
using FitBites.Domain.Events;
using FitBites.Domain.IRepositories;

namespace FitBites.Domain.Services
{
    /// <summary>
    /// 菜式领域服务实现
    /// </summary>
    public class RecipeDomainService : IRecipeDomainService, IScopedDependency
    {
        private readonly IRecipeRepository _recipeRepository;
        private readonly IIngredientRepository _ingredientRepository;
        
        /// <summary>
        /// 构造函数
        /// </summary>
        public RecipeDomainService(
            IRecipeRepository recipeRepository,
            IIngredientRepository ingredientRepository)
        {
            _recipeRepository = recipeRepository;
            _ingredientRepository = ingredientRepository;
        }
        
        /// <summary>
        /// 创建菜式
        /// </summary>
        public async Task<Recipe> CreateRecipeAsync(
            string recipeName, 
            string description, 
            Guid? cuisineId,
            Guid? cookingMethodId, 
            Guid? tasteId, 
            DifficultyLevel difficultyLevel,
            RecipeSource source,
            Guid? sourceId)
        {
            // 检查菜式名称是否已存在
            if (await _recipeRepository.ExistsByNameAsync(recipeName))
            {
                throw new ArgumentException($"菜式名称 '{recipeName}' 已存在");
            }
            
            // 创建菜式
            var recipe = Recipe.Create(
                recipeName,
                description,
                cuisineId,
                cookingMethodId,
                tasteId,
                difficultyLevel,
                source,
                sourceId);
            
            return recipe;
        }
        
        /// <summary>
        /// 更新菜式基本信息
        /// </summary>
        public async Task<Recipe> UpdateRecipeBasicInfoAsync(
            Recipe recipe,
            string recipeName,
            string description,
            Guid? cuisineId,
            Guid? cookingMethodId,
            Guid? tasteId,
            DifficultyLevel difficultyLevel)
        {
            if (recipe == null)
            {
                throw new ArgumentNullException(nameof(recipe));
            }
            
            // 如果名称变更，检查是否已存在
            if (recipe.RecipeName != recipeName && await _recipeRepository.ExistsByNameAsync(recipeName))
            {
                throw new ArgumentException($"菜式名称 '{recipeName}' 已存在");
            }
            
            // 更新基本信息
            recipe.UpdateBasicInfo(
                recipeName,
                description,
                cuisineId,
                cookingMethodId,
                tasteId,
                difficultyLevel);
            
            return recipe;
        }
        
        /// <summary>
        /// 设置菜式图片
        /// </summary>
        public Task<Recipe> SetRecipeImageAsync(Recipe recipe, string imageUrl)
        {
            if (recipe == null)
            {
                throw new ArgumentNullException(nameof(recipe));
            }
            
            recipe.SetImage(imageUrl);
            return Task.FromResult(recipe);
        }
        
        /// <summary>
        /// 设置菜式时间信息
        /// </summary>
        public Task<Recipe> SetRecipeTimeInfoAsync(Recipe recipe, int? prepTime, int? cookTime, int? servings)
        {
            if (recipe == null)
            {
                throw new ArgumentNullException(nameof(recipe));
            }
            
            recipe.SetTimeInfo(prepTime, cookTime, servings);
            return Task.FromResult(recipe);
        }
        
        /// <summary>
        /// 添加菜式食材
        /// </summary>
        public async Task<Recipe> AddRecipeIngredientAsync(
            Recipe recipe, 
            Guid ingredientId, 
            decimal amount, 
            string unit, 
            int order = 0, 
            string remark = null)
        {
            if (recipe == null)
            {
                throw new ArgumentNullException(nameof(recipe));
            }
            
            // 验证食材是否存在
            var ingredient = await _ingredientRepository.GetByIdAsync(ingredientId);
            if (ingredient == null)
            {
                throw new ArgumentException($"食材ID '{ingredientId}' 不存在");
            }
            
            // 创建食材
            var recipeIngredient = new RecipeIngredient(
                Guid.NewGuid(),
                recipe.Id,
                ingredientId,
                amount.ToString(),  // 将decimal转为string
                unit,
                null,  // 食材名称，可从ingredient获取，但这里传null由实体自行处理
                null,  // 分类名称，可从ingredient获取，但这里传null由实体自行处理
                order,  // 使用顺序
                remark,
                true,  // 默认启用
                null,  // 创建人
                DateTime.Now,  // 创建时间
                DateTime.Now   // 更新时间
            );
            
            // 添加到菜式
            recipe.AddIngredient(recipeIngredient);
            
            return recipe;
        }
        
        /// <summary>
        /// 添加菜式烹饪步骤
        /// </summary>
        public Task<Recipe> AddRecipeCookingStepAsync(
            Recipe recipe, 
            int stepOrder,
            string title,
            string description, 
            string imageUrl = null, 
            string tips = null)
        {
            if (recipe == null)
            {
                throw new ArgumentNullException(nameof(recipe));
            }
            
            // 创建烹饪步骤
            var cookingStep = new RecipeCookingStep(
                Guid.NewGuid(),         // id
                recipe.Id,              // recipeId
                stepOrder,              // stepOrder
                title ?? $"步骤 {stepOrder}",    // title - 使用传入的标题，如果为空则默认使用"步骤 N"
                description,            // description - 正确放置描述
                imageUrl,               // imageUrl - 正确放置图片URL
                null,                   // videoUrl
                null,                   // videoCover
                tips,                   // tips
                null,                   // estimatedTime
                null,                   // importantNote
                null,                   // sort
                true,                   // isEnabled
                null,                   // createdBy
                DateTime.Now,           // createdAt
                DateTime.Now            // updatedAt
            );
            
            // 添加到菜式
            recipe.AddCookingStep(cookingStep);
            
            return Task.FromResult(recipe);
        }
        
        /// <summary>
        /// 批量添加菜式食材
        /// </summary>
        public async Task<Recipe> AddRecipeIngredientsAsync(
            Recipe recipe, 
            IEnumerable<(Guid IngredientId, decimal Amount, string Unit, int Order, string Remark)> ingredients)
        {
            if (recipe == null)
            {
                throw new ArgumentNullException(nameof(recipe));
            }
            
            foreach (var (ingredientId, amount, unit, order, remark) in ingredients)
            {
                await AddRecipeIngredientAsync(recipe, ingredientId, amount, unit, order, remark);
            }
            
            return recipe;
        }
        
        /// <summary>
        /// 批量添加菜式烹饪步骤
        /// </summary>
        public async Task<Recipe> AddRecipeCookingStepsAsync(
            Recipe recipe, 
            IEnumerable<(int StepOrder, string Title, string Description, string ImageUrl, string Tips)> cookingSteps)
        {
            if (recipe == null)
            {
                throw new ArgumentNullException(nameof(recipe));
            }
            
            foreach (var (stepOrder, title, description, imageUrl, tips) in cookingSteps)
            {
                await AddRecipeCookingStepAsync(recipe, stepOrder, title, description, imageUrl, tips);
            }
            
            return recipe;
        }
        
        /// <summary>
        /// 设置菜式推荐状态
        /// </summary>
        public Task<Recipe> SetRecipeRecommendationAsync(Recipe recipe, bool isRecommended)
        {
            if (recipe == null)
            {
                throw new ArgumentNullException(nameof(recipe));
            }
            
            recipe.SetRecommendation(isRecommended);
            return Task.FromResult(recipe);
        }
        
        /// <summary>
        /// 启用菜式
        /// </summary>
        public Task<Recipe> EnableRecipeAsync(Recipe recipe)
        {
            if (recipe == null)
            {
                throw new ArgumentNullException(nameof(recipe));
            }
            
            recipe.Enable();
            return Task.FromResult(recipe);
        }
        
        /// <summary>
        /// 禁用菜式
        /// </summary>
        public Task<Recipe> DisableRecipeAsync(Recipe recipe)
        {
            if (recipe == null)
            {
                throw new ArgumentNullException(nameof(recipe));
            }
            
            recipe.Disable();
            return Task.FromResult(recipe);
        }
    }
} 