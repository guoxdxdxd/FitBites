namespace FitBites.Domain.Events
{
    /// <summary>
    /// 食材创建事件
    /// </summary>
    public class IngredientCreatedEvent : DomainEvent
    {
        /// <summary>
        /// 食材ID
        /// </summary>
        public Guid IngredientId { get; }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="ingredientId">食材ID</param>
        public IngredientCreatedEvent(Guid ingredientId)
        {
            IngredientId = ingredientId;
        }
    }

    /// <summary>
    /// 食材更新事件
    /// </summary>
    public class IngredientUpdatedEvent : DomainEvent
    {
        /// <summary>
        /// 食材ID
        /// </summary>
        public Guid IngredientId { get; }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="ingredientId">食材ID</param>
        public IngredientUpdatedEvent(Guid ingredientId)
        {
            IngredientId = ingredientId;
        }
    }

    /// <summary>
    /// 食材删除事件
    /// </summary>
    public class IngredientDeletedEvent : DomainEvent
    {
        /// <summary>
        /// 食材ID
        /// </summary>
        public Guid IngredientId { get; }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="ingredientId">食材ID</param>
        public IngredientDeletedEvent(Guid ingredientId)
        {
            IngredientId = ingredientId;
        }
    }
} 