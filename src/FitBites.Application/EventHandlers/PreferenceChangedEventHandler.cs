using FitBites.Application.Services.Preference;
using FitBites.Core.Enums;
using FitBites.Domain.Entities;
using FitBites.Domain.Entities.Base;
using FitBites.Domain.Events;
using FitBites.Domain.IRepositories;
using FitBites.Infrastructure.Events;
using Microsoft.Extensions.Logging;

namespace FitBites.Application.EventHandlers
{
    /// <summary>
    /// 偏好变更事件处理器
    /// 处理偏好数据（菜系、烹饪方式、口味）的变更事件，并刷新相应的缓存
    /// </summary>
    public class PreferenceChangedEventHandler :DomainEventHandler<PreferenceChangedEvent>
    {
        private readonly IPreferenceService _preferenceService;
        private readonly ICuisineRepository _cuisineRepository;
        private readonly ICookingMethodRepository _cookingMethodRepository;
        private readonly ITasteRepository _tasteRepository;

        public PreferenceChangedEventHandler(ILogger<PreferenceChangedEventHandler> logger,
            IPreferenceService preferenceService,
            ICuisineRepository cuisineRepository,
            ICookingMethodRepository cookingMethodRepository,
            ITasteRepository tasteRepository) : base(logger)
        {
            _preferenceService = preferenceService;
            _cuisineRepository = cuisineRepository;
            _cookingMethodRepository = cookingMethodRepository;
            _tasteRepository = tasteRepository;
        }

        protected override async Task ProcessEventAsync(PreferenceChangedEvent @event)
        {
            try
            {
                Logger.LogInformation(
                    "处理偏好变更事件: 类型={PreferenceType}, ID={PreferenceId}",
                    @event.TargetType,
                    @event.PreferenceId);
                
                // 刷新相应的缓存
                switch (@event.TargetType)
                {
                    case PreferenceTargetType.Cuisine:
                        await _preferenceService.RefreshCacheAsync<CuisineDict>(_cuisineRepository.QueryListAsync);
                        break;
                    case PreferenceTargetType.CookingMethod:
                        await _preferenceService.RefreshCacheAsync<CookingMethodDict>(_cookingMethodRepository.QueryListAsync);
                        break;
                    case PreferenceTargetType.Taste:
                        await _preferenceService.RefreshCacheAsync<TasteDict>(_tasteRepository.QueryListAsync);
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
               
                Logger.LogInformation(
                    "偏好变更事件处理完成: 类型={PreferenceType}, ID={PreferenceId}",
                    @event.TargetType,
                    @event.PreferenceId);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, 
                    "处理偏好变更事件失败: 类型={PreferenceType}, ID={PreferenceId}",
                    @event.TargetType,
                    @event.PreferenceId);
                
                // 不抛出异常，防止影响主流程
                // 缓存刷新失败不影响业务操作
            }
        }
    }
} 