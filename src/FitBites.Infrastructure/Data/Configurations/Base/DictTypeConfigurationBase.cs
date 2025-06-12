using FitBites.Domain.Entities.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FitBites.Infrastructure.Data.Configurations.Base
{
    /// <summary>
    /// 字典类型配置基类
    /// </summary>
    /// <typeparam name="TEntity">实体类型</typeparam>
    public abstract class DictTypeConfigurationBase<TEntity> : EntityTypeConfigurationBase<TEntity> where TEntity : EntityBase
    {
        public override void Configure(EntityTypeBuilder<TEntity> builder)
        {
            base.Configure(builder);

            // 公共字段配置
            builder.Property("Code")
                .IsRequired()
                .HasMaxLength(64);

            builder.Property("Name")
                .IsRequired()
                .HasMaxLength(128);

            builder.Property("Description")
                .HasMaxLength(500);

            // 公共索引配置
            builder.HasIndex("Code")
                .IsUnique();
        }
    }
} 