using System;

namespace FitBites.Application.DTOs.Recipe
{
    /// <summary>
    /// 菜式食材DTO
    /// </summary>
    public class RecipeIngredientDto
    {
        /// <summary>
        /// ID
        /// </summary>
        public Guid Id { get; set; }
        
        /// <summary>
        /// 菜式ID
        /// </summary>
        public Guid RecipeId { get; set; }
        
        /// <summary>
        /// 食材ID
        /// </summary>
        public Guid IngredientId { get; set; }
        
        /// <summary>
        /// 食材名称
        /// </summary>
        public string IngredientName { get; set; }
        
        /// <summary>
        /// 食材分类名称
        /// </summary>
        public string CategoryName { get; set; }
        
        /// <summary>
        /// 数量
        /// </summary>
        public decimal Amount { get; set; }
        
        /// <summary>
        /// 单位
        /// </summary>
        public string Unit { get; set; }
        
        /// <summary>
        /// 排序
        /// </summary>
        public int Order { get; set; }
        
        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }
    }
} 