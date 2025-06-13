using FitBites.Core.Enums;
using FitBites.Domain.Entities;
using System;

namespace FitBites.Application.DTOs.Ingredient
{
    /// <summary>
    /// 食材-人群适宜/忌用映射数据传输对象
    /// </summary>
    public class IngredientHumanGroupDto
    {
        /// <summary>
        /// ID
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// 食材ID
        /// </summary>
        public Guid IngredientId { get; set; }

        /// <summary>
        /// 人群标签ID
        /// </summary>
        public Guid GroupId { get; set; }

        /// <summary>
        /// 人群标签名称
        /// </summary>
        public string GroupName { get; set; }

        /// <summary>
        /// 类型（适用/忌用/慎用）
        /// </summary>
        public EffectType Effect { get; set; }

        /// <summary>
        /// 类型名称
        /// </summary>
        public string EffectName { get; set; }

        /// <summary>
        /// 补充说明
        /// </summary>
        public string Notes { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// 更新时间
        /// </summary>
        public DateTime? UpdatedAt { get; set; }

        /// <summary>
        /// 根据实体创建DTO
        /// </summary>
        /// <param name="entity">食材人群适宜/忌用映射实体</param>
        public IngredientHumanGroupDto(IngredientHumanGroup entity)
        {
            if (entity == null)
                return;

            Id = entity.Id;
            IngredientId = entity.IngredientId;
            GroupId = entity.GroupId;
            GroupName = entity.HumanGroup?.Name;
            Effect = entity.Effect;
            EffectName = entity.Effect.ToString();
            Notes = entity.Notes;
            CreatedAt = entity.CreatedAt;
            UpdatedAt = entity.UpdatedAt;
        }

        /// <summary>
        /// 默认构造函数
        /// </summary>
        public IngredientHumanGroupDto()
        {
        }
    }
} 