using System;
using System.Collections.Generic;
using FitBites.Domain.Events;

namespace FitBites.Domain
{
    /// <summary>
    /// 实体基类
    /// </summary>
    public abstract class BaseEntity
    {
        private List<DomainEvent> _domainEvents;
        
        /// <summary>
        /// 实体ID
        /// </summary>
        public Guid Id { get; protected set; }
        
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreatedAt { get; protected set; }
        
        /// <summary>
        /// 更新时间
        /// </summary>
        public DateTime? UpdatedAt { get; protected set; }

        /// <summary>
        /// 构造函数
        /// </summary>
        protected BaseEntity()
        {
            Id = Guid.NewGuid();
            CreatedAt = DateTime.UtcNow;
        }
        
        
        /// <summary>
        /// 判断两个实体是否相等
        /// </summary>
        /// <param name="obj">比较对象</param>
        /// <returns>是否相等</returns>
        public override bool Equals(object obj)
        {
            if (obj is not BaseEntity other)
                return false;
            
            if (ReferenceEquals(this, other))
                return true;
            
            if (GetType() != other.GetType())
                return false;
            
            if (Id == Guid.Empty || other.Id == Guid.Empty)
                return false;
            
            return Id == other.Id;
        }
        
        /// <summary>
        /// 获取哈希码
        /// </summary>
        /// <returns>哈希码</returns>
        public override int GetHashCode()
        {
            return (GetType().ToString() + Id).GetHashCode();
        }
        
        /// <summary>
        /// 实体比较
        /// </summary>
        /// <param name="left">左操作数</param>
        /// <param name="right">右操作数</param>
        /// <returns>是否相等</returns>
        public static bool operator ==(BaseEntity left, BaseEntity right)
        {
            if (left is null && right is null)
                return true;
            
            if (left is null || right is null)
                return false;
            
            return left.Equals(right);
        }
        
        /// <summary>
        /// 实体比较
        /// </summary>
        /// <param name="left">左操作数</param>
        /// <param name="right">右操作数</param>
        /// <returns>是否不等</returns>
        public static bool operator !=(BaseEntity left, BaseEntity right)
        {
            return !(left == right);
        }
    }
} 