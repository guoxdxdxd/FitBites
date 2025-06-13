using FitBites.Core.Enums;
using FitBites.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FitBites.Application.DTOs.Ingredient
{
    /// <summary>
    /// 食材数据传输对象
    /// </summary>
    public class IngredientDto
    {
        /// <summary>
        /// 食材ID
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// 食材名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 食材类别
        /// </summary>
        public IngredientCategory Category { get; set; }

        /// <summary>
        /// 食材类别名称
        /// </summary>
        public string CategoryName { get; set; }

        /// <summary>
        /// 含水量
        /// </summary>
        public string WaterContent { get; set; }

        /// <summary>
        /// 味型
        /// </summary>
        public string FlavorProfile { get; set; }

        /// <summary>
        /// 功能
        /// </summary>
        public string MainFunctions { get; set; }

        /// <summary>
        /// 烹饪行为特性
        /// </summary>
        public string CookingBehavior { get; set; }

        /// <summary>
        /// 推荐使用方式
        /// </summary>
        public string PreferredUsage { get; set; }

        /// <summary>
        /// 是否易挥发
        /// </summary>
        public bool? Volatile { get; set; }

        /// <summary>
        /// 其他备注
        /// </summary>
        public string Notes { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// 更新时间
        /// </summary>
        public DateTime? UpdatedAt { get; set; }

        /// <summary>
        /// 营养成分集合
        /// </summary>
        public List<IngredientNutritionDto> Nutritions { get; set; } = new List<IngredientNutritionDto>();

        /// <summary>
        /// 人群适宜/忌用映射集合
        /// </summary>
        public List<IngredientHumanGroupDto> HumanGroups { get; set; } = new List<IngredientHumanGroupDto>();

        /// <summary>
        /// 预处理集合
        /// </summary>
        public List<IngredientPreprocessDto> Preprocesses { get; set; } = new List<IngredientPreprocessDto>();

        /// <summary>
        /// 根据实体创建DTO
        /// </summary>
        /// <param name="entity">食材实体</param>
        public IngredientDto(Domain.Entities.Ingredient entity)
        {
            if (entity == null)
                return;

            Id = entity.Id;
            Name = entity.Name;
            Category = entity.Category;
            CategoryName = entity.Category.ToString();
            WaterContent = entity.WaterContent;
            FlavorProfile = entity.FlavorProfile;
            MainFunctions = entity.MainFunctions;
            CookingBehavior = entity.CookingBehavior;
            PreferredUsage = entity.PreferredUsage;
            Volatile = entity.Volatile;
            Notes = entity.Notes;
            CreatedAt = entity.CreatedAt;
            UpdatedAt = entity.UpdatedAt;

            if (entity.Nutritions != null)
            {
                Nutritions = entity.Nutritions.Select(n => new IngredientNutritionDto(n)).ToList();
            }

            if (entity.HumanGroups != null)
            {
                HumanGroups = entity.HumanGroups.Select(h => new IngredientHumanGroupDto(h)).ToList();
            }

            if (entity.Preprocesses != null)
            {
                Preprocesses = entity.Preprocesses.Select(p => new IngredientPreprocessDto(p)).ToList();
            }
        }

        /// <summary>
        /// 默认构造函数
        /// </summary>
        public IngredientDto()
        {
        }
    }
} 