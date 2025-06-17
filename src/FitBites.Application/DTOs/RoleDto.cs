using System;
using System.Collections.Generic;

namespace FitBites.Application.DTOs
{
    /// <summary>
    /// 角色DTO
    /// </summary>
    public class RoleDto
    {
        /// <summary>
        /// 角色ID
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// 角色编码
        /// </summary>
        public string RoleCode { get; set; }

        /// <summary>
        /// 角色名称
        /// </summary>
        public string RoleName { get; set; }

        /// <summary>
        /// 角色描述
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// 更新时间
        /// </summary>
        public DateTime UpdatedAt { get; set; }

        /// <summary>
        /// 权限ID列表
        /// </summary>
        public List<Guid> PermissionIds { get; set; }

        /// <summary>
        /// 权限名称列表
        /// </summary>
        public List<string> PermissionNames { get; set; }
    }
} 