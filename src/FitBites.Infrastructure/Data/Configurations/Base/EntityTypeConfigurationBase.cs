using FitBites.Domain.Entities.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FitBites.Infrastructure.Data.Configurations.Base
{
    /// <summary>
    /// 实体配置基类
    /// </summary>
    /// <typeparam name="TEntity">实体类型</typeparam>
    public abstract class EntityTypeConfigurationBase<TEntity> : IEntityTypeConfiguration<TEntity> where TEntity : EntityBase
    {
        public virtual void Configure(EntityTypeBuilder<TEntity> builder)
        {
            // 配置主键
            builder.HasKey(e => e.Id);

            // 配置主键使用GUID
            builder.Property(e => e.Id)
                .ValueGeneratedOnAdd();

            // 配置创建时间和更新时间
            builder.Property(e => e.CreatedAt)
                .IsRequired();

            builder.Property(e => e.UpdatedAt)
                .IsRequired();
        }
    }
} 