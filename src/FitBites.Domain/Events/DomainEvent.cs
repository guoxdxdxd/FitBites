using System;

namespace FitBites.Domain.Events
{
    /// <summary>
    /// 领域事件基类
    /// </summary>
    public abstract class DomainEvent
    {
        /// <summary>
        /// 事件ID
        /// </summary>
        public Guid Id { get; }
        
        /// <summary>
        /// 事件发生时间
        /// </summary>
        public DateTime OccurredOn { get; }
        
        /// <summary>
        /// 事件类型名称
        /// </summary>
        public string EventType => GetType().Name;
        
        /// <summary>
        /// 构造函数
        /// </summary>
        protected DomainEvent()
        {
            Id = Guid.NewGuid();
            OccurredOn = DateTime.UtcNow;
        }
    }
    
    /// <summary>
    /// 用户创建事件
    /// </summary>
    public class UserCreatedEvent : DomainEvent
    {
        /// <summary>
        /// 用户ID
        /// </summary>
        public Guid UserId { get; }
        
        /// <summary>
        /// 用户名
        /// </summary>
        public string Username { get; }
        
        /// <summary>
        /// 手机号
        /// </summary>
        public string Phone { get; }
        
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="userId">用户ID</param>
        /// <param name="username">用户名</param>
        /// <param name="phone">手机号</param>
        public UserCreatedEvent(Guid userId, string username, string phone)
        {
            UserId = userId;
            Username = username;
            Phone = phone;
        }
    }
    
    /// <summary>
    /// 用户登录事件
    /// </summary>
    public class UserLoggedInEvent : DomainEvent
    {
        /// <summary>
        /// 用户ID
        /// </summary>
        public Guid UserId { get; }
        
        /// <summary>
        /// 用户名
        /// </summary>
        public string Username { get; }
        
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="userId">用户ID</param>
        /// <param name="username">用户名</param>
        public UserLoggedInEvent(Guid userId, string username)
        {
            UserId = userId;
            Username = username;
        }
    }
    
    /// <summary>
    /// 用户角色分配事件
    /// </summary>
    public class UserRoleAssignedEvent : DomainEvent
    {
        /// <summary>
        /// 用户ID
        /// </summary>
        public Guid UserId { get; }
        
        /// <summary>
        /// 角色ID
        /// </summary>
        public Guid RoleId { get; }
        
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="userId">用户ID</param>
        /// <param name="roleId">角色ID</param>
        public UserRoleAssignedEvent(Guid userId, Guid roleId)
        {
            UserId = userId;
            RoleId = roleId;
        }
    }
    
    /// <summary>
    /// 用户权限授予事件
    /// </summary>
    public class UserPermissionGrantedEvent : DomainEvent
    {
        /// <summary>
        /// 用户ID
        /// </summary>
        public Guid UserId { get; }
        
        /// <summary>
        /// 权限ID
        /// </summary>
        public Guid PermissionId { get; }
        
        /// <summary>
        /// 过期时间
        /// </summary>
        public DateTime? ExpireTime { get; }
        
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="userId">用户ID</param>
        /// <param name="permissionId">权限ID</param>
        /// <param name="expireTime">过期时间</param>
        public UserPermissionGrantedEvent(Guid userId, Guid permissionId, DateTime? expireTime)
        {
            UserId = userId;
            PermissionId = permissionId;
            ExpireTime = expireTime;
        }
    }
    
    /// <summary>
    /// 用户刷新令牌生成事件
    /// </summary>
    public class UserRefreshTokenGeneratedEvent : DomainEvent
    {
        /// <summary>
        /// 用户ID
        /// </summary>
        public Guid UserId { get; }
        
        /// <summary>
        /// 刷新令牌
        /// </summary>
        public string RefreshToken { get; }
        
        /// <summary>
        /// 过期时间
        /// </summary>
        public DateTime? ExpireTime { get; }
        
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="userId">用户ID</param>
        /// <param name="refreshToken">刷新令牌</param>
        /// <param name="expireTime">过期时间</param>
        public UserRefreshTokenGeneratedEvent(Guid userId, string refreshToken, DateTime? expireTime)
        {
            UserId = userId;
            RefreshToken = refreshToken;
            ExpireTime = expireTime;
        }
    }
} 