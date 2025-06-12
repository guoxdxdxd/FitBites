using System;
using System.Collections.Generic;
using FitBites.Core.Enums;
using FitBites.Domain.Entities.Base;
using FitBites.Domain.Events;

namespace FitBites.Domain.Entities
{
    /// <summary>
    /// 口味字典实体
    /// </summary>
    public class TasteDict : PreferenceDictBase
    {
        /// <summary>
        /// 默认构造函数
        /// </summary>
        public TasteDict() : base()
        {
        }

        /// <summary>
        /// 种子数据构造函数
        /// </summary>
        /// <param name="id">ID</param>
        /// <param name="code">口味编码</param>
        /// <param name="name">口味名称</param>
        /// <param name="description">描述说明</param>
        /// <param name="status">状态</param>
        /// <param name="sortOrder">排序值</param>
        /// <param name="createdAt">创建时间</param>
        /// <param name="updatedAt">更新时间</param>
        public TasteDict(Guid id, string code, string name, string description, bool status, int sortOrder,
            DateTime createdAt, DateTime updatedAt)
            : base(id, code, name, description, status, sortOrder, createdAt, updatedAt)
        {
        }

        /// <summary>
        /// 获取当前偏好类型
        /// </summary>
        /// <returns>偏好类型</returns>
        protected override PreferenceTargetType GetPreferenceType()
        {
            return PreferenceTargetType.Taste;
        }

        /// <summary>
        /// 更新偏好信息
        /// </summary>
        /// <param name="name">名称</param>
        /// <param name="description">描述</param>
        /// <param name="sortOrder">排序值</param>
        public void Update(string name, string description, int? sortOrder)
        {
            if (!string.IsNullOrEmpty(name))
            {
                Name = name;
            }

            if (description != null)
            {
                Description = description;
            }

            if (sortOrder.HasValue)
            {
                SortOrder = sortOrder;
            }

            UpdatedAt = DateTime.Now;

            // 添加领域事件
            AddDomainEvent(new PreferenceChangedEvent(Id, PreferenceTargetType.Taste));
        }

        /// <summary>
        /// 启用偏好
        /// </summary>
        public void Enable()
        {
            if (Status)
            {
                return;
            }

            Status = true;
            UpdatedAt = DateTime.Now;

            // 添加领域事件
            AddDomainEvent(new PreferenceChangedEvent(Id, PreferenceTargetType.Taste));
        }

        /// <summary>
        /// 禁用偏好
        /// </summary>
        public void Disable()
        {
            if (!Status)
            {
                return;
            }

            Status = false;
            UpdatedAt = DateTime.Now;

            // 添加领域事件
            AddDomainEvent(new PreferenceChangedEvent(Id, PreferenceTargetType.Taste));
        }

        /// <summary>
        /// 删除偏好（软删除）
        /// </summary>
        public void Delete()
        {
            if (!Status)
            {
                return;
            }

            Status = false;
            UpdatedAt = DateTime.Now;

            // 添加领域事件
            AddDomainEvent(new PreferenceChangedEvent(Id, PreferenceTargetType.Taste));
        }

        /// <summary>
        /// 基于当前实例创建新的偏好对象
        /// </summary>
        /// <param name="code">编码</param>
        /// <param name="name">名称</param>
        /// <param name="description">描述</param>
        /// <param name="sortOrder">排序值</param>
        /// <returns>创建的偏好实例</returns>
        public static TasteDict Create(string code, string name, string description, int sortOrder)
        {
            var now = DateTime.Now;
            var instance = new TasteDict
            {
                Id = Guid.NewGuid(),
                Code = code,
                Name = name,
                Description = description,
                Status = true,
                SortOrder = sortOrder,
                CreatedAt = now,
                UpdatedAt = now
            };

            // 添加领域事件
            instance.AddDomainEvent(new PreferenceChangedEvent(instance.Id, PreferenceTargetType.Taste));

            return instance;
        }
    }
}