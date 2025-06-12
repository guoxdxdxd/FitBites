using FitBites.Domain.Entities;
using FitBites.Infrastructure.Data.Configurations.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FitBites.Infrastructure.Data.Configurations
{
    /// <summary>
    /// 家庭成员实体配置
    /// </summary>
    public class FamilyMemberConfiguration : EntityTypeConfigurationBase<FamilyMember>
    {
        public override void Configure(EntityTypeBuilder<FamilyMember> builder)
        {
            base.Configure(builder);

            // 表名设置
            builder.ToTable("FamilyMembers");

            // 字段配置
            builder.Property(m => m.FamilyId)
                .IsRequired();

            builder.Property(m => m.UserId)
                .IsRequired();

            builder.Property(m => m.MemberRole)
                .IsRequired();

            builder.Property(m => m.JoinedAt)
                .IsRequired();

            // 外键配置
            builder.HasOne(m => m.Family)
                .WithMany(f => f.Members)
                .HasForeignKey(m => m.FamilyId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(m => m.User)
                .WithMany(u => u.FamilyMemberships)
                .HasForeignKey(m => m.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            // 索引配置
            builder.HasIndex(m => m.FamilyId);
            builder.HasIndex(m => m.UserId);
            builder.HasIndex(m => m.MemberRole);
            builder.HasIndex(m => new { m.FamilyId, m.UserId }).IsUnique();
        }
    }
}