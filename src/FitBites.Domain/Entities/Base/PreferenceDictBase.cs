using System;
using System.Collections.Generic;
using FitBites.Core.Enums;
using FitBites.Domain.Entities.Base;
using FitBites.Domain.Events;
using FitBites.Domain.IRepositories;

namespace FitBites.Domain.Entities.Base
{
    /// <summary>
    /// 偏好字典基类
    /// 为所有偏好相关的字典实体提供基础属性和行为
    /// </summary>
    public abstract class PreferenceDictBase : AggregateRoot
    {
        /// <summary>
        /// 默认构造函数
        /// </summary>
        protected PreferenceDictBase()
        {
            Recipes = new HashSet<Recipe>();
        }

        /// <summary>
        /// 种子数据构造函数
        /// </summary>
        /// <param name="id">ID</param>
        /// <param name="code">编码</param>
        /// <param name="name">名称</param>
        /// <param name="description">描述说明</param>
        /// <param name="status">状态</param>
        /// <param name="sortOrder">排序值</param>
        /// <param name="createdAt">创建时间</param>
        /// <param name="updatedAt">更新时间</param>
        protected PreferenceDictBase(Guid id, string code, string name, string description, bool status, int sortOrder, DateTime createdAt, DateTime updatedAt)
        {
            Id = id;
            Code = code;
            Name = name;
            Description = description;
            Status = status;
            SortOrder = sortOrder;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
            Recipes = new HashSet<Recipe>();
        }

        /// <summary>
        /// 编码（唯一）
        /// </summary>
        public string Code { get; protected set; }

        /// <summary>
        /// 名称（展示用）
        /// </summary>
        public string Name { get; protected set; }

        /// <summary>
        /// 描述说明
        /// </summary>
        public string Description { get; protected set; }

        /// <summary>
        /// 状态（启用/禁用）
        /// </summary>
        public bool Status { get; protected set; }

        /// <summary>
        /// 排序值（正序）
        /// </summary>
        public int? SortOrder { get; protected set; }

        /// <summary>
        /// 关联的菜式集合
        /// </summary>
        public virtual ICollection<Recipe> Recipes { get; protected set; }
        
        /// <summary>
        /// 获取当前偏好类型
        /// </summary>
        /// <returns>偏好类型</returns>
        protected abstract PreferenceTargetType GetPreferenceType();
    }
} 