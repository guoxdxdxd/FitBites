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
        /// 条件性Include扩展方法，仅当条件满足时加载关联数据
        /// </summary>
        /// <typeparam name="T">实体类型</typeparam>
        /// <typeparam name="TProperty">关联属性类型</typeparam>
        /// <param name="query">查询表达式</param>
        /// <param name="condition">条件</param>
        /// <param name="path">关联属性表达式</param>
        /// <returns>查询表达式</returns>
        public static IQueryable<T> IncludeIf<T, TProperty>(
            this IQueryable<T> query,
            bool condition,
            Expression<Func<T, TProperty>> path)
            where T : class
        {
            return condition ? query.Include(path) : query;
        }

        /// <summary>
        /// 条件性Include扩展方法，支持字符串路径
        /// </summary>
        /// <typeparam name="T">实体类型</typeparam>
        /// <param name="query">查询表达式</param>
        /// <param name="condition">条件</param>
        /// <param name="path">关联属性路径</param>
        /// <returns>查询表达式</returns>
        public static IQueryable<T> IncludeIf<T>(
            this IQueryable<T> query,
            bool condition,
            string path)
            where T : class
        {
            return condition ? query.Include(path) : query;
        }

        // 注：ThenIncludeIf方法由于类型转换问题暂时移除
        // 对于条件性的ThenInclude操作，建议使用条件判断后再调用ThenInclude方法
    }
} 