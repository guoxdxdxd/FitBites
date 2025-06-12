using FitBites.Core.Enums;
using FitBites.Domain.Entities;
using FitBites.Domain.IRepositories;
using FitBites.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using FitBites.Infrastructure.Extensions;

namespace FitBites.Infrastructure.Repositories;

public class UserRepository : Repository<User>, IUserRepository
{
    private readonly ApplicationDbContext _dbContext;
        
    /// <summary>
    /// 构造函数
    /// </summary>
    /// <param name="dbContext">数据库上下文</param>
    public UserRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<User?> GetByIdAsync(Guid id)
    {
        return await _dbContext.Users.FindAsync(id);
    }

    public async Task<User?> GetByUsernameAsync(string username)
    {
        return await _dbContext.Users
            .FirstOrDefaultAsync(u => u.Username == username);
    }

    public async Task<User?> GetByPhoneAsync(string phone)
    {
        return await _dbContext.Users
            .FirstOrDefaultAsync(u => u.Phone == phone);
    }

    /// <summary>
    /// 根据账号（用户名或手机号）获取用户及其权限信息
    /// </summary>
    /// <param name="account">账号（用户名或手机号）</param>
    /// <returns>用户实体，包含角色和权限信息</returns>
    public async Task<User> GetUserWithPermissionsByAccountAsync(string account)
    {
        // 根据用户名或手机号查询用户
        var user = await _dbContext.Set<User>()
            .Where(u => u.Username == account || u.Phone == account)
            // 包含用户角色关系及角色信息
            .Include(u => u.UserRoles)
                .ThenInclude(ur => ur.Role)
                    .ThenInclude(r => r.PermissionMappings)
                        .ThenInclude(pm => pm.Permission)
            // 包含用户直接拥有的权限
            .Include(u => u.PermissionMappings)
                .ThenInclude(pm => pm.Permission)
            .AsSplitQuery()
            .FirstOrDefaultAsync();

        return user;
    }

    /// <summary>
    /// 根据刷新令牌获取用户及其权限信息
    /// </summary>
    /// <param name="refreshToken">刷新令牌</param>
    /// <returns>用户实体，包含角色和权限信息</returns>
    public async Task<User> GetUserByRefreshTokenAsync(string refreshToken)
    {
        // 根据刷新令牌查询用户
        var user = await _dbContext.Set<User>()
            .Where(u => u.RefreshToken == refreshToken)
            // 包含用户角色关系及角色信息
            .Include(u => u.UserRoles)
                .ThenInclude(ur => ur.Role)
                    .ThenInclude(r => r.PermissionMappings)
                        .ThenInclude(pm => pm.Permission)
            // 包含用户直接拥有的权限
            .Include(u => u.PermissionMappings)
                .ThenInclude(pm => pm.Permission)
            .AsSplitQuery()
            .FirstOrDefaultAsync();

        return user;
    }

    public async Task<IEnumerable<User>> GetUsersByFamilyIdAsync(Guid familyId)
    {
        var users = await _dbContext.FamilyMembers
            .Where(fm => fm.FamilyId == familyId)
            .Include(fm => fm.User)
            .AsSplitQuery()
            .Select(fm => fm.User)
            .ToListAsync();

        return users;
    }

    public async Task<IEnumerable<User>> GetUsersByRoleCodeAsync(string roleCode)
    {
        var users = await _dbContext.UserRoles
            .Where(ur => ur.Role.RoleCode == roleCode)
            .Include(ur => ur.User)
            .AsSplitQuery()
            .Select(ur => ur.User)
            .ToListAsync();

        return users;
    }

    /// <summary>
    /// 根据人群组ID获取用户列表
    /// </summary>
    /// <param name="humanGroupId">人群组ID</param>
    /// <returns>用户列表</returns>
    public async Task<IEnumerable<User>> GetUsersByHumanGroupIdAsync(Guid humanGroupId)
    {
        var users = await _dbContext.UserHumanGroups
            .Where(uhg => uhg.GroupId == humanGroupId)
            .Include(uhg => uhg.User)
            .AsSplitQuery()
            .Select(uhg => uhg.User)
            .ToListAsync();

        return users;
    }

    public async Task<User?> FindByUsernameAsync(string username)
    {
        return await _dbContext.Users
            .FirstOrDefaultAsync(u => u.Username == username);
    }
    
    public async Task<bool> IsUsernameUniqueAsync(string username)
    {
        return !await _dbContext.Users.AnyAsync(u => u.Username == username);
    }

    /// <summary>
    /// 获取用户信息（包括用户偏好）
    /// </summary>
    /// <param name="id">用户ID</param>
    /// <param name="targetType">用户偏好类型</param>
    /// <param name="userPreferenceId">用户偏好ID，如果不为默认值，则只查询指定的偏好</param>
    /// <returns>用户信息</returns>
    public async Task<User?> GetWithPreferencesByIdAsync(Guid id
        , PreferenceTargetType? targetType = null
        , Guid userPreferenceId = default)
    {
        return await _dbContext.Users
            .Where(o => o.Id == id)
            .IncludeIf(targetType.HasValue && userPreferenceId == Guid.Empty, u => u.UserPreferences.Where(p => p.TargetType == targetType))
            .IncludeIf(!targetType.HasValue && userPreferenceId != Guid.Empty, u => u.UserPreferences.Where(p => p.Id == userPreferenceId))
            .IncludeIf(targetType.HasValue && userPreferenceId != Guid.Empty, u => u.UserPreferences
                .Where(p => p.Id == userPreferenceId)
                .Where(p => p.TargetType == targetType)
            )
            .AsSplitQuery()
            .FirstOrDefaultAsync();
    }
}