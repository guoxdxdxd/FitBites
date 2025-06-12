using System;
using System.Collections.Generic;

namespace FitBites.Application.DTOs
{
    /// <summary>
    /// 从Token中解析的用户信息DTO
    /// </summary>
    public class UserTokenInfoDto
    {
        /// <summary>
        /// 用户ID
        /// </summary>
        public Guid UserId { get; set; }
        
        /// <summary>
        /// 用户名
        /// </summary>
        public string Username { get; set; }
        
        /// <summary>
        /// 用户编码
        /// </summary>
        public string UserCode { get; set; }
        
        /// <summary>
        /// 手机号
        /// </summary>
        public string Phone { get; set; }
        
        /// <summary>
        /// 用户角色列表
        /// </summary>
        public List<string> Roles { get; set; } = new List<string>();
        
        /// <summary>
        /// 用户权限列表
        /// </summary>
        public List<string> Permissions { get; set; } = new List<string>();
    }
} 