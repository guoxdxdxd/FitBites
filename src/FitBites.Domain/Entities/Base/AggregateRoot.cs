using System;
using System.Collections.Generic;
using FitBites.Domain.Events;

namespace FitBites.Domain.Entities.Base
{
    /// <summary>
    /// 聚合根基类
    /// </summary>
    public abstract class AggregateRoot : EntityBase
    {
        private List<DomainEvent> _domainEvents;

        /// <summary>
        /// 领域事件集合
        /// </summary>
        public IReadOnlyCollection<DomainEvent> DomainEvents => _domainEvents?.AsReadOnly();

        /// <summary>
        /// 添加领域事件
        /// </summary>
        /// <param name="domainEvent">领域事件</param>
        protected void AddDomainEvent(DomainEvent domainEvent)
        {
            _domainEvents ??= new List<DomainEvent>();
            _domainEvents.Add(domainEvent);
        }

        /// <summary>
        /// 移除领域事件
        /// </summary>
        /// <param name="domainEvent">领域事件</param>
        protected void RemoveDomainEvent(DomainEvent domainEvent)
        {
            _domainEvents?.Remove(domainEvent);
        }

        /// <summary>
        /// 清空领域事件
        /// </summary>
        public void ClearDomainEvents()
        {
            _domainEvents?.Clear();
        }
    }
} 