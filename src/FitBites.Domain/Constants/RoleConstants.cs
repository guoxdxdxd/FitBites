using System;

namespace FitBites.Domain.Constants
{
    /// <summary>
    /// 角色相关常量
    /// </summary>
    public static class RoleConstants
    {
        /// <summary>
        /// 普通用户角色ID
        /// </summary>
        public static readonly Guid USER_ROLE_ID = Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66d002");
        
        /// <summary>
        /// 普通用户角色代码
        /// </summary>
        public const string USER_ROLE_CODE = "USER";
        
        /// <summary>
        /// 普通用户角色名称
        /// </summary>
        public const string USER_ROLE_NAME = "普通用户";
    }
} 