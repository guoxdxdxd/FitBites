using System;
using FitBites.Domain.Entities.Base;

namespace FitBites.Domain.Entities
{
    /// <summary>
    /// 用户角色关系实体
    /// </summary>
    public class UserRole : EntityBase
    {
        public UserRole(Guid userId, Guid roleId)
        {
            Id = Guid.NewGuid();
            UserId = userId;
            RoleId = roleId;
            CreatedAt = DateTime.Now;
            UpdatedAt = DateTime.Now;
        }

        public UserRole()
        {
        }

        /// <summary>
        /// 种子数据构造函数
        /// </summary>
        /// <param name="id">ID</param>
        /// <param name="userId">用户ID</param>
        /// <param name="roleId">角色ID</param>
        /// <param name="createdAt">创建时间</param>
        /// <param name="updatedAt">更新时间</param>
        public UserRole(Guid id, Guid userId, Guid roleId, DateTime createdAt, DateTime updatedAt)
        {
            Id = id;
            UserId = userId;
            RoleId = roleId;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
        }

        /// <summary>
        /// 用户ID
        /// </summary>
        public Guid UserId { get; private set; }

        /// <summary>
        /// 角色ID
        /// </summary>
        public Guid RoleId { get; private set; }

        /// <summary>
        /// 用户导航属性
        /// </summary>
        public virtual User User { get; private set; }

        /// <summary>
        /// 角色导航属性
        /// </summary>
        public virtual Role Role { get; private set; }
    }
} 