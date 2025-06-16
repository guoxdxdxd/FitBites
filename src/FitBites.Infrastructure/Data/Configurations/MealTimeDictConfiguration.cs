using FitBites.Domain.Entities;
using FitBites.Infrastructure.Data.Configurations.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FitBites.Infrastructure.Data.Configurations
{
    /// <summary>
    /// 餐次字典实体配置
    /// </summary>
    public class MealTimeDictConfiguration : EntityTypeConfigurationBase<MealTimeDict>
    {
        public override void Configure(EntityTypeBuilder<MealTimeDict> builder)
        {
            base.Configure(builder);

            // 表名设置
            builder.ToTable("MealTimeDicts");

            // 字段配置
            builder.Property(m => m.Code)
                .IsRequired()
                .HasMaxLength(20);

            builder.Property(m => m.Name)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(m => m.Description)
                .HasMaxLength(200);

            // 软删除字段
            builder.Property(m => m.IsDeleted)
                .IsRequired();

            // 索引配置
            builder.HasIndex(m => m.Code).IsUnique();
            builder.HasIndex(m => m.Name);
        }
    }
} 