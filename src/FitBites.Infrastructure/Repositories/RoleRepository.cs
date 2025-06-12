using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FitBites.Core.Interfaces;
using FitBites.Domain.Entities;
using FitBites.Infrastructure.Data;
using FitBites.Infrastructure.Repositories;

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

        public Task<Role> GetRoleByCodeAsync(string roleCode)
        {
            throw new NotImplementedException();
        }

        public Task<Role> GetRoleWithPermissionsAsync(Guid roleId)
        {
            throw new NotImplementedException();
        }

        public Task<List<Role>> GetUserRolesAsync(Guid userId)
        {
            throw new NotImplementedException();
        }
    }
} 