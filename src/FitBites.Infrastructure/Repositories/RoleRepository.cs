using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FitBites.Core.Interfaces;
using FitBites.Domain.Entities;
using FitBites.Infrastructure.Data;
using FitBites.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace FitBites.Domain.IRepositories
{
    /// <summary>
    /// 角色仓储
    /// </summary>
    public class RoleRepository : Repository<Role>, IRoleRepository
    {
        public RoleRepository(ApplicationDbContext context) : base(context)
        {
        }

        public Task<Role?> GetRoleByCodeAsync(string roleCode)
        {
            return _dbSet.FirstOrDefaultAsync(x => x.RoleCode == roleCode);
        }

        public Task<Role?> GetRoleWithPermissionsAsync(Guid roleId)
        {
            return _dbSet.Include(o => o.PermissionMappings)
                .ThenInclude(o => o.Permission)
                .Where(o => o.Id == roleId)
                .FirstOrDefaultAsync();
        }

        public Task<List<Role>> GetUserRolesAsync(Guid userId)
        {
            return _context.UserRoles
                .Include(o => o.Role)
                .Where(o => o.UserId == userId)
                .Select(o => o.Role)
                .ToListAsync();
        }

    }
} 