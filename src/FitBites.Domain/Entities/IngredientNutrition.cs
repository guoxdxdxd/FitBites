using System;
using FitBites.Domain.Entities.Base;

namespace FitBites.Domain.Entities
{
    /// <summary>
    /// 食材-营养成分映射实体
    /// </summary>
    public class IngredientNutrition : EntityBase
    {
        /// <summary>
        /// 种子数据构造函数
        /// </summary>
        public IngredientNutrition(Guid id, Guid ingredientId, Guid nutrientId, decimal amount, string perUnit, DateTime createdAt, DateTime updatedAt)
        {
            Id = id;
            IngredientId = ingredientId;
            NutrientId = nutrientId;
            Amount = amount;
            PerUnit = perUnit;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
        }

        /// <summary>
        /// 食材ID
        /// </summary>
        public Guid IngredientId { get; private set; }

        /// <summary>
        /// 成分ID
        /// </summary>
        public Guid NutrientId { get; private set; }

        /// <summary>
        /// 数量
        /// </summary>
        public decimal Amount { get; private set; }

        /// <summary>
        /// 每单位（如每100g）
        /// </summary>
        public string PerUnit { get; private set; }

        /// <summary>
        /// 食材导航属性
        /// </summary>
        public virtual Ingredient Ingredient { get; private set; }

        /// <summary>
        /// 营养成分导航属性
        /// </summary>
        public virtual IngredientNutritionDict Nutrient { get; private set; }
    }
} 