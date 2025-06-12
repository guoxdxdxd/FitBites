using System;
using System.Collections.Generic;
using FitBites.Domain.Entities.Base;

namespace FitBites.Domain.Entities
{
    /// <summary>
    /// 权限实体
    /// </summary>
    public class Permission : EntityBase
    {
        /// <summary>
        /// 构造函数，初始化集合
        /// </summary>
        public Permission()
        {
            PermissionMappings = new HashSet<PermissionMapping>();
        }

        /// <summary>
        /// 种子数据构造函数
        /// </summary>
        /// <param name="id">ID</param>
        /// <param name="permissionCode">权限编码</param>
        /// <param name="description">权限描述</param>
        /// <param name="module">所属模块</param>
        /// <param name="createdAt">创建时间</param>
        /// <param name="updatedAt">更新时间</param>
        public Permission(Guid id, string permissionCode, string description, string module, DateTime createdAt, DateTime updatedAt)
        {
            Id = id;
            PermissionCode = permissionCode;
            Description = description;
            Module = module;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
            PermissionMappings = new HashSet<PermissionMapping>();
        }

        /// <summary>
        /// 权限编码（如 user.create）
        /// </summary>
        public string PermissionCode { get; private set; }

        /// <summary>
        /// 权限描述
        /// </summary>
        public string Description { get; private set; }

        /// <summary>
        /// 所属模块（如 用户管理、家庭管理）
        /// </summary>
        public string Module { get; private set; }

        /// <summary>
        /// 权限映射集合
        /// </summary>
        public virtual ICollection<PermissionMapping> PermissionMappings { get; private set; }
    }
    
    /// <summary>
    /// 权限比较器，用于确保权限集合中不存在重复项
    /// </summary>
    public class PermissionEqualityComparer : IEqualityComparer<Permission>
    {
        public bool Equals(Permission x, Permission y)
        {
            if (ReferenceEquals(x, y)) return true;
            if (x is null || y is null) return false;
            return x.Id == y.Id;
        }

        public int GetHashCode(Permission obj)
        {
            return obj.Id.GetHashCode();
        }
    }
} 