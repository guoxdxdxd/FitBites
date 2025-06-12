using FitBites.Domain.Entities;
using FitBites.Infrastructure.Data.Configurations.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FitBites.Infrastructure.Data.Configurations
{
    /// <summary>
    /// 烹饪方式字典实体配置
    /// </summary>
    public class CookingMethodDictConfiguration : EntityTypeConfigurationBase<CookingMethodDict>
    {
        public override void Configure(EntityTypeBuilder<CookingMethodDict> builder)
        {
            base.Configure(builder);

            // 表名设置
            builder.ToTable("CookingMethodDicts");

            // 字段配置
            builder.Property(c => c.Code)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(c => c.Description)
                .HasMaxLength(200);

            builder.Property(c => c.Status)
                .IsRequired();

            // 配置关系
            builder.HasMany(c => c.Recipes)
                .WithOne(r => r.CookingMethod)
                .HasForeignKey(r => r.CookingMethodId)
                .OnDelete(DeleteBehavior.Restrict);

            // 索引配置
            builder.HasIndex(c => c.Code).IsUnique();
            builder.HasIndex(c => c.Name);
            builder.HasIndex(c => c.Status);
            builder.HasIndex(c => c.SortOrder);
        }
    }
} 