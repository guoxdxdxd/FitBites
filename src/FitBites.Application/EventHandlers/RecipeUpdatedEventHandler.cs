using System;
using System.Threading.Tasks;
using FitBites.Core.DependencyInjection;
using FitBites.Core.Interfaces;
using FitBites.Domain.Events;
using FitBites.Domain.IRepositories;
using Microsoft.Extensions.Logging;

namespace FitBites.Application.EventHandlers
{
    /// <summary>
    /// 菜式更新事件处理器
    /// </summary>
    public class RecipeUpdatedEventHandler : IDomainEventHandler<RecipeUpdatedEvent>, IScopedDependency
    {
        private readonly ILogger<RecipeUpdatedEventHandler> _logger;
        private readonly IRecipeRepository _recipeRepository;
        private readonly ICacheService _cacheService;
        
        /// <summary>
        /// 构造函数
        /// </summary>
        public RecipeUpdatedEventHandler(
            ILogger<RecipeUpdatedEventHandler> logger,
            IRecipeRepository recipeRepository,
            ICacheService cacheService)
        {
            _logger = logger;
            _recipeRepository = recipeRepository;
            _cacheService = cacheService;
        }
        
        /// <summary>
        /// 处理菜式更新事件
        /// </summary>
        public async Task HandleAsync(RecipeUpdatedEvent domainEvent)
        {
            try
            {
                // 获取菜式信息
                var recipe = await _recipeRepository.GetByIdAsync(domainEvent.RecipeId);
                if (recipe == null)
                {
                    _logger.LogWarning("菜式更新事件处理失败：菜式不存在 {RecipeId}", domainEvent.RecipeId);
                    return;
                }
                
                // 清除菜式缓存
                await _cacheService.RemoveAsync($"Recipe:{recipe.Id}");
                
                // 如果是推荐菜式，清除推荐菜式列表缓存
                if (recipe.Recommended == true)
                {
                    await _cacheService.RemoveAsync("Recipe:Recommended");
                }
                
                // 记录日志
                _logger.LogInformation("菜式更新成功: {RecipeId}, {RecipeName}", recipe.Id, recipe.RecipeName);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "处理菜式更新事件时发生错误: {RecipeId}", domainEvent.RecipeId);
            }
        }
    }
} 