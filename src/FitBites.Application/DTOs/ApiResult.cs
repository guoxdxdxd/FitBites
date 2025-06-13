using System;

namespace FitBites.Application.DTOs
{
    /// <summary>
    /// API返回结果（无数据版本）
    /// </summary>
    public class ApiResult
    {
        /// <summary>
        /// 是否成功
        /// </summary>
        public bool IsSuccess { get; set; }

        /// <summary>
        /// 消息
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// 错误代码
        /// </summary>
        public string ErrorCode { get; set; }

        /// <summary>
        /// 创建成功结果
        /// </summary>
        /// <param name="message">消息</param>
        /// <returns>API结果</returns>
        public static ApiResult SuccessResult(string message = "操作成功")
        {
            return new ApiResult
            {
                IsSuccess = true,
                Message = message
            };
        }

        /// <summary>
        /// 创建失败结果
        /// </summary>
        /// <param name="message">错误消息</param>
        /// <param name="errorCode">错误代码</param>
        /// <returns>API结果</returns>
        public static ApiResult FailResult(string message, string errorCode = null)
        {
            return new ApiResult
            {
                IsSuccess = false,
                Message = message,
                ErrorCode = errorCode
            };
        }
        
        /// <summary>
        /// 创建成功结果
        /// </summary>
        /// <param name="message">消息</param>
        /// <returns>API结果</returns>
        public static ApiResult Success(string message = "操作成功")
        {
            return SuccessResult(message);
        }

        /// <summary>
        /// 创建失败结果
        /// </summary>
        /// <param name="message">错误消息</param>
        /// <param name="errorCode">错误代码</param>
        /// <returns>API结果</returns>
        public static ApiResult Fail(string message, string errorCode = null)
        {
            return FailResult(message, errorCode);
        }
    }

    /// <summary>
    /// API返回结果（包含数据）
    /// </summary>
    /// <typeparam name="T">数据类型</typeparam>
    public class ApiResult<T> : ApiResult
    {
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
        public static ApiResult<T> SuccessResult(T data, string message = "操作成功")
        {
            return new ApiResult<T>
            {
                IsSuccess = true,
                Message = message,
                Data = data
            };
        }

        /// <summary>
        /// 创建失败结果
        /// </summary>
        /// <param name="message">错误消息</param>
        /// <param name="errorCode">错误代码</param>
        /// <returns>API结果</returns>
        public static new ApiResult<T> FailResult(string message, string errorCode = null)
        {
            return new ApiResult<T>
            {
                IsSuccess = false,
                Message = message,
                ErrorCode = errorCode,
                Data = default
            };
        }
        
        /// <summary>
        /// 创建成功结果
        /// </summary>
        /// <param name="data">数据</param>
        /// <param name="message">消息</param>
        /// <returns>API结果</returns>
        public static ApiResult<T> Success(T data, string message = "操作成功")
        {
            return SuccessResult(data, message);
        }

        /// <summary>
        /// 创建失败结果
        /// </summary>
        /// <param name="message">错误消息</param>
        /// <param name="errorCode">错误代码</param>
        /// <returns>API结果</returns>
        public static new ApiResult<T> Fail(string message, string errorCode = null)
        {
            return FailResult(message, errorCode);
        }
    }
} 