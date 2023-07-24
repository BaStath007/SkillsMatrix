using Domain.Entities.JoinEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Application.Data.Configurations.JointEntities;

public sealed class EmployeeSkillConfiguration : IEntityTypeConfiguration<EmployeeSkill>
{
    public void Configure(EntityTypeBuilder<EmployeeSkill> builder)
    {
        // Configure the primary key
        builder.HasKey(x => new { x.EmployeeId, x.SkillId });

        // Configure the relationship to the 'Employee' entity
        builder.HasOne(χ => χ.Employee)
            .WithMany()
            .HasForeignKey(χ => χ.EmployeeId);

        // Configure the relationship to the 'Skill' entity
        builder.HasOne(χ => χ.Skill)
            .WithMany()
            .HasForeignKey(χ => χ.SkillId);
    }
}
