using FitBites.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using StackExchange.Redis;

namespace FitBites.API.Controllers;

/// <summary>
/// 健康检查控制器
/// 提供系统各组件健康状态检查的API端点
/// 用于监控和诊断系统运行状况
/// </summary>
/// <remarks>
/// 健康检查API通常由监控系统或运维人员使用
/// 不需要身份验证即可访问，方便系统状态监控
/// 可通过此API检查应用及其依赖服务（如Redis、数据库）的连接状态
/// </remarks>
[ApiController]
[Route("api/[controller]")]
public class HealthCheckController : ControllerBase
{
    private readonly IConnectionMultiplexer _redis;
    private readonly ICacheService _cacheService;
    private readonly ILogger<HealthCheckController> _logger;

    /// <summary>
    /// 构造函数
    /// </summary>
    /// <param name="redis">Redis连接多路复用器，用于检查Redis连接状态</param>
    /// <param name="cacheService">缓存服务，用于测试Redis读写功能</param>
    /// <param name="logger">日志记录器，用于记录健康检查过程中的异常</param>
    /// <remarks>
    /// 使用依赖注入获取Redis连接和缓存服务实例
    /// 如果Redis服务未配置或不可用，启动时会自动跳过注入相关服务
    /// </remarks>
    public HealthCheckController(
        IConnectionMultiplexer redis,
        ICacheService cacheService,
        ILogger<HealthCheckController> logger)
    {
        _redis = redis ?? throw new ArgumentNullException(nameof(redis), "Redis连接不能为空");
        _cacheService = cacheService ?? throw new ArgumentNullException(nameof(cacheService), "缓存服务不能为空");
        _logger = logger ?? throw new ArgumentNullException(nameof(logger), "日志记录器不能为空");
    }

    /// <summary>
    /// 获取API健康状态
    /// </summary>
    /// <returns>健康状态信息，包含状态描述和时间戳</returns>
    /// <remarks>
    /// 此端点用于基本的API可用性检查
    /// 只要API服务运行正常，即返回200 OK状态码
    /// 可用于负载均衡器的健康探测或基本监控
    /// </remarks>
    /// <response code="200">API服务运行正常</response>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public IActionResult Get()
    {
        _logger.LogInformation("健康检查API被访问: {Time}", DateTime.Now);
        return Ok(new { Status = "API服务运行正常", Timestamp = DateTime.Now });
    }

    /// <summary>
    /// 检查Redis连接状态
    /// </summary>
    /// <returns>Redis连接详细状态，包含连接状态、读写测试结果、服务端点和时间戳</returns>
    /// <remarks>
    /// 此端点检查Redis服务的连接状态和读写功能
    /// 执行以下检查：
    /// 1. 连接状态检查 - 验证与Redis服务器的连接是否正常
    /// 2. 读写测试 - 写入测试数据并读取验证，确认Redis存储功能正常
    /// 3. 服务端点信息 - 返回当前连接的Redis服务器端点信息
    /// 
    /// 用于诊断Redis缓存问题或监控Redis可用性
    /// </remarks>
    /// <response code="200">成功执行Redis检查，返回检查结果</response>
    /// <response code="500">Redis检查过程中发生错误</response>
    [HttpGet("redis")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> CheckRedis()
    {
        try
        {
            _logger.LogInformation("Redis健康检查开始: {Time}", DateTime.Now);
            
            // 检查Redis连接状态
            var isConnected = _redis.IsConnected;
            _logger.LogDebug("Redis连接状态: {Status}", isConnected ? "已连接" : "未连接");
            
            // 尝试写入和读取一个测试键
            var testKey = "health:check:" + Guid.NewGuid();
            var testValue = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
            
            _logger.LogDebug("Redis读写测试开始，测试键: {Key}", testKey);
            
            // 写入测试数据，60秒过期
            await _cacheService.SetAsync(testKey, testValue, 60);
            
            // 读取测试数据
            var readValue = await _cacheService.GetAsync<string>(testKey);
            
            // 清理测试键
            await _cacheService.RemoveAsync(testKey);
            _logger.LogDebug("Redis测试键已清理: {Key}", testKey);
            
            // 检查读写测试结果
            var readWriteSuccess = testValue == readValue;
            _logger.LogDebug("Redis读写测试结果: {Result}", readWriteSuccess ? "成功" : "失败");
            
            // 获取Redis端点信息
            var endpoints = _redis.GetEndPoints()
                .Select(e => e.ToString())
                .ToList();
                
            _logger.LogDebug("Redis服务端点: {Endpoints}", string.Join(", ", endpoints));
            
            // 构建返回结果
            var result = new
            { 
                IsConnected = isConnected,
                ReadWriteTest = readWriteSuccess ? "成功" : "失败",
                Endpoints = string.Join(", ", endpoints),
                Timestamp = DateTime.Now
            };
            
            _logger.LogInformation("Redis健康检查完成: {Time}", DateTime.Now);
            return Ok(result);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Redis健康检查失败");
            return StatusCode(500, new 
            { 
                Error = "Redis连接检查失败", 
                Message = ex.Message,
                Timestamp = DateTime.Now
            });
        }
    }
} 