using System;
using FitBites.Domain.Entities.Base;

namespace FitBites.Domain.Entities
{
    /// <summary>
    /// 餐次字典实体
    /// </summary>
    public class MealTimeDict : EntityBase
    {
        /// <summary>
        /// 默认构造函数
        /// </summary>
        public MealTimeDict()
        {
        }

        /// <summary>
        /// 种子数据构造函数
        /// </summary>
        /// <param name="id">ID</param>
        /// <param name="code">餐次编码</param>
        /// <param name="name">餐次名称</param>
        /// <param name="description">餐次说明</param>
        /// <param name="createdAt">创建时间</param>
        /// <param name="updatedAt">更新时间</param>
        public MealTimeDict(Guid id, string code, string name, string description, DateTime createdAt, DateTime updatedAt)
        {
            Id = id;
            Code = code;
            Name = name;
            Description = description;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
        }

        /// <summary>
        /// 餐次编码（如 BREAKFAST）
        /// </summary>
        public string Code { get; private set; }

        /// <summary>
        /// 餐次名称（如 早餐）
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// 餐次说明
        /// </summary>
        public string Description { get; private set; }
    }
} 