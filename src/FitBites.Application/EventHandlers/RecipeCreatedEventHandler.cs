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
    /// 菜式创建事件处理器
    /// </summary>
    public class RecipeCreatedEventHandler : IDomainEventHandler<RecipeCreatedEvent>, IScopedDependency
    {
        private readonly ILogger<RecipeCreatedEventHandler> _logger;
        private readonly IRecipeRepository _recipeRepository;
        private readonly ICacheService _cacheService;
        
        /// <summary>
        /// 构造函数
        /// </summary>
        public RecipeCreatedEventHandler(
            ILogger<RecipeCreatedEventHandler> logger,
            IRecipeRepository recipeRepository,
            ICacheService cacheService)
        {
            _logger = logger;
            _recipeRepository = recipeRepository;
            _cacheService = cacheService;
        }
        
        /// <summary>
        /// 处理菜式创建事件
        /// </summary>
        public async Task HandleAsync(RecipeCreatedEvent domainEvent)
        {
            try
            {
                // 获取菜式信息
                var recipe = await _recipeRepository.GetByIdAsync(domainEvent.RecipeId);
                if (recipe == null)
                {
                    _logger.LogWarning("菜式创建事件处理失败：菜式不存在 {RecipeId}", domainEvent.RecipeId);
                    return;
                }
                
                // 清除相关缓存
                await ClearRecipeCacheAsync();
                
                // 记录日志
                _logger.LogInformation("菜式创建成功: {RecipeId}, {RecipeName}", recipe.Id, recipe.RecipeName);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "处理菜式创建事件时发生错误: {RecipeId}", domainEvent.RecipeId);
            }
        }
        
        /// <summary>
        /// 清除菜式相关缓存
        /// </summary>
        private async Task ClearRecipeCacheAsync()
        {
            try
            {
                // 清除推荐菜式列表缓存
                await _cacheService.RemoveAsync("Recipe:Recommended");
                
                // 清除菜式统计缓存
                await _cacheService.RemoveAsync("Recipe:Count");
                
                _logger.LogInformation("已清除菜式相关缓存");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "清除菜式相关缓存时发生错误");
            }
        }
    }
} 