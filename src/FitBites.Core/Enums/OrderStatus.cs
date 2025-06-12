namespace FitBites.Core.Enums
{
    /// <summary>
    /// 点菜状态枚举
    /// </summary>
    public enum OrderStatus
    {
        /// <summary>
        /// 待确认
        /// </summary>
        Pending = 0,

        /// <summary>
        /// 已确认
        /// </summary>
        Confirmed = 1,

        /// <summary>
        /// 已拒绝
        /// </summary>
        Rejected = 2
    }
} 