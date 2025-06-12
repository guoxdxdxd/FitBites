using System.ComponentModel.DataAnnotations;

namespace FitBites.Application.DTOs
{
    /// <summary>
    /// 用户注册DTO
    /// </summary>
    public class UserRegisterDto
    {
        /// <summary>
        /// 用户名
        /// </summary>
        [Required(ErrorMessage = "用户名不能为空")]
        [StringLength(64, MinimumLength = 3, ErrorMessage = "用户名长度必须在3-64个字符之间")]
        public string Username { get; set; }
        
        /// <summary>
        /// 密码
        /// </summary>
        [Required(ErrorMessage = "密码不能为空")]
        [StringLength(64, MinimumLength = 6, ErrorMessage = "密码长度必须在6-64个字符之间")]
        public string Password { get; set; }
        
        /// <summary>
        /// 手机号
        /// </summary>
        [Required(ErrorMessage = "手机号不能为空")]
        [RegularExpression(@"^1[3-9]\d{9}$", ErrorMessage = "请输入有效的手机号码")]
        public string Phone { get; set; }
    }
} 