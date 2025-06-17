using System;

namespace FitBites.Application.DTOs
{
    /// <summary>
    /// 权限DTO
    /// </summary>
    public class PermissionDto
    {
        /// <summary>
        /// 权限ID
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// 权限编码（如 user.create）
        /// </summary>
        public string PermissionCode { get; set; }

        /// <summary>
        /// 权限描述
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 所属模块（如 用户管理、家庭管理）
        /// </summary>
        public string Module { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// 更新时间
        /// </summary>
        public DateTime? UpdatedAt { get; set; }
    }
} 