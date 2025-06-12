using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FitBites.Domain.Events;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace FitBites.Infrastructure.Events
{
    /// <summary>
    /// 领域事件发布器实现
    /// </summary>
    public class DomainEventPublisher : IDomainEventPublisher
    {
        private readonly ILogger<DomainEventPublisher> _logger;
        private readonly IServiceProvider _serviceProvider;
        
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="logger">日志记录器</param>
        /// <param name="serviceProvider">服务提供器</param>
        public DomainEventPublisher(ILogger<DomainEventPublisher> logger, IServiceProvider serviceProvider)
        {
            _logger = logger;
            _serviceProvider = serviceProvider;
        }
        
        /// <summary>
        /// 发布领域事件
        /// </summary>
        /// <param name="event">领域事件</param>
        /// <returns>任务</returns>
        public async Task PublishAsync(DomainEvent @event)
        {
            _logger.LogInformation("发布领域事件: {EventType}, ID: {EventId}", @event.EventType, @event.Id);
            
            // 在实际项目中，这里可以将事件存储到事件存储中，或者发送到消息队列
            // 例如使用MediatR、RabbitMQ、Kafka等
            
            // 简单实现，通过反射查找并调用事件处理器
            var eventType = @event.GetType();
            var handlerType = typeof(IDomainEventHandler<>).MakeGenericType(eventType);
            
            try
            {
                // 获取所有处理此事件的处理器
                var handlers = _serviceProvider.GetService(typeof(IEnumerable<>).MakeGenericType(handlerType));
                
                if (handlers != null)
                {
                    foreach (var handler in (System.Collections.IEnumerable)handlers)
                    {
                        // 调用处理器的Handle方法
                        var method = handlerType.GetMethod("HandleAsync");
                        if (method != null)
                        {
                            await (Task)method.Invoke(handler, new object[] { @event });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "处理领域事件 {EventType} 失败", @event.EventType);
                throw;
            }
        }
    }
} 