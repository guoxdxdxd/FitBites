using System.Text.Json;
using FitBites.Core.Interfaces;
using Microsoft.Extensions.Logging;
using StackExchange.Redis;

namespace FitBites.Infrastructure.Services;

/// <summary>
/// Redis缓存服务实现
/// 基于StackExchange.Redis实现了ICacheService接口
/// 提供Redis分布式缓存的读写操作，支持对象序列化/反序列化
/// </summary>
/// <remarks>
/// 此服务应当注册为单例（Singleton）生命周期
/// Redis连接使用ConnectionMultiplexer，支持连接池和自动重连
/// 所有异常都会被捕获并记录日志，保证业务层调用安全
/// </remarks>
public class RedisCacheService : ICacheService
{
    private readonly IConnectionMultiplexer _redis;
    private readonly IDatabase _database;
    private readonly ILogger<RedisCacheService> _logger;
    private readonly string _instanceName;

    /// <summary>
    /// 构造函数
    /// </summary>
    /// <param name="redis">Redis连接多路复用器，用于获取数据库连接</param>
    /// <param name="logger">日志记录器，用于记录异常和调试信息</param>
    /// <param name="instanceName">实例名称前缀，用于隔离不同应用的缓存命名空间</param>
    /// <remarks>
    /// instanceName参数可用于多租户或多环境隔离，例如"Prod:"、"Test:"或"Tenant1:"
    /// </remarks>
    public RedisCacheService(IConnectionMultiplexer redis, ILogger<RedisCacheService> logger, string instanceName = "")
    {
        _redis = redis ?? throw new ArgumentNullException(nameof(redis), "Redis连接不能为空");
        _database = redis.GetDatabase();
        _logger = logger ?? throw new ArgumentNullException(nameof(logger), "日志记录器不能为空");
        _instanceName = instanceName ?? string.Empty;
    }

    /// <summary>
    /// 获取完整的键名
    /// 自动添加实例名称前缀，实现缓存隔离
    /// </summary>
    /// <param name="key">原始键名</param>
    /// <returns>带前缀的完整键名</returns>
    /// <remarks>
    /// 如实例名为"FitBites:"，键名为"user:1001"，则返回"FitBites:user:1001"
    /// </remarks>
    private string GetKeyName(string key) => $"{_instanceName}{key}";

    /// <summary>
    /// 从Redis获取缓存值并反序列化为指定类型
    /// </summary>
    /// <typeparam name="T">要反序列化的目标类型</typeparam>
    /// <param name="key">缓存键名</param>
    /// <returns>
    /// 反序列化后的对象；如果键不存在或发生异常，则返回默认值(null)
    /// </returns>
    /// <remarks>
    /// 内部使用System.Text.Json进行反序列化
    /// 所有异常都会被捕获并记录，确保不会因缓存异常影响业务流程
    /// </remarks>
    public async Task<T?> GetAsync<T>(string key)
    {
        try
        {
            if (string.IsNullOrEmpty(key))
            {
                _logger.LogWarning("尝试获取空键的缓存值");
                return default;
            }
            
            var fullKey = GetKeyName(key);
            var value = await _database.StringGetAsync(fullKey);
            
            if (value.IsNullOrEmpty)
            {
                _logger.LogDebug("缓存键 {Key} 不存在或已过期", key);
                return default;
            }
            
            _logger.LogDebug("成功获取缓存键 {Key} 的值", key);
            return JsonSerializer.Deserialize<T>(value!);
        }
        catch (JsonException ex)
        {
            _logger.LogError(ex, "反序列化缓存键 {Key} 的值时出错", key);
            return default;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "从Redis获取键 {Key} 的值时出错", key);
            return default;
        }
    }

    /// <summary>
    /// 将对象序列化并存储到Redis缓存
    /// </summary>
    /// <typeparam name="T">要序列化的对象类型</typeparam>
    /// <param name="key">缓存键名</param>
    /// <param name="value">要缓存的对象</param>
    /// <param name="expiry">过期时间(秒)，默认3600秒(1小时)</param>
    /// <returns>操作是否成功</returns>
    /// <remarks>
    /// 内部使用System.Text.Json进行序列化
    /// 支持设置过期时间，默认为1小时
    /// 所有异常都会被捕获并记录，确保不会因缓存异常影响业务流程
    /// </remarks>
    public async Task<bool> SetAsync<T>(string key, T value, int expiry = 3600)
    {
        try
        {
            if (string.IsNullOrEmpty(key))
            {
                _logger.LogWarning("尝试使用空键设置缓存值");
                return false;
            }
            
            if (value == null)
            {
                _logger.LogWarning("尝试缓存空值，键: {Key}", key);
                return false;
            }
            
            var fullKey = GetKeyName(key);
            var serializedValue = JsonSerializer.Serialize(value);
            
            var result = await _database.StringSetAsync(
                fullKey, 
                serializedValue, 
                expiry > 0 ? TimeSpan.FromSeconds(expiry) : (TimeSpan?)null
            );
            
            if (result)
            {
                _logger.LogDebug("成功设置缓存键 {Key}，过期时间: {Expiry}秒", key, expiry);
            }
            else
            {
                _logger.LogWarning("设置缓存键 {Key} 失败", key);
            }
            
            return result;
        }
        catch (JsonException ex)
        {
            _logger.LogError(ex, "序列化对象到缓存键 {Key} 时出错", key);
            return false;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "向Redis设置键 {Key} 的值时出错", key);
            return false;
        }
    }

    /// <summary>
    /// 从Redis缓存中删除指定键
    /// </summary>
    /// <param name="key">要删除的缓存键名</param>
    /// <returns>
    /// true表示删除成功；false表示键不存在或删除失败
    /// </returns>
    /// <remarks>
    /// 如果键不存在，Redis仍会返回成功
    /// 所有异常都会被捕获并记录，确保不会因缓存异常影响业务流程
    /// </remarks>
    public async Task<bool> RemoveAsync(string key)
    {
        try
        {
            if (string.IsNullOrEmpty(key))
            {
                _logger.LogWarning("尝试删除空键的缓存");
                return false;
            }
            
            var fullKey = GetKeyName(key);
            var result = await _database.KeyDeleteAsync(fullKey);
            
            _logger.LogDebug("删除缓存键 {Key} {Result}", key, result ? "成功" : "失败(键可能不存在)");
            return result;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "从Redis删除键 {Key} 时出错", key);
            return false;
        }
    }

    /// <summary>
    /// 检查Redis缓存中是否存在指定键
    /// </summary>
    /// <param name="key">要检查的缓存键名</param>
    /// <returns>
    /// true表示键存在；false表示键不存在或检查失败
    /// </returns>
    /// <remarks>
    /// 所有异常都会被捕获并记录，确保不会因缓存异常影响业务流程
    /// </remarks>
    public async Task<bool> ExistsAsync(string key)
    {
        try
        {
            if (string.IsNullOrEmpty(key))
            {
                _logger.LogWarning("尝试检查空键是否存在");
                return false;
            }
            
            var fullKey = GetKeyName(key);
            var result = await _database.KeyExistsAsync(fullKey);
            
            _logger.LogDebug("检查缓存键 {Key} {Result}", key, result ? "存在" : "不存在");
            return result;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "检查Redis键 {Key} 是否存在时出错", key);
            return false;
        }
    }

    /// <summary>
    /// 从Redis哈希表中获取指定字段的值并反序列化
    /// </summary>
    /// <typeparam name="T">要反序列化的目标类型</typeparam>
    /// <param name="key">哈希表的键名</param>
    /// <param name="field">哈希表中的字段名</param>
    /// <returns>
    /// 反序列化后的对象；如果键或字段不存在或发生异常，则返回默认值(null)
    /// </returns>
    /// <remarks>
    /// 内部使用System.Text.Json进行反序列化
    /// 所有异常都会被捕获并记录，确保不会因缓存异常影响业务流程
    /// </remarks>
    public async Task<T?> HashGetAsync<T>(string key, string field)
    {
        try
        {
            if (string.IsNullOrEmpty(key) || string.IsNullOrEmpty(field))
            {
                _logger.LogWarning("尝试获取空键或空字段的哈希值");
                return default;
            }
            
            var fullKey = GetKeyName(key);
            var value = await _database.HashGetAsync(fullKey, field);
            
            if (value.IsNullOrEmpty)
            {
                _logger.LogDebug("哈希表 {Key} 的字段 {Field} 不存在", key, field);
                return default;
            }
            
            _logger.LogDebug("成功获取哈希表 {Key} 的字段 {Field} 的值", key, field);
            return JsonSerializer.Deserialize<T>(value!);
        }
        catch (JsonException ex)
        {
            _logger.LogError(ex, "反序列化哈希表 {Key} 的字段 {Field} 的值时出错", key, field);
            return default;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "从Redis获取哈希表 {Key} 的字段 {Field} 的值时出错", key, field);
            return default;
        }
    }

    /// <summary>
    /// 将对象序列化并存储到Redis哈希表的指定字段
    /// </summary>
    /// <typeparam name="T">要序列化的对象类型</typeparam>
    /// <param name="key">哈希表的键名</param>
    /// <param name="field">哈希表中的字段名</param>
    /// <param name="value">要缓存的对象</param>
    /// <returns>
    /// true表示设置成功；false表示设置失败
    /// </returns>
    /// <remarks>
    /// 内部使用System.Text.Json进行序列化
    /// 哈希表不支持直接设置过期时间，如需过期，请对整个哈希表键设置过期
    /// 所有异常都会被捕获并记录，确保不会因缓存异常影响业务流程
    /// </remarks>
    public async Task<bool> HashSetAsync<T>(string key, string field, T value)
    {
        try
        {
            if (string.IsNullOrEmpty(key) || string.IsNullOrEmpty(field))
            {
                _logger.LogWarning("尝试使用空键或空字段设置哈希值");
                return false;
            }
            
            if (value == null)
            {
                _logger.LogWarning("尝试缓存空值到哈希表，键: {Key}，字段: {Field}", key, field);
                return false;
            }
            
            var fullKey = GetKeyName(key);
            var serializedValue = JsonSerializer.Serialize(value);
            var result = await _database.HashSetAsync(fullKey, field, serializedValue);
            
            _logger.LogDebug("设置哈希表 {Key} 的字段 {Field} {Result}", key, field, "成功");
            return true; // HashSet总是返回成功，除非出现异常
        }
        catch (JsonException ex)
        {
            _logger.LogError(ex, "序列化对象到哈希表 {Key} 的字段 {Field} 时出错", key, field);
            return false;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "向Redis设置哈希表 {Key} 的字段 {Field} 的值时出错", key, field);
            return false;
        }
    }

    /// <summary>
    /// 从Redis哈希表中删除指定字段
    /// </summary>
    /// <param name="key">哈希表的键名</param>
    /// <param name="field">要删除的字段名</param>
    /// <returns>
    /// true表示删除成功；false表示字段不存在或删除失败
    /// </returns>
    /// <remarks>
    /// 所有异常都会被捕获并记录，确保不会因缓存异常影响业务流程
    /// </remarks>
    public async Task<bool> HashDeleteAsync(string key, string field)
    {
        try
        {
            if (string.IsNullOrEmpty(key) || string.IsNullOrEmpty(field))
            {
                _logger.LogWarning("尝试删除空键或空字段的哈希值");
                return false;
            }
            
            var fullKey = GetKeyName(key);
            var result = await _database.HashDeleteAsync(fullKey, field);
            
            _logger.LogDebug("删除哈希表 {Key} 的字段 {Field} {Result}", key, field, result ? "成功" : "失败(字段可能不存在)");
            return result;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "从Redis删除哈希表 {Key} 的字段 {Field} 时出错", key, field);
            return false;
        }
    }

    /// <summary>
    /// 递增Redis中指定键的数值
    /// </summary>
    /// <param name="key">要递增的键名</param>
    /// <param name="value">递增的值，默认为1</param>
    /// <returns>
    /// 递增后的值；如果发生异常则返回0
    /// </returns>
    /// <remarks>
    /// 如果键不存在，Redis会先创建键并设为0，再执行递增操作
    /// 适用于计数器、限流等场景
    /// 所有异常都会被捕获并记录，确保不会因缓存异常影响业务流程
    /// </remarks>
    public async Task<long> IncrementAsync(string key, long value = 1)
    {
        try
        {
            if (string.IsNullOrEmpty(key))
            {
                _logger.LogWarning("尝试递增空键的值");
                return 0;
            }
            
            if (value == 0)
            {
                _logger.LogWarning("尝试递增值为0，键: {Key}", key);
                return 0;
            }
            
            var fullKey = GetKeyName(key);
            var result = await _database.StringIncrementAsync(fullKey, value);
            
            _logger.LogDebug("递增键 {Key} 的值 {Value}，结果: {Result}", key, value, result);
            return result;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "在Redis中递增键 {Key} 的值时出错", key);
            return 0;
        }
    }
} 