using FitBites.Domain.Entities.Base;

namespace FitBites.Domain.Entities
{
    /// <summary>
    /// 家庭聚合根
    /// </summary>
    public class Family : AggregateRoot
    {
        /// <summary>
        /// 构造函数，初始化集合
        /// </summary>
        public Family()
        {
            Members = new HashSet<FamilyMember>();
            FamilyMealPlans = new HashSet<WeeklyMealPlan>();
        }



        /// <summary>
        /// 家庭编码，唯一
        /// </summary>
        public string FamilyCode { get; private set; }

        /// <summary>
        /// 家庭名称
        /// </summary>
        public string FamilyName { get; private set; }

        /// <summary>
        /// 户主用户ID
        /// </summary>
        public Guid OwnerUserId { get; private set; }

        /// <summary>
        /// 家庭描述
        /// </summary>
        public string Description { get; private set; }

        /// <summary>
        /// 家庭头像URL
        /// </summary>
        public string Avatar { get; private set; }



        /// <summary>
        /// 户主用户导航属性
        /// </summary>
        public virtual User Owner { get; private set; }

        /// <summary>
        /// 家庭成员集合
        /// </summary>
        public virtual ICollection<FamilyMember> Members { get; private set; }

        /// <summary>
        /// 家庭菜谱集合
        /// </summary>
        public virtual ICollection<WeeklyMealPlan> FamilyMealPlans { get; private set; }
    }
} 