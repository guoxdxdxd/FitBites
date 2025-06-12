using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using FitBites.Core.DependencyInjection;
using FitBites.Core.Enums;
using FitBites.Domain.Entities;

namespace FitBites.Domain.IRepositories;

/// <summary>
/// 用户仓储接口
/// </summary>
public interface IUserRepository : ISingletonDependency
{
    /// <summary>
    /// 根据ID获取用户
    /// </summary>
    /// <param name="id">用户ID</param>
    /// <returns>用户实体</returns>
    Task<User?> GetByIdAsync(Guid id);
    
    /// <summary>
    /// 根据用户名获取用户
    /// </summary>
    /// <param name="username">用户名</param>
    /// <returns>用户实体</returns>
    Task<User?> GetByUsernameAsync(string username);
    
    /// <summary>
    /// 根据手机号获取用户
    /// </summary>
    /// <param name="phone">手机号</param>
    /// <returns>用户实体</returns>
    Task<User?> GetByPhoneAsync(string phone);
    
    /// <summary>
    /// 根据账号（用户名或手机号）获取用户及其权限
    /// </summary>
    /// <param name="account">账号</param>
    /// <returns>用户实体</returns>
    Task<User> GetUserWithPermissionsByAccountAsync(string account);
    
    /// <summary>
    /// 根据刷新令牌获取用户及其权限
    /// </summary>
    /// <param name="refreshToken">刷新令牌</param>
    /// <returns>用户实体</returns>
    Task<User> GetUserByRefreshTokenAsync(string refreshToken);
    
    /// <summary>
    /// 判断条件是否存在
    /// </summary>
    /// <param name="predicate">条件表达式</param>
    /// <returns>是否存在</returns>
    Task<bool> ExistsAsync(Expression<Func<User, bool>> predicate);
    
    /// <summary>
    /// 添加用户
    /// </summary>
    /// <param name="user">用户实体</param>
    /// <returns>添加的用户</returns>
    Task<User> AddAsync(User user);
    
    /// <summary>
    /// 更新用户
    /// </summary>
    /// <param name="user">用户实体</param>
    /// <returns>更新的用户</returns>
    Task<User> UpdateAsync(User user);
    
    /// <summary>
    /// 获取家庭中的所有用户
    /// </summary>
    /// <param name="familyId">家庭ID</param>
    /// <returns>用户列表</returns>
    Task<IEnumerable<User>> GetUsersByFamilyIdAsync(Guid familyId);
    
    /// <summary>
    /// 根据角色获取用户
    /// </summary>
    /// <param name="roleCode">角色代码</param>
    /// <returns>用户列表</returns>
    Task<IEnumerable<User>> GetUsersByRoleCodeAsync(string roleCode);
    
    /// <summary>
    /// 获取特定人群标签的用户
    /// </summary>
    /// <param name="humanGroupId">人群标签ID</param>
    /// <returns>用户列表</returns>
    Task<IEnumerable<User>> GetUsersByHumanGroupIdAsync(Guid humanGroupId);

    /// <summary>
    /// 获取用户信息（包括用户偏好）
    /// </summary>
    /// <param name="id">用户ID</param>
    /// <param name="targetType">用户偏好类型</param>
    /// <param name="userPreferenceId">用户偏好ID，如果不为默认值，则只查询指定的偏好</param>
    /// <returns>用户信息</returns>
    Task<User?> GetWithPreferencesByIdAsync(Guid id
        , PreferenceTargetType? targetType = null
        , Guid userPreferenceId = default);
}