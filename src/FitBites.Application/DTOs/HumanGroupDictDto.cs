using System;

namespace FitBites.Application.DTOs
{
    /// <summary>
    /// 人群标签字典DTO
    /// </summary>
    public class HumanGroupDictDto
    {
        /// <summary>
        /// ID
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// 标签名称（如：孕妇、糖尿病人）
        /// </summary>
        public string Name { get; set; }

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
    /// 创建人群标签请求DTO
    /// </summary>
    public class CreateHumanGroupDictDto
    {
        /// <summary>
        /// 标签名称（如：孕妇、糖尿病人）
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 描述说明
        /// </summary>
        public string Description { get; set; }
    }

    /// <summary>
    /// 更新人群标签请求DTO
    /// </summary>
    public class UpdateHumanGroupDictDto
    {
        /// <summary>
        /// 标签名称（如：孕妇、糖尿病人）
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 描述说明
        /// </summary>
        public string Description { get; set; }
    }
} 