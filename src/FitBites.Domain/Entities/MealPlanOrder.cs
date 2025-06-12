using System;
using FitBites.Core.Enums;
using FitBites.Domain.Entities.Base;

namespace FitBites.Domain.Entities
{
    /// <summary>
    /// 菜谱点菜实体
    /// </summary>
    public class MealPlanOrder : EntityBase
    {


        /// <summary>
        /// 菜谱ID
        /// </summary>
        public Guid MealPlanId { get; private set; }

        /// <summary>
        /// 点菜用户ID
        /// </summary>
        public Guid UserId { get; private set; }

        /// <summary>
        /// 菜式ID
        /// </summary>
        public Guid RecipeId { get; private set; }

        /// <summary>
        /// 点菜状态
        /// </summary>
        public OrderStatus Status { get; private set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; private set; }



        /// <summary>
        /// 菜谱导航属性
        /// </summary>
        public virtual WeeklyMealPlan MealPlan { get; private set; }

        /// <summary>
        /// 用户导航属性
        /// </summary>
        public virtual User User { get; private set; }

        /// <summary>
        /// 菜式导航属性
        /// </summary>
        public virtual Recipe Recipe { get; private set; }
    }
} 