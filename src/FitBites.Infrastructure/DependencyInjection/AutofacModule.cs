using Autofac;
using FitBites.Core.DependencyInjection;
using FitBites.Infrastructure.Services;
using Microsoft.Extensions.Configuration;
using System.Reflection;

namespace FitBites.Infrastructure.DependencyInjection
{
    /// <summary>
    /// 
    /// </summary>
    public class AutofacModule : Autofac.Module
    {
        private readonly IConfiguration _configuration;

        public AutofacModule(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void Load(ContainerBuilder builder)
        {
            // 注册IConfiguration
            builder.RegisterInstance(_configuration).As<IConfiguration>().SingleInstance();
            
            // 注册JwtService为单例
            builder.RegisterType<JwtService>().AsSelf().SingleInstance();

            // 获取所有程序集
            var assemblies = GetAllReferencedAssemblies().ToArray();

            // 按接口标记注册服务
            // 注册所有实现了ISingletonDependency接口的类
            builder.RegisterAssemblyTypes(assemblies)
                .Where(t => t.IsClass && !t.IsAbstract && typeof(ISingletonDependency).IsAssignableFrom(t))
                .AsImplementedInterfaces()
                .SingleInstance();

            // 注册所有实现了IScopedDependency接口的类
            builder.RegisterAssemblyTypes(assemblies)
                .Where(t => t.IsClass && !t.IsAbstract && typeof(IScopedDependency).IsAssignableFrom(t))
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();

            // 注册所有实现了ITransientDependency接口的类
            builder.RegisterAssemblyTypes(assemblies)
                .Where(t => t.IsClass && !t.IsAbstract && typeof(ITransientDependency).IsAssignableFrom(t))
                .AsImplementedInterfaces()
                .InstancePerDependency();

            // 对于没有接口但实现了依赖注入标记的类，直接注册自身
            builder.RegisterAssemblyTypes(assemblies)
                .Where(t => t.IsClass && !t.IsAbstract && 
                       typeof(IDependency).IsAssignableFrom(t) && 
                       !t.GetInterfaces().Any(i => i.Name != nameof(IDependency) && 
                                                 i.Name != nameof(ITransientDependency) && 
                                                 i.Name != nameof(IScopedDependency) && 
                                                 i.Name != nameof(ISingletonDependency)))
                .AsSelf();
        }

        /// <summary>
        /// 获取所有引用的程序集
        /// </summary>
        /// <returns>程序集集合</returns>
        private IEnumerable<Assembly> GetAllReferencedAssemblies()
        {
            var loadedAssemblies = AppDomain.CurrentDomain.GetAssemblies().ToList();
            var result = new HashSet<Assembly>();
            
            // 查找API程序集
            var apiAssembly = loadedAssemblies.FirstOrDefault(a => 
                a.FullName != null && a.FullName.StartsWith("FitBites.API"));
                
            if (apiAssembly != null)
            {
                // 递归获取API程序集引用的所有程序集
                GetReferencedAssemblies(apiAssembly, result, loadedAssemblies);
            }
            
            // 筛选出FitBites相关的程序集
            return result.Where(a => a.FullName != null && (
                a.FullName.StartsWith("FitBites.Core") ||
                a.FullName.StartsWith("FitBites.Domain") ||
                a.FullName.StartsWith("FitBites.Application") ||
                a.FullName.StartsWith("FitBites.Infrastructure") ||
                a.FullName.StartsWith("FitBites.API")));
        }
        
        /// <summary>
        /// 递归获取引用的程序集
        /// </summary>
        /// <param name="assembly">程序集</param>
        /// <param name="result">结果集</param>
        /// <param name="loadedAssemblies">已加载程序集</param>
        private void GetReferencedAssemblies(Assembly assembly, HashSet<Assembly> result, List<Assembly> loadedAssemblies)
        {
            if (!result.Add(assembly))
                return;
                
            foreach (var referencedAssemblyName in assembly.GetReferencedAssemblies())
            {
                var referencedAssembly = loadedAssemblies.FirstOrDefault(a => a.FullName == referencedAssemblyName.FullName);
                
                if (referencedAssembly == null)
                {
                    try
                    {
                        referencedAssembly = Assembly.Load(referencedAssemblyName);
                        loadedAssemblies.Add(referencedAssembly);
                    }
                    catch
                    {
                        // 加载失败，跳过
                        continue;
                    }
                }
                
                GetReferencedAssemblies(referencedAssembly, result, loadedAssemblies);
            }
        }
    }
} 