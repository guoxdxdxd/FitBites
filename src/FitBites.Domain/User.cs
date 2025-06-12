using System;
using FitBites.Domain.Events;

namespace FitBites.Domain
{
    /// <summary>
    /// 用户实体
    /// </summary>
    public class User : BaseEntity
    {
        /// <summary>
        /// 用户名
        /// </summary>
        public string Username { get; private set; }
        
        /// <summary>
        /// 密码哈希
        /// </summary>
        public string PasswordHash { get; private set; }
        
        /// <summary>
        /// 手机号码
        /// </summary>
        public string Phone { get; private set; }
        
        /// <summary>
        /// 邮箱
        /// </summary>
        public string Email { get; private set; }
        
        /// <summary>
        /// 最后登录时间
        /// </summary>
        public DateTime? LastLoginTime { get; private set; }
        
        /// <summary>
        /// 是否激活
        /// </summary>
        public bool IsActive { get; private set; }
        
        /// <summary>
        /// 创建用户（工厂方法）
        /// </summary>
        /// <param name="username">用户名</param>
        /// <param name="passwordHash">密码哈希</param>
        /// <param name="phone">手机号码</param>
        /// <param name="email">邮箱</param>
        /// <returns>用户实体</returns>
        public static User Create(string username, string passwordHash, string phone, string email)
        {
            var user = new User
            {
                Username = username,
                PasswordHash = passwordHash,
                Phone = phone,
                Email = email,
                IsActive = true
            };
            
            // 添加领域事件
            user.AddDomainEvent(new UserCreatedEvent(user.Id, user.Username, user.Phone));
            
            return user;
        }
        
        /// <summary>
        /// 用户登录
        /// </summary>
        /// <returns>是否成功</returns>
        public bool Login()
        {
            if (!IsActive)
                return false;
            
            LastLoginTime = DateTime.UtcNow;
            UpdatedAt = DateTime.UtcNow;
            
            // 添加领域事件
            AddDomainEvent(new UserLoggedInEvent(Id, Username));
            
            return true;
        }
        
        /// <summary>
        /// 更新用户信息
        /// </summary>
        /// <param name="phone">手机号码</param>
        /// <param name="email">邮箱</param>
        public void UpdateInfo(string phone, string email)
        {
            Phone = phone;
            Email = email;
            UpdatedAt = DateTime.UtcNow;
        }
        
        /// <summary>
        /// 更改密码
        /// </summary>
        /// <param name="newPasswordHash">新密码哈希</param>
        public void ChangePassword(string newPasswordHash)
        {
            PasswordHash = newPasswordHash;
            UpdatedAt = DateTime.UtcNow;
        }
        
        /// <summary>
        /// 激活用户
        /// </summary>
        public void Activate()
        {
            IsActive = true;
            UpdatedAt = DateTime.UtcNow;
        }
        
        /// <summary>
        /// 停用用户
        /// </summary>
        public void Deactivate()
        {
            IsActive = false;
            UpdatedAt = DateTime.UtcNow;
        }
    }
} 