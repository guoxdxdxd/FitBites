using System;

namespace FitBites.Domain
{
    /// <summary>
    /// 领域异常
    /// </summary>
    public class DomainException : Exception
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="message">异常信息</param>
        public DomainException(string message) : base(message)
        {
        }
        
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="message">异常信息</param>
        /// <param name="innerException">内部异常</param>
        public DomainException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
} 