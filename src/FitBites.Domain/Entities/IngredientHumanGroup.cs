using System;
using FitBites.Core.Enums;
using FitBites.Domain.Entities.Base;

namespace FitBites.Domain.Entities
{
    /// <summary>
    /// 食材-人群适宜/忌用映射实体
    /// </summary>
    public class IngredientHumanGroup : EntityBase
    {
        /// <summary>
        /// 种子数据构造函数
        /// </summary>
        public IngredientHumanGroup(Guid id, Guid ingredientId, Guid groupId, EffectType effect, string notes, DateTime createdAt, DateTime updatedAt)
        {
            Id = id;
            IngredientId = ingredientId;
            GroupId = groupId;
            Effect = effect;
            Notes = notes;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
        }

        /// <summary>
        /// 食材ID
        /// </summary>
        public Guid IngredientId { get; private set; }

        /// <summary>
        /// 人群标签ID
        /// </summary>
        public Guid GroupId { get; private set; }

        /// <summary>
        /// 类型（适用/忌用/慎用）
        /// </summary>
        public EffectType Effect { get; private set; }

        /// <summary>
        /// 补充说明
        /// </summary>
        public string Notes { get; private set; }

        /// <summary>
        /// 食材导航属性
        /// </summary>
        public virtual Ingredient Ingredient { get; private set; }

        /// <summary>
        /// 人群标签导航属性
        /// </summary>
        public virtual HumanGroupDict HumanGroup { get; private set; }
    }
} 