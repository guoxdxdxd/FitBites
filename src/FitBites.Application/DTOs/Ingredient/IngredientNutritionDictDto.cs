using System;

namespace FitBites.Application.DTOs.Ingredient
{
    /// <summary>
    /// 营养成分字典DTO
    /// </summary>
    public class IngredientNutritionDictDto
    {
        /// <summary>
        /// ID
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// 成分名称（如：蛋白质）
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 单位（g、mg、μg等）
        /// </summary>
        public string Unit { get; set; }

        /// <summary>
        /// 描述说明
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// 更新时间
        /// </summary>
        public DateTime? UpdatedAt { get; set; }
    }

    /// <summary>
    /// 创建营养成分字典请求DTO
    /// </summary>
    public class CreateIngredientNutritionDictDto
    {
        /// <summary>
        /// 成分名称（如：蛋白质）
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 单位（g、mg、μg等）
        /// </summary>
        public string Unit { get; set; }

        /// <summary>
        /// 描述说明
        /// </summary>
        public string Description { get; set; }
    }

    /// <summary>
    /// 更新营养成分字典请求DTO
    /// </summary>
    public class UpdateIngredientNutritionDictDto
    {
        /// <summary>
        /// 成分名称（如：蛋白质）
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 单位（g、mg、μg等）
        /// </summary>
        public string Unit { get; set; }

        /// <summary>
        /// 描述说明
        /// </summary>
        public string Description { get; set; }
    }
} 