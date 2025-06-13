using FitBites.Application.Services.Interfaces;
using FitBites.Domain.Entities;
using FitBites.Domain.Events;
using FitBites.Domain.IRepositories;
using FitBites.Infrastructure.Events;
using Microsoft.Extensions.Logging;

namespace FitBites.Application.EventHandlers
{
    /// <summary>
    /// 人群标签变更事件处理器
    /// 处理人群标签数据的变更事件，并刷新相应的缓存
    /// </summary>
    public class HumanGroupChangedEventHandler : DomainEventHandler<HumanGroupChangedEvent>
    {
        private readonly IHumanGroupDictService _humanGroupDictService;
        private readonly IHumanGroupDictRepository _humanGroupDictRepository;

        public HumanGroupChangedEventHandler(
            ILogger<HumanGroupChangedEventHandler> logger,
            IHumanGroupDictService humanGroupDictService,
            IHumanGroupDictRepository humanGroupDictRepository) : base(logger)
        {
            _humanGroupDictService = humanGroupDictService;
            _humanGroupDictRepository = humanGroupDictRepository;
        }

        protected override async Task ProcessEventAsync(HumanGroupChangedEvent @event)
        {
            try
            {
                Logger.LogInformation(
                    "处理人群标签变更事件: ID={HumanGroupId}",
                    @event.HumanGroupId);
                
                // 刷新人群标签缓存
                await _humanGroupDictService.RefreshCacheAsync();
               
                Logger.LogInformation(
                    "人群标签变更事件处理完成: ID={HumanGroupId}",
                    @event.HumanGroupId);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, 
                    "处理人群标签变更事件失败: ID={HumanGroupId}",
                    @event.HumanGroupId);
                
                // 不抛出异常，防止影响主流程
                // 缓存刷新失败不影响业务操作
            }
        }
    }
} 