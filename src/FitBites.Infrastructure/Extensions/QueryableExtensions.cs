using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace FitBites.Infrastructure.Extensions
{
    /// <summary>
    /// IQueryable扩展方法
    /// </summary>
    public static class QueryableExtensions
    {
        /// <summary>
        /// 条件性Where扩展方法，仅当条件满足时应用筛选条件
        /// </summary>
        /// <typeparam name="T">实体类型</typeparam>
        /// <param name="query">查询表达式</param>
        /// <param name="condition">条件</param>
        /// <param name="predicate">筛选条件</param>
        /// <returns>查询表达式</returns>
        public static IQueryable<T> WhereIf<T>(
            this IQueryable<T> query,
            bool condition,
            Expression<Func<T, bool>> predicate)
        {
            return condition ? query.Where(predicate) : query;
        }

        /// <summary>
        /// 条件式 Include：当 condition 为 true 时，加载指定的导航属性，并返回支持 ThenInclude 的查询。
        /// </summary>
        /// <typeparam name="TEntity">实体类型</typeparam>
        /// <typeparam name="TProperty">导航属性类型</typeparam>
        /// <param name="source">查询源</param>
        /// <param name="condition">是否应用的条件</param>
        /// <param name="navigationPropertyPath">导航属性表达式</param>
        /// <returns>支持 ThenInclude 的查询对象</returns>
        public static IIncludableQueryable<TEntity, TProperty> IncludeIf<TEntity, TProperty>(
            this IQueryable<TEntity> source,
            bool condition,
            Expression<Func<TEntity, TProperty>> navigationPropertyPath)
            where TEntity : class
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            if (navigationPropertyPath == null)
                throw new ArgumentNullException(nameof(navigationPropertyPath));

            if (condition)
            {
                return source.Include(navigationPropertyPath);
            }

            // 当 condition 为 false 时，返回一个空的 IIncludableQueryable
            return new IncludableQueryableWrapper<TEntity, TProperty>(source);
        }

        /// <summary>
        /// 条件式 ThenInclude：当 condition 为 true 时，加载指定导航属性的子导航属性（引用导航）。
        /// </summary>
        /// <typeparam name="TEntity">实体类型</typeparam>
        /// <typeparam name="TPreviousProperty">前一导航属性类型</typeparam>
        /// <typeparam name="TProperty">子导航属性类型</typeparam>
        /// <param name="source">包含导航属性的查询</param>
        /// <param name="condition">是否应用的条件</param>
        /// <param name="navigationPropertyPath">子导航属性表达式</param>
        /// <returns>包含或不包含子导航属性的查询</returns>
        public static IIncludableQueryable<TEntity, TProperty> ThenIncludeIf<TEntity, TPreviousProperty, TProperty>(
            this IIncludableQueryable<TEntity, TPreviousProperty> source,
            bool condition,
            Expression<Func<TPreviousProperty, TProperty>> navigationPropertyPath)
            where TEntity : class
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            if (navigationPropertyPath == null)
                throw new ArgumentNullException(nameof(navigationPropertyPath));

            return condition
                ? source.ThenInclude(navigationPropertyPath)
                : (IIncludableQueryable<TEntity, TProperty>)source;
        }

        /// <summary>
        /// 条件式 ThenInclude：当 condition 为 true 时，加载指定导航属性的子集合导航。
        /// </summary>
        /// <typeparam name="TEntity">实体类型</typeparam>
        /// <typeparam name="TPreviousProperty">前一导航属性集合的元素类型</typeparam>
        /// <typeparam name="TProperty">子集合导航属性类型</typeparam>
        /// <param name="source">包含集合导航属性的查询</param>
        /// <param name="condition">是否应用的条件</param>
        /// <param name="navigationPropertyPath">子集合导航属性表达式</param>
        /// <returns>包含或不包含子集合导航属性的查询</returns>
        public static IIncludableQueryable<TEntity, TProperty> ThenIncludeIf<TEntity, TPreviousProperty, TProperty>(
            this IIncludableQueryable<TEntity, System.Collections.Generic.IEnumerable<TPreviousProperty>> source,
            bool condition,
            Expression<Func<TPreviousProperty, TProperty>> navigationPropertyPath)
            where TEntity : class
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            if (navigationPropertyPath == null)
                throw new ArgumentNullException(nameof(navigationPropertyPath));

            return condition
                ? source.ThenInclude(navigationPropertyPath)
                : (IIncludableQueryable<TEntity, TProperty>)source;
        }
    }
}