namespace FitBites.Application.DTOs
{
    /// <summary>
    /// API返回结果
    /// </summary>
    /// <typeparam name="T">返回数据类型</typeparam>
    public class ApiResult<T>
    {
        /// <summary>
        /// 状态码：0成功，其他失败
        /// </summary>
        public int Code { get; set; }
        
        /// <summary>
        /// 消息
        /// </summary>
        public string Message { get; set; }
        
        /// <summary>
        /// 返回数据
        /// </summary>
        public T Data { get; set; }
        
        /// <summary>
        /// 创建成功结果
        /// </summary>
        /// <param name="data">数据</param>
        /// <param name="message">消息</param>
        /// <returns>API结果</returns>
        public static ApiResult<T> Success(T data, string message = "操作成功")
        {
            return new ApiResult<T>
            {
                Code = 0,
                Message = message,
                Data = data
            };
        }
        
        /// <summary>
        /// 创建失败结果
        /// </summary>
        /// <param name="message">错误消息</param>
        /// <param name="code">错误码</param>
        /// <returns>API结果</returns>
        public static ApiResult<T> Fail(string message, int code = 1)
        {
            return new ApiResult<T>
            {
                Code = code,
                Message = message,
                Data = default
            };
        }
    }
} 