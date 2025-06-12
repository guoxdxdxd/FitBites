using System;
using FitBites.Domain.Entities.Base;

namespace FitBites.Domain.Entities
{
    /// <summary>
    /// 配料预处理实体
    /// </summary>
    public class IngredientPreprocess : EntityBase
    {
        /// <summary>
        /// 种子数据构造函数
        /// </summary>
        public IngredientPreprocess(Guid id, Guid ingredientId, string method, string description, int? durationSec, string temperatureDesc, DateTime createdAt, DateTime updatedAt)
        {
            Id = id;
            IngredientId = ingredientId;
            Method = method;
            Description = description;
            DurationSec = durationSec;
            TemperatureDesc = temperatureDesc;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
        }

        /// <summary>
        /// 种子数据构造函数（带图片URL）
        /// </summary>
        public IngredientPreprocess(Guid id, Guid ingredientId, string method, string description, int? durationSec, string temperatureDesc, DateTime createdAt, DateTime updatedAt, string imageUrl)
        {
            Id = id;
            IngredientId = ingredientId;
            Method = method;
            Description = description;
            DurationSec = durationSec;
            TemperatureDesc = temperatureDesc;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
            ImageUrl = imageUrl;
        }

        /// <summary>
        /// 食材ID
        /// </summary>
        public Guid IngredientId { get; private set; }

        /// <summary>
        /// 加工方式（如捣碎、焯水、冷藏、挂浆等）
        /// </summary>
        public string Method { get; private set; }

        /// <summary>
        /// 加工描述
        /// </summary>
        public string Description { get; private set; }

        /// <summary>
        /// 加工图片URL
        /// </summary>
        public string ImageUrl { get; private set; }

        /// <summary>
        /// 处理时长（秒）
        /// </summary>
        public int? DurationSec { get; private set; }

        /// <summary>
        /// 温度描述（如沸水、冷藏）
        /// </summary>
        public string TemperatureDesc { get; private set; }

        /// <summary>
        /// 食材导航属性
        /// </summary>
        public virtual Ingredient Ingredient { get; private set; }
    }
} 