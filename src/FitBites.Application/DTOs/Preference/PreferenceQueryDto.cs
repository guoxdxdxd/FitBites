using FitBites.Core.Enums;

namespace FitBites.Application.Dtos.Preference
{
    /// <summary>
    /// 偏好查询参数DTO
    /// </summary>
    public class PreferenceQueryDto
    {
        /// <summary>
        /// 偏好目标类型
        /// </summary>
        public PreferenceTargetType TargetType { get; set; }
        
        /// <summary>
        /// 名称（可空可模糊查询）
        /// </summary>
        public string? Name { get; set; }
    }
} 