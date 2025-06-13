namespace FitBites.Application.DTOs
{
    /// <summary>
    /// 分页请求数据传输对象
    /// </summary>
    public class PaginationRequestDto
    {
        private int _pageIndex = 1;
        private int _pageSize = 10;
        
        /// <summary>
        /// 页码（从1开始）
        /// </summary>
        public int PageIndex 
        { 
            get => _pageIndex;
            set => _pageIndex = value < 1 ? 1 : value;
        }
        
        /// <summary>
        /// 每页大小
        /// </summary>
        public int PageSize 
        { 
            get => _pageSize;
            set => _pageSize = value < 1 ? 10 : (value > 100 ? 100 : value);
        }
    }
} 