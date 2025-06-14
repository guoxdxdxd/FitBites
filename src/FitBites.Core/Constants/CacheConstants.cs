namespace FitBites.Core.Constants
{
    /// <summary>
    /// 缓存常量
    /// </summary>
    public static class CacheConstants
    {
        /// <summary>
        /// 偏好缓存键前缀
        /// </summary>
        public const string PREFERENCE_CACHE_KEY_PREFIX = "preference:";
        
        /// <summary>
        /// 偏好缓存过期时间（1天，单位秒）
        /// </summary>
        public const int PREFERENCE_CACHE_EXPIRY = 86400;
        
        /// <summary>
        /// 人群标签缓存键前缀
        /// </summary>
        public const string HUMAN_GROUP_DICT_CACHE_KEY_PREFIX = "humangroup:";
        
        /// <summary>
        /// 人群标签缓存过期时间（1天，单位秒）
        /// </summary>
        public const int HUMAN_GROUP_DICT_CACHE_EXPIRY = 86400;
        
        /// <summary>
        /// 获取偏好缓存键
        /// </summary>
        /// <param name="typeName">偏好类型名称</param>
        /// <returns>完整缓存键</returns>
        public static string GetPreferenceCacheKey(string typeName)
        {
            return $"{PREFERENCE_CACHE_KEY_PREFIX}{typeName}:all";
        }
        
        /// <summary>
        /// 获取人群标签缓存键
        /// </summary>
        /// <returns>完整缓存键</returns>
        public static string GetHumanGroupDictCacheKey()
        {
            return $"{HUMAN_GROUP_DICT_CACHE_KEY_PREFIX}all";
        }
    }
} 