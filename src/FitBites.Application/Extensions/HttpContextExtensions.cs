using System.Security.Claims;
using FitBites.Application.DTOs;
using FitBites.Application.Services;
using FitBites.Application.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;

namespace FitBites.Application.Extensions
{
    /// <summary>
    /// HttpContext扩展方法
    /// </summary>
    public static class HttpContextExtensions
    {
        /// <summary>
        /// 从HttpContext中获取当前用户信息
        /// </summary>
        /// <param name="httpContext">Http上下文</param>
        /// <param name="userService">用户服务</param>
        /// <returns>用户信息</returns>
        public static UserTokenInfoDto? GetCurrentUser(this HttpContext httpContext, IUserService userService)
        {
            if (httpContext.User == null)
            {
                return null;
            }
            
            try
            {
                // 解析令牌获取用户信息
                return userService.ParseUserFromToken(httpContext.User);
            }
            catch (Exception)
            {
                // 令牌解析失败返回null
                return null;
            }
        }

        /// <summary>
        /// 从HttpContext中获取当前用户ID
        /// </summary>
        /// <param name="httpContext">Http上下文</param>
        /// <returns>用户ID</returns>
        public static Guid? GetCurrentUserId(this HttpContext httpContext)
        {
            var userIdClaim = httpContext.User?.FindFirst(ClaimTypes.NameIdentifier) ??
                              httpContext.User?.FindFirst("sub");

            if (userIdClaim != null && Guid.TryParse(userIdClaim.Value, out var userId))
            {
                return userId;
            }

            return null;
        }

        /// <summary>
        /// 检查当前用户是否有指定权限
        /// </summary>
        /// <param name="httpContext">Http上下文</param>
        /// <param name="permissionCode">权限代码</param>
        /// <returns>是否有权限</returns>
        public static bool HasPermission(this HttpContext httpContext, string permissionCode)
        {
            return httpContext.User?.HasClaim("permission", permissionCode) ?? false;
        }

        /// <summary>
        /// 检查当前用户是否有指定角色
        /// </summary>
        /// <param name="httpContext">Http上下文</param>
        /// <param name="roleCode">角色代码</param>
        /// <returns>是否有角色</returns>
        public static bool HasRole(this HttpContext httpContext, string roleCode)
        {
            return httpContext.User?.IsInRole(roleCode) ?? false;
        }
    }
}