using System.ComponentModel.DataAnnotations;

namespace FitBites.Application.DTOs.Recipe
{
    /// <summary>
    /// 更新菜式食材DTO
    /// </summary>
    public class UpdateRecipeIngredientDto
    {
        /// <summary>
        /// 数量
        /// </summary>
        [Required(ErrorMessage = "食材数量不能为空")]
        [Range(0.01, 9999, ErrorMessage = "食材数量必须大于0")]
        public decimal Amount { get; set; }
        
        /// <summary>
        /// 单位
        /// </summary>
        [Required(ErrorMessage = "食材单位不能为空")]
        [StringLength(20, ErrorMessage = "食材单位长度不能超过20个字符")]
        public string Unit { get; set; }
        
        /// <summary>
        /// 排序
        /// </summary>
        public int Order { get; set; }
        
        /// <summary>
        /// 备注
        /// </summary>
        [StringLength(100, ErrorMessage = "备注长度不能超过100个字符")]
        public string Remark { get; set; }
    }
} 