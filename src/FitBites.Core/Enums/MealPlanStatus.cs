namespace FitBites.Core.Enums
{
    /// <summary>
    /// 菜谱状态枚举
    /// </summary>
    public enum MealPlanStatus
    {
        /// <summary>
        /// 草稿
        /// </summary>
        Draft = 0,

        /// <summary>
        /// 启用
        /// </summary>
        Active = 1,
        
        /// <summary>
        /// 禁用
        /// </summary>
        Disabled = 4,
        
        /// <summary>
        /// 生成中
        /// </summary>
        Generating = 2,
        
        /// <summary>
        /// 生成失败
        /// </summary>
        Fail = 3
        
    }
} 