using System.Threading.Tasks;
using FitBites.Core.DependencyInjection;

namespace FitBites.Domain.Events
{
    /// <summary>
    /// 领域事件处理器接口
    /// </summary>
    /// <typeparam name="TEvent">事件类型</typeparam>
    public interface IDomainEventHandler<in TEvent> : IScopedDependency where TEvent : DomainEvent
    {
        /// <summary>
        /// 处理领域事件
        /// </summary>
        /// <param name="event">领域事件</param>
        /// <returns>任务</returns>
        Task HandleAsync(TEvent @event);
    }
} 