using System;

namespace FitBites.Application.DTOs
{
    /// <summary>
    /// 用户DTO
    /// </summary>
    public class UserDto
    {
        /// <summary>
        /// 用户ID
        /// </summary>
        public Guid Id { get; set; }
        
        /// <summary>
        /// 用户编码
        /// </summary>
        public string UserCode { get; set; }
        
        /// <summary>
        /// 用户名
        /// </summary>
        public string Username { get; set; }
        
        /// <summary>
        /// 手机号
        /// </summary>
        public string Phone { get; set; }
        
        /// <summary>
        /// 昵称
        /// </summary>
        public string Nickname { get; set; }
        
        /// <summary>
        /// 头像URL
        /// </summary>
        public string Avatar { get; set; }
        
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreatedAt { get; set; }
    }
} 