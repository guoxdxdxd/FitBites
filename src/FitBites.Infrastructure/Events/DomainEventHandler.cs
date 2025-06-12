using System;
using System.Threading.Tasks;
using FitBites.Domain.Events;
using Microsoft.Extensions.Logging;

namespace FitBites.Infrastructure.Events
{
    /// <summary>
    /// 领域事件处理器基类
    /// </summary>
    /// <typeparam name="TEvent">事件类型</typeparam>
    public abstract class DomainEventHandler<TEvent> : IDomainEventHandler<TEvent> where TEvent : DomainEvent
    {
        protected readonly ILogger<DomainEventHandler<TEvent>> Logger;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="logger">日志记录器</param>
        protected DomainEventHandler(ILogger<DomainEventHandler<TEvent>> logger)
        {
            Logger = logger;
        }

        /// <summary>
        /// 处理领域事件
        /// </summary>
        /// <param name="event">领域事件</param>
        /// <returns>任务</returns>
        public async Task HandleAsync(TEvent @event)
        {
            try
            {
                Logger.LogInformation("处理领域事件: {EventType}, ID: {EventId}", @event.EventType, @event.Id);
                await ProcessEventAsync(@event);
                Logger.LogInformation("领域事件处理完成: {EventType}, ID: {EventId}", @event.EventType, @event.Id);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "处理领域事件 {EventType} 失败", @event.EventType);
                throw;
            }
        }

        /// <summary>
        /// 处理具体事件的逻辑
        /// </summary>
        /// <param name="event">领域事件</param>
        /// <returns>任务</returns>
        protected abstract Task ProcessEventAsync(TEvent @event);
    }
} 