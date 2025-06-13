using System;
using System.Threading;
using System.Threading.Tasks;
using FitBites.Application.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace FitBites.API.Services;

/// <summary>
/// 偏好缓存初始化服务
/// 在应用启动时自动初始化Redis中的偏好数据缓存
/// </summary>
public class PreferenceCacheInitializer : BackgroundService
{
    private readonly IServiceProvider _serviceProvider;
    private readonly ILogger<PreferenceCacheInitializer> _logger;

    /// <summary>
    /// 构造函数
    /// </summary>
    /// <param name="serviceProvider">服务提供者</param>
    /// <param name="logger">日志记录器</param>
    public PreferenceCacheInitializer(
        IServiceProvider serviceProvider,
        ILogger<PreferenceCacheInitializer> logger)
    {
        _serviceProvider = serviceProvider;
        _logger = logger;
    }

    /// <summary>
    /// 执行后台任务
    /// </summary>
    /// <param name="stoppingToken">取消令牌</param>
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        _logger.LogInformation("偏好缓存初始化服务已启动");
        
        // 延迟几秒再启动，等待其他服务就绪
        await Task.Delay(TimeSpan.FromSeconds(5), stoppingToken);
        
        try
        {
            // 使用作用域服务
            using var scope = _serviceProvider.CreateScope();
            var preferenceService = scope.ServiceProvider.GetRequiredService<IPreferenceService>();
            
            _logger.LogInformation("开始初始化偏好缓存...");
            await preferenceService.RefreshPreferenceCacheAsync();
            _logger.LogInformation("偏好缓存初始化完成");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "偏好缓存初始化失败");
        }
    }
} 