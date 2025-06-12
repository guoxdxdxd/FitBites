using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FitBites.Core.DependencyInjection;
using FitBites.Domain.Entities;
using FitBites.Domain.Events;
using FitBites.Domain.IRepositories;

namespace FitBites.Domain.Services
{
    /// <summary>
    /// 用户领域服务接口
    /// </summary>
    public interface IUserDomainService : IScopedDependency
    {
        /// <summary>
        /// 创建新用户
        /// </summary>
        /// <param name="username">用户名</param>
        /// <param name="password">密码</param>
        /// <param name="phone">手机号</param>
        /// <param name="defaultRoleId">默认角色ID</param>
        /// <returns>创建的用户</returns>
        Task<User> CreateUserAsync(string username, string password, string phone, Guid defaultRoleId);
        
        /// <summary>
        /// 验证用户登录
        /// </summary>
        /// <param name="account">账号（用户名或手机号）</param>
        /// <param name="password">密码</param>
        /// <returns>验证成功的用户</returns>
        Task<User> ValidateUserLoginAsync(string account, string password);
        
        /// <summary>
        /// 验证刷新令牌
        /// </summary>
        /// <param name="refreshToken">刷新令牌</param>
        /// <returns>验证成功的用户</returns>
        Task<User> ValidateRefreshTokenAsync(string refreshToken);
        
        /// <summary>
        /// 分配角色给用户
        /// </summary>
        /// <param name="userId">用户ID</param>
        /// <param name="roleId">角色ID</param>
        /// <returns>操作结果</returns>
        Task<bool> AssignRoleToUserAsync(Guid userId, Guid roleId);
        
        /// <summary>
        /// 授予用户直接权限
        /// </summary>
        /// <param name="userId">用户ID</param>
        /// <param name="permissionId">权限ID</param>
        /// <param name="expireTime">过期时间</param>
        /// <returns>操作结果</returns>
        Task<bool> GrantPermissionToUserAsync(Guid userId, Guid permissionId, DateTime? expireTime);
    }
    
    /// <summary>
    /// 用户领域服务实现
    /// </summary>
    public class UserDomainService : IUserDomainService
    {
        private readonly IUserRepository _userRepository;
        private readonly IRoleRepository _roleRepository;
        private readonly IPermissionRepository _permissionRepository;
        private readonly Random _random;
        
        /// <summary>
        /// 构造函数
        /// </summary>
        public UserDomainService(
            IUserRepository userRepository,
            IRoleRepository roleRepository,
            IPermissionRepository permissionRepository)
        {
            _userRepository = userRepository;
            _roleRepository = roleRepository;
            _permissionRepository = permissionRepository;
            _random = new Random();
        }
        
        /// <summary>
        /// 创建新用户
        /// </summary>
        public async Task<User> CreateUserAsync(string username, string password, string phone, Guid defaultRoleId)
        {
            // 验证用户名和手机号唯一性
            if (await _userRepository.ExistsAsync(u => u.Username == username))
            {
                throw new DomainException("用户名已存在");
            }
            
            if (await _userRepository.ExistsAsync(u => u.Phone == phone))
            {
                throw new DomainException("手机号已存在");
            }
            
            // 获取默认角色
            var role = await _roleRepository.GetByIdAsync(defaultRoleId);
            if (role == null)
            {
                throw new DomainException("指定的默认角色不存在");
            }
            
            // 创建用户实体
            var user = new User(username, phone, Core.Enums.UserStatus.Enabled);
            
            // 设置密码
            user.ChangePassword(password);
            
            // 添加默认角色
            user.AddRole(role);
            
            user.Create();

            return user;
        }
        
        /// <summary>
        /// 验证用户登录
        /// </summary>
        public async Task<User> ValidateUserLoginAsync(string account, string password)
        {
            // 获取用户信息
            var user = await _userRepository.GetUserWithPermissionsByAccountAsync(account);
            
            // 验证用户存在且可以登录
            if (user == null || !user.CanLogin())
            {
                throw new DomainException("用户不存在或已被禁用");
            }
            
            // 验证密码
            if (!user.VerifyPassword(password))
            {
                throw new DomainException("密码错误");
            }
            
            user.Login();
            
            return user;
        }
        
        /// <summary>
        /// 验证刷新令牌
        /// </summary>
        public async Task<User> ValidateRefreshTokenAsync(string refreshToken)
        {
            // 获取用户信息
            var user = await _userRepository.GetUserByRefreshTokenAsync(refreshToken);
            
            // 验证用户存在且可以登录
            if (user == null || !user.CanLogin())
            {
                throw new DomainException("无效的刷新令牌或用户已被禁用");
            }
            
            // 验证刷新令牌
            if (!user.ValidateRefreshToken(refreshToken))
            {
                throw new DomainException("刷新令牌已过期或无效");
            }
            
            return user;
        }
        
        /// <summary>
        /// 分配角色给用户
        /// </summary>
        public async Task<bool> AssignRoleToUserAsync(Guid userId, Guid roleId)
        {
            var user = await _userRepository.GetByIdAsync(userId);
            if (user == null)
            {
                throw new DomainException("用户不存在");
            }
            
            var role = await _roleRepository.GetByIdAsync(roleId);
            if (role == null)
            {
                throw new DomainException("角色不存在");
            }
            
            // 添加角色
            user.AddRole(role);
            
            return true;
        }
        
        /// <summary>
        /// 授予用户直接权限
        /// </summary>
        public async Task<bool> GrantPermissionToUserAsync(Guid userId, Guid permissionId, DateTime? expireTime)
        {
            var user = await _userRepository.GetByIdAsync(userId);
            if (user == null)
            {
                throw new DomainException("用户不存在");
            }
            
            var permission = await _permissionRepository.GetByIdAsync(permissionId);
            if (permission == null)
            {
                throw new DomainException("权限不存在");
            }
            
            // 创建权限映射
            var permissionMapping = new PermissionMapping(Core.Enums.ObjectType.User, userId, permissionId, true, expireTime);
            
            // 添加到用户的权限映射集合
            user.PermissionMappings.Add(permissionMapping);
            
            return true;
        }
        
        /// <summary>
        /// 生成随机用户编码
        /// </summary>
        /// <returns>用户编码</returns>
        private string GenerateUserCode()
        {
            return $"U{DateTime.Now:yyyyMMdd}{_random.Next(1000, 9999)}";
        }
        
        /// <summary>
        /// 生成随机昵称
        /// </summary>
        /// <returns>随机昵称</returns>
        private string GenerateRandomNickname()
        {
            string[] prefixes = { "快乐的", "开心的", "阳光的", "健康的", "活力的", "美味的", "营养的" };
            string[] nouns = { "厨师", "美食家", "营养师", "吃货", "厨神", "美食达人", "健身达人" };
            
            var prefix = prefixes[_random.Next(prefixes.Length)];
            var noun = nouns[_random.Next(nouns.Length)];
            
            return $"{prefix}{noun}{_random.Next(10, 100)}";
        }
    }
} 