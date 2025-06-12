using System.Threading.Tasks;
using FitBites.Domain.Events;
using Microsoft.Extensions.Logging;

namespace FitBites.Infrastructure.Events
{
    /// <summary>
    /// 用户创建事件处理器
    /// </summary>
    public class UserCreatedEventHandler : DomainEventHandler<UserCreatedEvent>
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="logger">日志记录器</param>
        public UserCreatedEventHandler(ILogger<UserCreatedEventHandler> logger) 
            : base(logger)
        {
        }

        /// <summary>
        /// 处理用户创建事件
        /// </summary>
        /// <param name="event">用户创建事件</param>
        /// <returns>任务</returns>
        protected override async Task ProcessEventAsync(UserCreatedEvent @event)
        {
            // 这里实现具体的业务逻辑
            // 例如：发送欢迎邮件、初始化用户资料、分配默认权限等
            
            Logger.LogInformation("处理用户创建事件: 用户ID: {@UserId}, 用户名: {@Username}", @event.UserId, @event.Username);
            
            // 模拟异步操作
            await Task.CompletedTask;
        }
    }
} 