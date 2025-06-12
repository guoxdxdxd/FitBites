using System;
using System.Collections.Generic;
using System.Linq;

namespace FitBites.Infrastructure.Extensions
{
    /// <summary>
    /// IEnumerable扩展方法
    /// </summary>
    public static class EnumerableExtensions
    {
        /// <summary>
        /// 条件性Where扩展方法，适用于IEnumerable集合，仅当条件满足时应用筛选条件
        /// </summary>
        /// <typeparam name="T">实体类型</typeparam>
        /// <param name="collection">集合</param>
        /// <param name="condition">条件</param>
        /// <param name="predicate">筛选条件</param>
        /// <returns>筛选后的集合</returns>
        public static IEnumerable<T> WhereIf<T>(
            this IEnumerable<T> collection,
            bool condition,
            Func<T, bool> predicate)
        {
            return condition ? collection.Where(predicate) : collection;
        }
    }
} 