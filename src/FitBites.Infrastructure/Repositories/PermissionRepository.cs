using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FitBites.Core.Enums;
using FitBites.Domain.Entities;
using FitBites.Domain.IRepositories;
using FitBites.Infrastructure.Data;
using FitBites.Infrastructure.Extensions;
using Microsoft.EntityFrameworkCore;

namespace FitBites.Infrastructure.Repositories
{
    /// <summary>
    /// 权限仓储实现
    /// </summary>
    public class PermissionRepository : Repository<Permission>, IPermissionRepository
    {
        private readonly DbContext _dbContext;
        
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dbContext">数据库上下文</param>
        public PermissionRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
        
        /// <summary>
        /// 获取用户权限
        /// </summary>
        /// <param name="userId">用户ID</param>
        /// <param name="checkExpiration">是否检查过期时间</param>
        /// <returns>用户权限列表</returns>
        public async Task<List<Permission>> GetUserPermissionsAsync(Guid userId, bool checkExpiration = true)
        {
            return await _dbContext.Set<PermissionMapping>()
                .Where(pm => pm.ObjectType == ObjectType.User && pm.ObjectId == userId && pm.Status)
                .WhereIf(checkExpiration, pm => pm.ExpireTime == null || pm.ExpireTime > DateTime.Now)
                .Include(pm => pm.Permission)
                .AsSplitQuery()
                .Select(pm => pm.Permission)
                .ToListAsync();
        }
        
        /// <summary>
        /// 获取角色权限
        /// </summary>
        /// <param name="roleId">角色ID</param>
        /// <param name="checkExpiration">是否检查过期时间</param>
        /// <returns>角色权限列表</returns>
        public async Task<List<Permission>> GetRolePermissionsAsync(Guid roleId, bool checkExpiration = true)
        {
            return await _dbContext.Set<PermissionMapping>()
                .Where(pm => pm.ObjectType == ObjectType.Role && pm.ObjectId == roleId && pm.Status)
                .WhereIf(checkExpiration, pm => pm.ExpireTime == null || pm.ExpireTime > DateTime.Now)
                .Include(pm => pm.Permission)
                .AsSplitQuery()
                .Select(pm => pm.Permission)
                .ToListAsync();
        }

        public Task<List<Permission>> GetUserPermissionsAsync(Guid userId)
        {
            throw new NotImplementedException();
        }

        public Task<List<Permission>> GetRolePermissionsAsync(Guid roleId)
        {
            throw new NotImplementedException();
        }
    }
} 