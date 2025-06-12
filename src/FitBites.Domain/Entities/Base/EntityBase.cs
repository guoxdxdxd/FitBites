using System;

namespace FitBites.Domain.Entities.Base
{
    /// <summary>
    /// 实体基类
    /// </summary>
    public abstract class EntityBase
    {
        /// <summary>
        /// 主键ID
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// 更新时间
        /// </summary>
        public DateTime UpdatedAt { get; set; }
    }
}