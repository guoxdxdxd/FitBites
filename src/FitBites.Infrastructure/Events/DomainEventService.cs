using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FitBites.Core.DependencyInjection;
using FitBites.Domain.Events;

namespace FitBites.Infrastructure.Events
{
    /// <summary>
    /// 领域事件服务
    /// </summary>
    public class DomainEventService : IScopedDependency
    {
        private readonly IDomainEventPublisher _eventPublisher;
        private readonly List<DomainEvent> _events;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="eventPublisher">事件发布器</param>
        public DomainEventService(IDomainEventPublisher eventPublisher)
        {
            _eventPublisher = eventPublisher;
            _events = new List<DomainEvent>();
        }

        /// <summary>
        /// 添加事件
        /// </summary>
        /// <param name="event">领域事件</param>
        public void AddEvent(DomainEvent @event)
        {
            _events.Add(@event);
        }

        /// <summary>
        /// 添加多个事件
        /// </summary>
        /// <param name="events">领域事件集合</param>
        public void AddEvents(IEnumerable<DomainEvent> events)
        {
            _events.AddRange(events);
        }

        /// <summary>
        /// 清空事件
        /// </summary>
        public void ClearEvents()
        {
            _events.Clear();
        }

        /// <summary>
        /// 发布所有收集的事件
        /// </summary>
        /// <returns>任务</returns>
        public async Task PublishEventsAsync()
        {
            var events = _events.ToList();
            
            if (!events.Any())
                return;
            
            foreach (var @event in events)
            {
                await _eventPublisher.PublishAsync(@event);
            }
            
            // 发布完成后清空事件列表
            ClearEvents();
        }
    }
} 