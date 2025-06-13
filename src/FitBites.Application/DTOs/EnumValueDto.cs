namespace FitBites.Application.DTOs
{
    /// <summary>
    /// 枚举值数据传输对象
    /// </summary>
    public class EnumValueDto
    {
        /// <summary>
        /// 枚举值
        /// </summary>
        public int Value { get; set; }

        /// <summary>
        /// 枚举名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 枚举描述
        /// </summary>
        public string Description { get; set; }
    }
} 