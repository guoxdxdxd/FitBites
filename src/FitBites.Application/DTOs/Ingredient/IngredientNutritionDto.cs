using FitBites.Domain.Entities;
using System;

namespace FitBites.Application.DTOs.Ingredient
{
    /// <summary>
    /// 食材-营养成分映射数据传输对象
    /// </summary>
    public class IngredientNutritionDto
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
        /// 成分ID
        /// </summary>
        public Guid NutrientId { get; set; }

        /// <summary>
        /// 成分名称
        /// </summary>
        public string NutrientName { get; set; }

        /// <summary>
        /// 数量
        /// </summary>
        public decimal Amount { get; set; }

        /// <summary>
        /// 每单位（如每100g）
        /// </summary>
        public string PerUnit { get; set; }

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
        /// <param name="entity">食材营养成分实体</param>
        public IngredientNutritionDto(IngredientNutrition entity)
        {
            if (entity == null)
                return;

            Id = entity.Id;
            IngredientId = entity.IngredientId;
            NutrientId = entity.NutrientId;
            NutrientName = entity.Nutrient?.Name;
            Amount = entity.Amount;
            PerUnit = entity.PerUnit;
            CreatedAt = entity.CreatedAt;
            UpdatedAt = entity.UpdatedAt;
        }

        /// <summary>
        /// 默认构造函数
        /// </summary>
        public IngredientNutritionDto()
        {
        }
    }
} 