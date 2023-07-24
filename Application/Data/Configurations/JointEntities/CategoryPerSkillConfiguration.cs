using Domain.Entities.JoinEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Application.Data.Configurations.JointEntities;

public sealed class CategoryPerSkillConfiguration : IEntityTypeConfiguration<CategoryPerSkill>
{
    public void Configure(EntityTypeBuilder<CategoryPerSkill> builder)
    {
        // Configure the primary key
        builder.HasKey(x => new { x.SkillId, x.SkillCategoryId });

        // Configure the relationship to the 'Skill' entity
        builder.HasOne(χ => χ.Skill)
            .WithMany()
            .HasForeignKey(χ => χ.SkillId);

        // Configure the relationship to the 'SkillCategory' entity
        builder.HasOne(χ => χ.SkillCategory)
            .WithMany()
            .HasForeignKey(χ => χ.SkillCategoryId);
    }
}
