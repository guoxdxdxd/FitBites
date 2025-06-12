namespace FitBites.Core.DependencyInjection
{
    /// <summary>
    /// 依赖注入的基础接口，所有需要自动注册的服务都应该实现此接口或其子接口
    /// </summary>
    public interface IDependency
    {
    }

    /// <summary>
    /// 瞬态生命周期服务标记接口
    /// </summary>
    public interface ITransientDependency : IDependency
    {
    }

    /// <summary>
    /// 作用域生命周期服务标记接口
    /// </summary>
    public interface IScopedDependency : IDependency
    {
    }

    /// <summary>
    /// 单例生命周期服务标记接口
    /// </summary>
    public interface ISingletonDependency : IDependency
    {
    }
} 