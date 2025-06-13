using System;

namespace FitBites.Domain.Events
{
    /// <summary>
    /// 菜式创建事件
    /// </summary>
    public class RecipeCreatedEvent : DomainEvent
    {
        /// <summary>
        /// 菜式ID
        /// </summary>
        public Guid RecipeId { get; }
        
        /// <summary>
        /// 构造函数
        /// </summary>
        public RecipeCreatedEvent(Guid recipeId)
        {
            RecipeId = recipeId;
        }
    }
} 