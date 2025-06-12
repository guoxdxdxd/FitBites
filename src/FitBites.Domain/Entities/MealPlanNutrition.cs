using System;
using FitBites.Domain.Entities.Base;

namespace FitBites.Domain.Entities
{
    /// <summary>
    /// 菜谱营养实体
    /// </summary>
    public class MealPlanNutrition : EntityBase
    {


        /// <summary>
        /// 菜谱ID
        /// </summary>
        public Guid MealPlanId { get; private set; }

        /// <summary>
        /// 营养成分ID
        /// </summary>
        public Guid NutrientId { get; private set; }

        /// <summary>
        /// 一周营养成分总量
        /// </summary>
        public decimal TotalAmount { get; private set; }

        /// <summary>
        /// 计量单位
        /// </summary>
        public string Unit { get; private set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; private set; }



        /// <summary>
        /// 菜谱导航属性
        /// </summary>
        public virtual WeeklyMealPlan MealPlan { get; private set; }

        /// <summary>
        /// 营养成分导航属性
        /// </summary>
        public virtual IngredientNutritionDict Nutrient { get; private set; }
    }
} 