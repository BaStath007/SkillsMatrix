using Domain.Entities.JoinEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Application.Data.Configurations.JointEntities;

public sealed class PositionSkillConfiguration : IEntityTypeConfiguration<PositionSkill>
{
    public void Configure(EntityTypeBuilder<PositionSkill> builder)
    {
        // Configure the primary key
        builder.HasKey(x => new { x.PositionId, x.SkillId });

        // Configure the relationship to the 'Position' entity
        builder.HasOne(χ => χ.Position)
            .WithMany()
            .HasForeignKey(χ => χ.PositionId);

        // Configure the relationship to the 'Skill' entity
        builder.HasOne(χ => χ.Skill)
            .WithMany()
            .HasForeignKey(χ => χ.SkillId);
    }
}
