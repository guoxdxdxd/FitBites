using System.Threading.Tasks;
using FitBites.Core.DependencyInjection;

namespace FitBites.Domain.Events
{
    /// <summary>
    /// 领域事件发布器接口
    /// </summary>
    public interface IDomainEventPublisher : IScopedDependency
    {
        /// <summary>
        /// 发布领域事件
        /// </summary>
        /// <param name="event">领域事件</param>
        /// <returns>任务</returns>
        Task PublishAsync(DomainEvent @event);
    }
} 