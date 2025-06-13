using FitBites.Domain.Entities;
using System;

namespace FitBites.Application.DTOs.Ingredient
{
    /// <summary>
    /// 食材预处理方法数据传输对象
    /// </summary>
    public class IngredientPreprocessDto
    {
        /// <summary>
        /// ID
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// 食材ID
        /// </summary>
        public Guid IngredientId { get; set; }

        /// <summary>
        /// 加工方式（如捣碎、焯水、冷藏、挂浆等）
        /// </summary>
        public string Method { get; set; }

        /// <summary>
        /// 加工描述
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 加工图片URL
        /// </summary>
        public string ImageUrl { get; set; }

        /// <summary>
        /// 处理时长（秒）
        /// </summary>
        public int? DurationSec { get; set; }

        /// <summary>
        /// 温度描述（如沸水、冷藏）
        /// </summary>
        public string TemperatureDesc { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// 更新时间
        /// </summary>
        public DateTime? UpdatedAt { get; set; }

        /// <summary>
        /// 根据实体创建DTO
        /// </summary>
        /// <param name="entity">食材预处理方法实体</param>
        public IngredientPreprocessDto(IngredientPreprocess entity)
        {
            if (entity == null)
                return;

            Id = entity.Id;
            IngredientId = entity.IngredientId;
            Method = entity.Method;
            Description = entity.Description;
            ImageUrl = entity.ImageUrl;
            DurationSec = entity.DurationSec;
            TemperatureDesc = entity.TemperatureDesc;
            CreatedAt = entity.CreatedAt;
            UpdatedAt = entity.UpdatedAt;
        }

        /// <summary>
        /// 默认构造函数
        /// </summary>
        public IngredientPreprocessDto()
        {
        }
    }
} 