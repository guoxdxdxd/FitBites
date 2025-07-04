using System;
using System.Collections.Generic;
using FitBites.Core.Enums;
using FitBites.Domain.Entities.Base;

namespace FitBites.Domain.Entities
{
    /// <summary>
    /// 系统角色实体
    /// </summary>
    public class Role : EntityBase
    {
        /// <summary>
        /// 构造函数，初始化集合
        /// </summary>
        public Role()
        {
            UserRoles = new HashSet<UserRole>();
            PermissionMappings = new HashSet<PermissionMapping>();
        }

        /// <summary>
        /// 种子数据构造函数
        /// </summary>
        /// <param name="id">ID</param>
        /// <param name="roleCode">角色编码</param>
        /// <param name="roleName">角色名称</param>
        /// <param name="description">角色描述</param>
        /// <param name="createdAt">创建时间</param>
        /// <param name="updatedAt">更新时间</param>
        public Role(Guid id, string roleCode, string roleName, string description, DateTime createdAt, DateTime updatedAt)
        {
            Id = id;
            RoleCode = roleCode;
            RoleName = roleName;
            Description = description;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
            UserRoles = new HashSet<UserRole>();
            PermissionMappings = new HashSet<PermissionMapping>();
        }

        /// <summary>
        /// 角色编码（如 admin, user）
        /// </summary>
        public string RoleCode { get; private set; }

        /// <summary>
        /// 角色名称（系统管理员、普通用户等）
        /// </summary>
        public string RoleName { get; private set; }

        /// <summary>
        /// 角色描述
        /// </summary>
        public string Description { get; private set; }

        /// <summary>
        /// 用户角色关系集合
        /// </summary>
        public virtual ICollection<UserRole> UserRoles { get; private set; }

        /// <summary>
        /// 角色直接关联的权限映射集合
        /// </summary>
        public virtual ICollection<PermissionMapping> PermissionMappings { get; private set; }

        /// <summary>
        /// 更新角色名称和描述
        /// </summary>
        /// <param name="roleName">新名称</param>
        /// <param name="description">新描述</param>
        public void Update(string roleName, string description)
        {
            RoleName = roleName;
            Description = description;
            UpdatedAt = DateTime.Now;
        }

        /// <summary>
        /// 设置角色权限
        /// </summary>
        /// <param name="permissionIds">权限ID列表</param>
        public void SetPermissions(IEnumerable<Guid> permissionIds)
        {
            //移除
            var newPids = permissionIds.Where(pid => PermissionMappings.All(i => i.PermissionId != pid)).ToList();
            var delPers = PermissionMappings.Where(o => !permissionIds.Contains(o.PermissionId)).ToList();
            foreach (var delPer in delPers)
            {
                PermissionMappings.Remove(delPer);
            }

            //新增
            var newPers = newPids.Select(pid => new PermissionMapping(ObjectType.Role, Id, pid, true, null));
            foreach (var newPer in newPers)
            {
                PermissionMappings.Add(newPer);
            }
            
            UpdatedAt = DateTime.Now;
        }

    }
} 