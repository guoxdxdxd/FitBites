using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FitBites.Application.DTOs;
using FitBites.Application.DTOs.Recipe;
using FitBites.Application.Services.Interfaces;
using FitBites.Core.DependencyInjection;
using FitBites.Core.Interfaces;
using FitBites.Core.Utils;
using FitBites.Domain.IRepositories;
using FitBites.Domain.Services;

namespace FitBites.Application.Services
{
    /// <summary>
    /// 菜式应用服务实现
    /// </summary>
    public class RecipeApplicationService : IRecipeApplicationService, IScopedDependency
    {
        private readonly IRecipeRepository _recipeRepository;
        private readonly IRecipeDomainService _recipeDomainService;
        private readonly IIngredientRepository _ingredientRepository;
        private readonly IUnitOfWork _unitOfWork;
        
        /// <summary>
        /// 构造函数
        /// </summary>
        public RecipeApplicationService(
            IRecipeRepository recipeRepository,
            IRecipeDomainService recipeDomainService,
            IIngredientRepository ingredientRepository,
            IUnitOfWork unitOfWork)
        {
            _recipeRepository = recipeRepository;
            _recipeDomainService = recipeDomainService;
            _ingredientRepository = ingredientRepository;
            _unitOfWork = unitOfWork;
        }
        
        /// <summary>
        /// 获取菜式详情
        /// </summary>
        public async Task<RecipeDto> GetRecipeAsync(Guid id)
        {
            var recipe = await _recipeRepository.GetByIdAsync(id);
            if (recipe == null)
            {
                throw new ApplicationException($"菜式不存在: {id}");
            }
            
            return await MapToRecipeDtoAsync(recipe);
        }
        
        /// <summary>
        /// 创建菜式
        /// </summary>
        public async Task<RecipeDto> CreateRecipeAsync(CreateRecipeDto dto)
        {
            // 创建菜式
            var recipe = await _recipeDomainService.CreateRecipeAsync(
                dto.RecipeName,
                dto.Description,
                dto.CuisineId,
                dto.CookingMethodId,
                dto.TasteId,
                dto.DifficultyLevel,
                dto.Source,
                dto.SourceId);
                
            // 设置图片
            if (!string.IsNullOrEmpty(dto.ImageUrl))
            {
                await _recipeDomainService.SetRecipeImageAsync(recipe, dto.ImageUrl);
            }
            
            // 设置时间信息
            await _recipeDomainService.SetRecipeTimeInfoAsync(recipe, dto.PrepTime, dto.CookTime, dto.Servings);
            
            // 设置推荐状态
            if (dto.Recommended.HasValue)
            {
                await _recipeDomainService.SetRecipeRecommendationAsync(recipe, dto.Recommended.Value);
            }
            
            // 添加食材
            if (dto.Ingredients != null && dto.Ingredients.Any())
            {
                var ingredients = dto.Ingredients.Select(i => (
                    i.IngredientId,
                    i.Amount,
                    i.Unit,
                    i.Order,
                    i.Remark
                ));
                
                await _recipeDomainService.AddRecipeIngredientsAsync(recipe, ingredients);
            }
            
            // 添加烹饪步骤
            if (dto.CookingSteps != null && dto.CookingSteps.Any())
            {
                var cookingSteps = dto.CookingSteps.Select(s => (
                    s.StepOrder,
                    s.Title,
                    s.Description,
                    s.ImageUrl,
                    s.Tips
                ));
                
                await _recipeDomainService.AddRecipeCookingStepsAsync(recipe, cookingSteps);
            }
            
            // 保存到数据库
            await _recipeRepository.AddAsync(recipe);
            await _unitOfWork.SaveChangesAsync();
            
            // 返回DTO
            return await MapToRecipeDtoAsync(recipe);
        }
        
        /// <summary>
        /// 更新菜式基本信息
        /// </summary>
        public async Task<RecipeDto> UpdateRecipeBasicInfoAsync(UpdateRecipeDto dto)
        {
            var recipe = await _recipeRepository.GetByIdAsync(dto.Id);
            if (recipe == null)
            {
                throw new ApplicationException($"菜式不存在: {dto.Id}");
            }
            
            // 更新基本信息
            await _recipeDomainService.UpdateRecipeBasicInfoAsync(
                recipe,
                dto.RecipeName,
                dto.Description,
                dto.CuisineId,
                dto.CookingMethodId,
                dto.TasteId,
                dto.DifficultyLevel);
                
            // 设置时间信息
            await _recipeDomainService.SetRecipeTimeInfoAsync(recipe, dto.PrepTime, dto.CookTime, dto.Servings);
            
            // 设置推荐状态
            if (dto.Recommended.HasValue)
            {
                await _recipeDomainService.SetRecipeRecommendationAsync(recipe, dto.Recommended.Value);
            }
            
            // 保存到数据库
            await _unitOfWork.SaveChangesAsync();
            
            // 返回DTO
            return await MapToRecipeDtoAsync(recipe);
        }
        
        /// <summary>
        /// 设置菜式图片
        /// </summary>
        public async Task<RecipeDto> SetRecipeImageAsync(Guid id, string imageUrl)
        {
            var recipe = await _recipeRepository.GetByIdAsync(id);
            if (recipe == null)
            {
                throw new ApplicationException($"菜式不存在: {id}");
            }
            
            // 设置图片
            await _recipeDomainService.SetRecipeImageAsync(recipe, imageUrl);
            
            // 保存到数据库
            await _unitOfWork.SaveChangesAsync();
            
            // 返回DTO
            return await MapToRecipeDtoAsync(recipe);
        }
        
        /// <summary>
        /// 设置菜式时间信息
        /// </summary>
        public async Task<RecipeDto> SetRecipeTimeInfoAsync(Guid id, int? prepTime, int? cookTime, int? servings)
        {
            var recipe = await _recipeRepository.GetByIdAsync(id);
            if (recipe == null)
            {
                throw new ApplicationException($"菜式不存在: {id}");
            }
            
            // 设置时间信息
            await _recipeDomainService.SetRecipeTimeInfoAsync(recipe, prepTime, cookTime, servings);
            
            // 保存到数据库
            await _unitOfWork.SaveChangesAsync();
            
            // 返回DTO
            return await MapToRecipeDtoAsync(recipe);
        }
        
        /// <summary>
        /// 添加菜式食材
        /// </summary>
        public async Task<RecipeDto> AddRecipeIngredientAsync(Guid id, CreateRecipeIngredientDto dto)
        {
            var recipe = await _recipeRepository.GetByIdAsync(id);
            if (recipe == null)
            {
                throw new ApplicationException($"菜式不存在: {id}");
            }
            
            // 添加食材
            await _recipeDomainService.AddRecipeIngredientAsync(
                recipe,
                dto.IngredientId,
                dto.Amount,
                dto.Unit,
                dto.Order,
                dto.Remark);
                
            // 保存到数据库
            await _unitOfWork.SaveChangesAsync();
            
            // 返回DTO
            return await MapToRecipeDtoAsync(recipe);
        }
        
        /// <summary>
        /// 添加菜式烹饪步骤
        /// </summary>
        public async Task<RecipeDto> AddRecipeCookingStepAsync(Guid id, CreateRecipeCookingStepDto dto)
        {
            var recipe = await _recipeRepository.GetByIdAsync(id);
            if (recipe == null)
            {
                throw new ApplicationException($"菜式不存在: {id}");
            }
            
            // 添加烹饪步骤
            await _recipeDomainService.AddRecipeCookingStepAsync(
                recipe,
                dto.StepOrder,
                dto.Title,
                dto.Description,
                dto.ImageUrl,
                dto.Tips);
                
            // 保存到数据库
            await _unitOfWork.SaveChangesAsync();
            
            // 返回DTO
            return await MapToRecipeDtoAsync(recipe);
        }
        
        /// <summary>
        /// 设置菜式推荐状态
        /// </summary>
        public async Task<RecipeDto> SetRecipeRecommendationAsync(Guid id, bool isRecommended)
        {
            var recipe = await _recipeRepository.GetByIdAsync(id);
            if (recipe == null)
            {
                throw new ApplicationException($"菜式不存在: {id}");
            }
            
            // 设置推荐状态
            await _recipeDomainService.SetRecipeRecommendationAsync(recipe, isRecommended);
            
            // 保存到数据库
            await _unitOfWork.SaveChangesAsync();
            
            // 返回DTO
            return await MapToRecipeDtoAsync(recipe);
        }
        
        /// <summary>
        /// 启用菜式
        /// </summary>
        public async Task<RecipeDto> EnableRecipeAsync(Guid id)
        {
            var recipe = await _recipeRepository.GetByIdAsync(id);
            if (recipe == null)
            {
                throw new ApplicationException($"菜式不存在: {id}");
            }
            
            // 启用菜式
            await _recipeDomainService.EnableRecipeAsync(recipe);
            
            // 保存到数据库
            await _unitOfWork.SaveChangesAsync();
            
            // 返回DTO
            return await MapToRecipeDtoAsync(recipe);
        }
        
        /// <summary>
        /// 禁用菜式
        /// </summary>
        public async Task<RecipeDto> DisableRecipeAsync(Guid id)
        {
            var recipe = await _recipeRepository.GetByIdAsync(id);
            if (recipe == null)
            {
                throw new ApplicationException($"菜式不存在: {id}");
            }
            
            // 禁用菜式
            await _recipeDomainService.DisableRecipeAsync(recipe);
            
            // 保存到数据库
            await _unitOfWork.SaveChangesAsync();
            
            // 返回DTO
            return await MapToRecipeDtoAsync(recipe);
        }
        
        /// <summary>
        /// 获取推荐菜式列表
        /// </summary>
        public async Task<List<RecipeDto>> GetRecommendedRecipesAsync(int count = 10)
        {
            // 获取推荐菜式
            var recipes = await _recipeRepository.GetRecipesBySourceAsync(Core.Enums.RecipeSource.System, null, 1, count);
            var dtos = new List<RecipeDto>();
            
            foreach (var recipe in recipes)
            {
                dtos.Add(await MapToRecipeDtoAsync(recipe));
            }
            
            return dtos;
        }
        
        /// <summary>
        /// 分页获取菜式列表
        /// </summary>
        public async Task<PaginationResponseDto<RecipeDto>> GetRecipeListAsync(int page = 1, int pageSize = 10, string keyword = null)
        {
            // 获取总数
            var totalCount = await _recipeRepository.GetRecipesCountAsync(keyword: keyword);
            
            // 搜索菜式
            var recipes = await _recipeRepository.SearchRecipesAsync(keyword, page, pageSize);
            
            // 转换为DTO
            var dtos = new List<RecipeDto>();
            foreach (var recipe in recipes)
            {
                dtos.Add(await MapToRecipeDtoAsync(recipe));
            }
            
            // 返回分页结果
            return new PaginationResponseDto<RecipeDto>
            {
                PageIndex = page,
                PageSize = pageSize,
                TotalCount = totalCount,
                Items = dtos
            };
        }
        
        /// <summary>
        /// 将实体映射为DTO
        /// </summary>
        private async Task<RecipeDto> MapToRecipeDtoAsync(Domain.Entities.Recipe recipe)
        {
            var dto = new RecipeDto
            {
                Id = recipe.Id,
                RecipeName = recipe.RecipeName,
                ImageUrl = recipe.ImageUrl,
                Description = recipe.Description,
                CuisineId = recipe.CuisineId,
                CookingMethodId = recipe.CookingMethodId,
                TasteId = recipe.TasteId,
                DifficultyLevel = recipe.DifficultyLevel,
                DifficultyLevelName = recipe.DifficultyLevel.ToString(),
                PrepTime = recipe.PrepTime,
                CookTime = recipe.CookTime,
                TotalTime = recipe.GetTotalCookingTime(),
                Servings = recipe.Servings,
                Recommended = recipe.Recommended,
                Status = recipe.Status,
                Source = recipe.Source,
                SourceName = recipe.Source.ToString(),
                SourceId = recipe.SourceId,
                CreatedAt = recipe.CreatedAt,
                UpdatedAt = recipe.UpdatedAt
            };
            
            // 设置关联实体名称 - 使用导航属性
            if (recipe.CuisineId.HasValue && recipe.Cuisine != null)
            {
                dto.CuisineName = recipe.Cuisine.Name;
            }
            
            if (recipe.CookingMethodId.HasValue && recipe.CookingMethod != null)
            {
                dto.CookingMethodName = recipe.CookingMethod.Name;
            }
            
            if (recipe.TasteId.HasValue && recipe.Taste != null)
            {
                dto.TasteName = recipe.Taste.Name;
            }
            
            // 设置食材列表
            if (recipe.Ingredients != null)
            {
                foreach (var ingredient in recipe.Ingredients)
                {
                    var ingredientName = "未知食材";
                    var categoryName = "未知分类";
                    
                    // 使用导航属性获取食材信息
                    if (ingredient.Ingredient != null)
                    {
                        ingredientName = ingredient.Ingredient.Name;
                        if (ingredient.Ingredient.Category != null)
                        {
                            categoryName = ingredient.Ingredient.Category.GetDescription();
                        }
                    }
                    
                    dto.Ingredients.Add(new RecipeIngredientDto
                    {
                        Id = ingredient.Id,
                        RecipeId = ingredient.RecipeId,
                        IngredientId = ingredient.IngredientId,
                        IngredientName = ingredientName,
                        CategoryName = categoryName,
                        Amount = decimal.TryParse(ingredient.IngredientWeight, out var amount) ? amount : 0,
                        Unit = ingredient.RoleType ?? "",
                        Order = ingredient.UsageOrder ?? 0,
                        Remark = ingredient.Notes
                    });
                }
                
                // 按排序号排序
                dto.Ingredients = dto.Ingredients.OrderBy(i => i.Order).ToList();
            }
            
            // 设置烹饪步骤列表
            if (recipe.CookingSteps != null)
            {
                foreach (var step in recipe.CookingSteps)
                {
                    dto.CookingSteps.Add(new RecipeCookingStepDto
                    {
                        Id = step.Id,
                        RecipeId = step.RecipeId,
                        StepOrder = step.StepNumber,
                        Title = step.Title,
                        Description = step.Description,
                        ImageUrl = step.ImageUrl,
                        Tips = step.AiInstruction
                    });
                }
                
                // 按步骤号排序
                dto.CookingSteps = dto.CookingSteps.OrderBy(s => s.StepOrder).ToList();
            }
            
            return dto;
        }
    }
} 