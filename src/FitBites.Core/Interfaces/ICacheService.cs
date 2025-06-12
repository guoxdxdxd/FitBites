namespace FitBites.Core.Interfaces;

/// <summary>
/// 缓存服务接口，提供对分布式缓存的统一访问
/// 实现了常用的缓存操作，支持字符串、哈希表和计数器等数据类型
/// 设计为领域层的接口，可通过不同的基础设施层实现（如Redis、内存缓存等）
/// </summary>
public interface ICacheService
{
    /// <summary>
    /// 获取缓存中指定键的值
    /// </summary>
    /// <typeparam name="T">返回数据类型，将自动反序列化为此类型</typeparam>
    /// <param name="key">缓存键名，区分大小写</param>
    /// <returns>缓存的值；如果键不存在或已过期，则返回默认值(null)</returns>
    /// <remarks>
    /// 使用示例：var user = await cacheService.GetAsync<UserDto>("user:10001");
    /// </remarks>
    Task<T?> GetAsync<T>(string key);
    
    /// <summary>
    /// 设置缓存键值对，支持过期时间设置
    /// </summary>
    /// <typeparam name="T">数据类型，将自动序列化此类型</typeparam>
    /// <param name="key">缓存键名，区分大小写</param>
    /// <param name="value">要缓存的值，将被序列化</param>
    /// <param name="expiry">过期时间(秒)，默认为3600秒(1小时)</param>
    /// <returns>操作是否成功</returns>
    /// <remarks>
    /// 使用示例：await cacheService.SetAsync("user:10001", userDto, 7200); // 缓存2小时
    /// </remarks>
    Task<bool> SetAsync<T>(string key, T value, int expiry = 3600);
    
    /// <summary>
    /// 删除缓存中的指定键
    /// </summary>
    /// <param name="key">要删除的缓存键名</param>
    /// <returns>删除是否成功；如果键不存在则返回false</returns>
    /// <remarks>
    /// 使用示例：await cacheService.RemoveAsync("user:10001");
    /// </remarks>
    Task<bool> RemoveAsync(string key);
    
    /// <summary>
    /// 判断缓存中是否存在指定键
    /// </summary>
    /// <param name="key">要检查的缓存键名</param>
    /// <returns>如果键存在且未过期则返回true，否则返回false</returns>
    /// <remarks>
    /// 使用示例：if (await cacheService.ExistsAsync("user:10001")) { ... }
    /// </remarks>
    Task<bool> ExistsAsync(string key);
    
    /// <summary>
    /// 获取哈希表中指定字段的值
    /// 哈希表类似字典，可存储多个字段-值对
    /// </summary>
    /// <typeparam name="T">返回数据类型，将自动反序列化为此类型</typeparam>
    /// <param name="key">哈希表的键名</param>
    /// <param name="field">哈希表中的字段名</param>
    /// <returns>字段的值；如果键或字段不存在则返回默认值(null)</returns>
    /// <remarks>
    /// 使用示例：var address = await cacheService.HashGetAsync<AddressDto>("user:10001:profile", "address");
    /// </remarks>
    Task<T?> HashGetAsync<T>(string key, string field);
    
    /// <summary>
    /// 设置哈希表中指定字段的值
    /// </summary>
    /// <typeparam name="T">数据类型，将自动序列化此类型</typeparam>
    /// <param name="key">哈希表的键名</param>
    /// <param name="field">哈希表中的字段名</param>
    /// <param name="value">要设置的值，将被序列化</param>
    /// <returns>操作是否成功；如果字段已存在，则更新其值</returns>
    /// <remarks>
    /// 使用示例：await cacheService.HashSetAsync("user:10001:profile", "address", addressDto);
    /// </remarks>
    Task<bool> HashSetAsync<T>(string key, string field, T value);
    
    /// <summary>
    /// 删除哈希表中的指定字段
    /// </summary>
    /// <param name="key">哈希表的键名</param>
    /// <param name="field">要删除的字段名</param>
    /// <returns>删除是否成功；如果字段不存在则返回false</returns>
    /// <remarks>
    /// 使用示例：await cacheService.HashDeleteAsync("user:10001:profile", "address");
    /// </remarks>
    Task<bool> HashDeleteAsync(string key, string field);
    
    /// <summary>
    /// 递增指定键的数值
    /// 用于计数器、限流等场景
    /// </summary>
    /// <param name="key">要递增的键名</param>
    /// <param name="value">递增的值，默认为1</param>
    /// <returns>递增后的值；如果键不存在则创建并设置为递增值</returns>
    /// <remarks>
    /// 使用示例：
    /// 1. 访问计数：var count = await cacheService.IncrementAsync("page:home:visits");
    /// 2. 限流计数：var attempts = await cacheService.IncrementAsync("rate:limit:user:10001", 1);
    /// </remarks>
    Task<long> IncrementAsync(string key, long value = 1);
} 