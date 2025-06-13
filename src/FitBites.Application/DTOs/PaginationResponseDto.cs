using System.Collections.Generic;

namespace FitBites.Application.DTOs
{
    /// <summary>
    /// 分页响应数据传输对象
    /// </summary>
    /// <typeparam name="T">分页项类型</typeparam>
    public class PaginationResponseDto<T> where T : class
    {
        /// <summary>
        /// 当前页码
        /// </summary>
        public int PageIndex { get; set; }
        
        /// <summary>
        /// 每页大小
        /// </summary>
        public int PageSize { get; set; }
        
        /// <summary>
        /// 总记录数
        /// </summary>
        public int TotalCount { get; set; }
        
        /// <summary>
        /// 总页数
        /// </summary>
        public int TotalPages => (TotalCount + PageSize - 1) / PageSize;
        
        /// <summary>
        /// 是否有上一页
        /// </summary>
        public bool HasPrevious => PageIndex > 1;
        
        /// <summary>
        /// 是否有下一页
        /// </summary>
        public bool HasNext => PageIndex < TotalPages;
        
        /// <summary>
        /// 数据项列表
        /// </summary>
        public List<T> Items { get; set; } = new List<T>();
    }
} 