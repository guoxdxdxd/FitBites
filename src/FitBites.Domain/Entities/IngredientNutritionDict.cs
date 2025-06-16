using System;
using System.Collections.Generic;
using FitBites.Domain.Entities.Base;

namespace FitBites.Domain.Entities
{
    /// <summary>
    /// 营养成分字典实体
    /// </summary>
    public class IngredientNutritionDict : EntityBase
    {
        /// <summary>
        /// 构造函数，初始化集合
        /// </summary>
        public IngredientNutritionDict()
        {
            IngredientNutritions = new HashSet<IngredientNutrition>();
            MealPlanNutritions = new HashSet<MealPlanNutrition>();
        }

        /// <summary>
        /// 种子数据构造函数
        /// </summary>
        /// <param name="id">ID</param>
        /// <param name="name">成分名称</param>
        /// <param name="unit">单位</param>
        /// <param name="description">描述说明</param>
        /// <param name="createdAt">创建时间</param>
        /// <param name="updatedAt">更新时间</param>
        public IngredientNutritionDict(Guid id, string name, string unit, string description, DateTime createdAt, DateTime updatedAt)
        {
            Id = id;
            Name = name;
            Unit = unit;
            Description = description;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
            IngredientNutritions = new HashSet<IngredientNutrition>();
            MealPlanNutritions = new HashSet<MealPlanNutrition>();
        }

        /// <summary>
        /// 成分名称（如：蛋白质）
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// 单位（g、mg、μg等）
        /// </summary>
        public string Unit { get; private set; }

        /// <summary>
        /// 描述说明
        /// </summary>
        public string Description { get; private set; }

        /// <summary>
        /// 食材营养成分映射集合
        /// </summary>
        public virtual ICollection<IngredientNutrition> IngredientNutritions { get; private set; }

        /// <summary>
        /// 菜谱营养集合
        /// </summary>
        public virtual ICollection<MealPlanNutrition> MealPlanNutritions { get; private set; }

        /// <summary>
        /// 创建营养成分字典工厂方法
        /// </summary>
        public static IngredientNutritionDict Create(string name, string unit, string description)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new DomainException("成分名称不能为空");
            if (string.IsNullOrWhiteSpace(unit))
                throw new DomainException("单位不能为空");
            return new IngredientNutritionDict
            {
                Id = Guid.NewGuid(),
                Name = name,
                Unit = unit,
                Description = description,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                IngredientNutritions = new HashSet<IngredientNutrition>(),
                MealPlanNutritions = new HashSet<MealPlanNutrition>()
            };
        }

        /// <summary>
        /// 更新营养成分字典
        /// </summary>
        public void Update(string name, string unit, string description)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new DomainException("成分名称不能为空");
            if (string.IsNullOrWhiteSpace(unit))
                throw new DomainException("单位不能为空");
            Name = name;
            Unit = unit;
            Description = description;
            UpdatedAt = DateTime.UtcNow;
        }
    }
} 