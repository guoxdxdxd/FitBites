using FitBites.Domain.Events;
using Microsoft.Extensions.Logging;

namespace FitBites.Infrastructure.Events;

public class UserLoggedInEventHandler : DomainEventHandler<UserLoggedInEvent>
{
    public UserLoggedInEventHandler(ILogger<DomainEventHandler<UserLoggedInEvent>> logger) : base(logger)
    {
    }

    protected override async Task ProcessEventAsync(UserLoggedInEvent @event)
    {           
        Logger.LogInformation("处理用户登录事件: 用户ID: {@UserId}, 用户名: {@Username}", @event.UserId, @event.Username);
            
        // 模拟异步操作
        await Task.CompletedTask;
    }
}