using System;

namespace FitBites.Domain.Events
{
    /// <summary>
    /// 菜式更新事件
    /// </summary>
    public class RecipeUpdatedEvent : DomainEvent
    {
        /// <summary>
        /// 菜式ID
        /// </summary>
        public Guid RecipeId { get; }
        
        /// <summary>
        /// 构造函数
        /// </summary>
        public RecipeUpdatedEvent(Guid recipeId)
        {
            RecipeId = recipeId;
        }
    }
} 