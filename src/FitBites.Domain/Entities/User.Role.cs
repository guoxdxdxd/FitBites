using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using FitBites.Domain.Events;

namespace FitBites.Domain.Entities
{
    /// <summary>
    /// 用户聚合根 - 角色和权限相关方法
    /// </summary>
    public partial class User
    {
        /// <summary>
        /// 获取用户所有有效权限（包括直接权限和角色权限）
        /// 非数据库字段
        /// </summary>
        [NotMapped]
        public IEnumerable<Permission> AllPermissions
        {
            get
            {
                var now = DateTime.Now;
                var permissionSet = new HashSet<Permission>(new PermissionEqualityComparer());

                // 添加用户直接拥有的有效权限
                foreach (var mapping in PermissionMappings.Where(pm =>
                             pm.Status && (pm.ExpireTime == null || pm.ExpireTime > now)))
                {
                    permissionSet.Add(mapping.Permission);
                }

                // 添加用户通过角色获得的有效权限
                foreach (var userRole in UserRoles)
                {
                    if (userRole.Role?.PermissionMappings != null)
                    {
                        foreach (var mapping in userRole.Role.PermissionMappings.Where(pm =>
                                     pm.Status && (pm.ExpireTime == null || pm.ExpireTime > now)))
                        {
                            permissionSet.Add(mapping.Permission);
                        }
                    }
                }

                return permissionSet;
            }
        }


        public void AddPermissionMapping(PermissionMapping permissionMapping)
        {
            PermissionMappings.Add(permissionMapping);
            AddDomainEvent(new UserPermissionGrantedEvent(Id, permissionMapping.PermissionId, permissionMapping.ExpireTime));
        }


        /// <summary>
        /// 获取用户所有角色
        /// </summary>
        /// <returns>角色列表</returns>
        public List<Role> GetRoles()
        {
            return UserRoles.Select(ur => ur.Role).ToList();
        }

        /// <summary>
        /// 检查用户是否有指定权限
        /// </summary>
        /// <param name="permissionCode">权限代码</param>
        /// <returns>是否有权限</returns>
        public bool HasPermission(string permissionCode)
        {
            return AllPermissions.Any(p => p.PermissionCode == permissionCode);
        }

        /// <summary>
        /// 检查用户是否有指定角色
        /// </summary>
        /// <param name="roleCode">角色代码</param>
        /// <returns>是否有角色</returns>
        public bool HasRole(string roleCode)
        {
            return UserRoles.Any(ur => ur.Role?.RoleCode == roleCode);
        }

        /// <summary>
        /// 添加角色
        /// </summary>
        /// <param name="role">角色</param>
        public void AddRole(Role role)
        {
            if (!UserRoles.Any(ur => ur.RoleId == role.Id))
            {
                UserRoles.Add(new UserRole(Id, role.Id));
                
                AddDomainEvent(new UserRoleAssignedEvent(Id, role.Id));
            }
        }
    }
} 