using System.ComponentModel.DataAnnotations;
using FitBites.Core.Enums;

namespace FitBites.Application.Dtos.Preference
{
    /// <summary>
    /// 偏好更新DTO
    /// </summary>
    public class PreferenceUpdateDto
    {
        /// <summary>
        /// 偏好类型
        /// </summary>
        [Required(ErrorMessage = "偏好类型不能为空")]
        public PreferenceTargetType Type { get; set; }
        
        /// <summary>
        /// 名称
        /// </summary>
        [StringLength(50, ErrorMessage = "名称长度不能超过50个字符")]
        public string? Name { get; set; }
        
        /// <summary>
        /// 描述
        /// </summary>
        [StringLength(500, ErrorMessage = "描述长度不能超过500个字符")]
        public string? Description { get; set; }
        
        /// <summary>
        /// 排序值
        /// </summary>
        public int? SortOrder { get; set; }
    }
} 