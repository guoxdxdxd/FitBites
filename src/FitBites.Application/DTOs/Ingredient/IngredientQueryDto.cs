using FitBites.Core.Enums;

namespace FitBites.Application.DTOs.Ingredient
{
    /// <summary>
    /// 食材查询数据传输对象
    /// </summary>
    public class IngredientQueryDto : PaginationRequestDto
    {
        /// <summary>
        /// 食材分类（可选）
        /// </summary>
        public IngredientCategory? Category { get; set; }
        
        /// <summary>
        /// 食材名称关键词（可选，支持模糊查询）
        /// </summary>
        public string? Keyword { get; set; }
    }
} 