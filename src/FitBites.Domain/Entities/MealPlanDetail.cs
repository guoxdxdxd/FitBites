using System;
using FitBites.Core.Enums;
using FitBites.Domain.Entities.Base;

namespace FitBites.Domain.Entities
{
    /// <summary>
    /// 菜谱明细实体
    /// </summary>
    public class MealPlanDetail : EntityBase
    {


        /// <summary>
        /// 菜谱ID
        /// </summary>
        public Guid MealPlanId { get; private set; }

        /// <summary>
        /// 周内日期
        /// </summary>
        public WeekDay WeekDay { get; private set; }

        /// <summary>
        /// 餐次ID
        /// </summary>
        public Guid MealTimeId { get; private set; }

        /// <summary>
        /// 菜式ID
        /// </summary>
        public Guid RecipeId { get; private set; }

        /// <summary>
        /// 份数
        /// </summary>
        public int? Servings { get; private set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; private set; }



        /// <summary>
        /// 菜谱导航属性
        /// </summary>
        public virtual WeeklyMealPlan MealPlan { get; private set; }

        /// <summary>
        /// 餐次导航属性
        /// </summary>
        public virtual MealTimeDict MealTime { get; private set; }

        /// <summary>
        /// 菜式导航属性
        /// </summary>
        public virtual Recipe Recipe { get; private set; }
    }
} 