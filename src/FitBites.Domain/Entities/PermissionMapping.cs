using System;
using FitBites.Core.Enums;
using FitBites.Domain.Entities.Base;

namespace FitBites.Domain.Entities
{
    /// <summary>
    /// 权限映射实体
    /// </summary>
    public class PermissionMapping : EntityBase
    {
        public PermissionMapping()
        {
        }

        public PermissionMapping(ObjectType objectType, Guid objectId, Guid permissionId, bool status, DateTime? expireTime)
        {
            Id = Guid.NewGuid();
            ObjectType = objectType;
            ObjectId = objectId;
            PermissionId = permissionId;
            Status = status;
            ExpireTime = expireTime;
            CreatedAt = DateTime.Now;
            UpdatedAt = DateTime.Now;
        }

        /// <summary>
        /// 种子数据构造函数
        /// </summary>
        /// <param name="id">ID</param>
        /// <param name="objectType">对象类型</param>
        /// <param name="objectId">对象ID</param>
        /// <param name="permissionId">权限ID</param>
        /// <param name="status">状态</param>
        /// <param name="createdAt">创建时间</param>
        /// <param name="updatedAt">更新时间</param>
        public PermissionMapping(Guid id, ObjectType objectType, Guid objectId, Guid permissionId, bool status, DateTime createdAt, DateTime updatedAt)
        {
            Id = id;
            ObjectType = objectType;
            ObjectId = objectId;
            PermissionId = permissionId;
            Status = status;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
        }

        /// <summary>
        /// 对象类型（角色/用户）
        /// </summary>
        public ObjectType ObjectType { get; private set; }

        /// <summary>
        /// 对应角色ID或用户ID
        /// </summary>
        public Guid ObjectId { get; private set; }

        /// <summary>
        /// 权限ID
        /// </summary>
        public Guid PermissionId { get; private set; }

        /// <summary>
        /// 是否启用
        /// </summary>
        public bool Status { get; private set; }

        /// <summary>
        /// 到期时间（可空，表示永久有效）
        /// </summary>
        public DateTime? ExpireTime { get; private set; }

        /// <summary>
        /// 权限导航属性
        /// </summary>
        public virtual Permission Permission { get; private set; }

        /// <summary>
        /// 用户导航属性（当ObjectType为用户类型时）
        /// </summary>
        public virtual User User { get; private set; }

        /// <summary>
        /// 角色导航属性（当ObjectType为角色类型时）
        /// </summary>
        public virtual Role Role { get; private set; }
    }
} 