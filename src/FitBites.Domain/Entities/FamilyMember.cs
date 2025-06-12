using FitBites.Core.Enums;
using FitBites.Domain.Entities.Base;

namespace FitBites.Domain.Entities
{
    /// <summary>
    /// 家庭成员实体
    /// </summary>
    public class FamilyMember : EntityBase
    {


        /// <summary>
        /// 家庭ID
        /// </summary>
        public Guid FamilyId { get; private set; }

        /// <summary>
        /// 成员用户ID
        /// </summary>
        public Guid UserId { get; private set; }

        /// <summary>
        /// 成员角色（户主、副户主、成员）
        /// </summary>
        public FamilyMemberRole MemberRole { get; private set; }

        /// <summary>
        /// 加入时间
        /// </summary>
        public DateTime JoinedAt { get; private set; }

        /// <summary>
        /// 家庭导航属性
        /// </summary>
        public virtual Family Family { get; private set; }

        /// <summary>
        /// 用户导航属性
        /// </summary>
        public virtual User User { get; private set; }
    }
} 