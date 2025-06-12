using System;
using System.Collections.Generic;
using FitBites.Core.Enums;
using FitBites.Domain.Entities.Base;
using FitBites.Domain.Events;

namespace FitBites.Domain.Entities
{
    /// <summary>
    /// 周菜谱聚合根
    /// </summary>
    public class WeeklyMealPlan : AggregateRoot
    {
        /// <summary>
        /// 构造函数，初始化集合
        /// </summary>
        public WeeklyMealPlan()
        {
            Orders = new HashSet<MealPlanOrder>();
            Details = new HashSet<MealPlanDetail>();
            Nutritions = new HashSet<MealPlanNutrition>();
        }



        /// <summary>
        /// 唯一菜谱编码
        /// </summary>
        public string PlanCode { get; private set; }

        /// <summary>
        /// 菜谱所属年份
        /// </summary>
        public int Year { get; private set; }

        /// <summary>
        /// 年内周数（1-52）
        /// </summary>
        public int WeekNumber { get; private set; }

        /// <summary>
        /// 菜谱开始日期
        /// </summary>
        public DateTime StartDate { get; private set; }

        /// <summary>
        /// 菜谱结束日期
        /// </summary>
        public DateTime EndDate { get; private set; }

        /// <summary>
        /// 用户ID
        /// </summary>
        public Guid? UserId { get; private set; }

        /// <summary>
        /// 家庭ID
        /// </summary>
        public Guid? FamilyId { get; private set; }

        /// <summary>
        /// 创建者用户ID
        /// </summary>
        public Guid CreatorUserId { get; private set; }

        /// <summary>
        /// 菜谱特点描述
        /// </summary>
        public string Description { get; private set; }

        /// <summary>
        /// 状态
        /// </summary>
        public MealPlanStatus Status { get; private set; }



        /// <summary>
        /// 用户导航属性
        /// </summary>
        public virtual User User { get; private set; }

        /// <summary>
        /// 家庭导航属性
        /// </summary>
        public virtual Family Family { get; private set; }

        /// <summary>
        /// 创建者导航属性
        /// </summary>
        public virtual User Creator { get; private set; }

        /// <summary>
        /// 点菜集合
        /// </summary>
        public virtual ICollection<MealPlanOrder> Orders { get; private set; }

        /// <summary>
        /// 菜谱明细集合
        /// </summary>
        public virtual ICollection<MealPlanDetail> Details { get; private set; }

        /// <summary>
        /// 菜谱营养集合
        /// </summary>
        public virtual ICollection<MealPlanNutrition> Nutritions { get; private set; }
    }
} 