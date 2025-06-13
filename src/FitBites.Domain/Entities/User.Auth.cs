using System;
using FitBites.Domain.Events;

namespace FitBites.Domain.Entities
{
    /// <summary>
    /// 用户聚合根 - 认证相关方法
    /// </summary>
    public partial class User
    {
        /// <summary>
        /// 验证密码是否正确
        /// </summary>
        /// <param name="password">原始密码</param>
        /// <returns>验证结果</returns>
        public bool VerifyPassword(string password)
        {
            return Password == EncryptPassword(password);
        }

        public void Login()
        {
            AddDomainEvent(new UserLoggedInEvent(Id, Username));
        }

        /// <summary>
        /// 更改密码
        /// </summary>
        /// <param name="newPassword">新密码</param>
        public void ChangePassword(string newPassword)
        {
            Password = EncryptPassword(newPassword);
            UpdatedAt = DateTime.Now;
        }
        
        /// <summary>
        /// 生成新的刷新令牌
        /// </summary>
        /// <param name="expireTime">过期时间</param>
        public void GenerateRefreshToken(DateTime expireTime)
        {
            RefreshToken = Guid.NewGuid().ToString("N") + Guid.NewGuid().ToString("N");
            RefreshTokenExpireTime = expireTime;
            UpdatedAt = DateTime.Now;
            
            AddDomainEvent(new UserRefreshTokenGeneratedEvent(Id, RefreshToken, RefreshTokenExpireTime));
        }
        
        /// <summary>
        /// 验证刷新令牌是否有效
        /// </summary>
        /// <param name="refreshToken">刷新令牌</param>
        /// <returns>是否有效</returns>
        public bool ValidateRefreshToken(string refreshToken)
        {
            return RefreshToken == refreshToken && 
                   RefreshTokenExpireTime.HasValue && 
                   RefreshTokenExpireTime.Value > DateTime.UtcNow;
        }
        
        /// <summary>
        /// 撤销刷新令牌
        /// </summary>
        public void RevokeRefreshToken()
        {
            RefreshToken = null;
            RefreshTokenExpireTime = null;
            UpdatedAt = DateTime.Now;
        }
    }
} 