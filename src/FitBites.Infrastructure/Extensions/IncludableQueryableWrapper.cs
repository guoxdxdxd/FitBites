using System.Collections;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore.Query;

namespace FitBites.Infrastructure.Extensions;

/// <summary>
/// 包装类，用于在 IncludeIf 条件为 false 时提供 IIncludableQueryable 接口。
/// </summary>
internal class IncludableQueryableWrapper<TEntity, TProperty> : IIncludableQueryable<TEntity, TProperty>, IQueryable<TEntity>
    where TEntity : class
{
    private readonly IQueryable<TEntity> _source;

    /// <summary>
    /// 构造函数，接受原始 IQueryable 查询对象。
    /// </summary>
    /// <param name="source">原始查询</param>
    public IncludableQueryableWrapper(IQueryable<TEntity> source)
    {
        _source = source ?? throw new ArgumentNullException(nameof(source));
    }

    /// <summary>
    /// 获取查询的元素类型。
    /// </summary>
    public Type ElementType => _source.ElementType;

    /// <summary>
    /// 获取查询的表达式树。
    /// </summary>
    public Expression Expression => _source.Expression;

    /// <summary>
    /// 获取查询的提供程序。
    /// </summary>
    public IQueryProvider Provider => _source.Provider;

    /// <summary>
    /// 获取非泛型枚举器。
    /// </summary>
    public IEnumerator GetEnumerator() => _source.GetEnumerator();

    /// <summary>
    /// 获取泛型枚举器。
    /// </summary>
    IEnumerator<TEntity> IEnumerable<TEntity>.GetEnumerator() => _source.GetEnumerator();
}