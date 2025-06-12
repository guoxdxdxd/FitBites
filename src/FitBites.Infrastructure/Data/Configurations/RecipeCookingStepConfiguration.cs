using FitBites.Domain.Entities;
using FitBites.Infrastructure.Data.Configurations.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FitBites.Infrastructure.Data.Configurations
{
    /// <summary>
    /// 烹饪步骤实体配置
    /// </summary>
    public class RecipeCookingStepConfiguration : EntityTypeConfigurationBase<RecipeCookingStep>
    {
        public override void Configure(EntityTypeBuilder<RecipeCookingStep> builder)
        {
            base.Configure(builder);

            // 表名设置
            builder.ToTable("RecipeCookingSteps");

            // 字段配置
            builder.Property(s => s.RecipeId)
                .IsRequired();

            builder.Property(s => s.StepNumber)
                .IsRequired();

            builder.Property(s => s.Title)
                .HasMaxLength(100)
                .IsRequired(false);

            builder.Property(s => s.Description)
                .HasMaxLength(500)
                .IsRequired(false);

            builder.Property(s => s.ImageUrl)
                .HasMaxLength(256)
                .IsRequired(false);

            builder.Property(s => s.VideoUrl)
                .HasMaxLength(256)
                .IsRequired(false);

            builder.Property(s => s.IngredientRefs)
                .HasMaxLength(500)
                .IsRequired(false);

            builder.Property(s => s.ActionType)
                .HasMaxLength(50)
                .IsRequired(false);

            builder.Property(s => s.TemperatureDesc)
                .HasMaxLength(50)
                .IsRequired(false);

            builder.Property(s => s.AiInstruction)
                .HasMaxLength(500)
                .IsRequired(false);

            // 外键配置
            builder.HasOne(s => s.Recipe)
                .WithMany(r => r.CookingSteps)
                .HasForeignKey(s => s.RecipeId)
                .OnDelete(DeleteBehavior.Cascade);

            // 索引配置
            builder.HasIndex(s => s.RecipeId);
            builder.HasIndex(s => new { s.RecipeId, s.StepNumber }).IsUnique();
        }
    }
} 