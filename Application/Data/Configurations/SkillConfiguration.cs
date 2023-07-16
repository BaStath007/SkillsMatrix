using Domain.Entities;
using Domain.Entities.JoinEntities;
using Domain.Enums;
using Domain.Primitives;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Application.Data.Configurations;

public sealed class SkillConfiguration : IEntityTypeConfiguration<Skill>
{
    public void Configure(EntityTypeBuilder<Skill> builder)
    {
        builder.HasKey(x => x.Id);

        builder.HasOne(x => x.ParentSkill)
            .WithMany();

        builder.HasMany(x => x.ChildrenSkills)
            .WithOne()
            .HasForeignKey(x => x.ParentSkillId);

        builder.HasMany(x => x.Employees)
            .WithMany(x => x.Skills)
            .UsingEntity<EmployeeSkill>(
            x => x.HasOne<Employee>()
            .WithMany()
            .HasForeignKey(x => x.EmployeeId),
            x => x.HasOne<Skill>()
            .WithMany()
            .HasForeignKey(x => x.SkillId),
            x => x.HasKey(e => new { e.EmployeeId, e.SkillId }));

        builder.HasMany(x => x.Positions)
            .WithMany(x => x.Skills)
            .UsingEntity<PositionSkill>(
            x => x.HasOne<Position>()
            .WithMany()
            .HasForeignKey(x => x.PositionId),
            x => x.HasOne<Skill>()
            .WithMany()
            .HasForeignKey(x => x.SkillId),
            x => x.HasKey(e => new { e.PositionId, e.SkillId }));

        builder.HasMany(x => x.SkillCategories)
            .WithMany(x => x.Skills)
            .UsingEntity<CategoryPerSkill>(
            x => x.HasOne<SkillCategory>()
            .WithMany()
            .HasForeignKey(x => x.SkillCategoryId),
            x => x.HasOne<Skill>()
            .WithMany()
            .HasForeignKey(x => x.SkillId),
            x => x.HasKey(e => new { e.SkillCategoryId, e.SkillId }));

        builder.OwnsOne(
            s => s.Description,
            d => d.Property(x => x.Value));

        builder.Property<SkillType>("SkillType")
            .HasConversion(
                st => st.Name,
                st => Enumeration<SkillType>.FromName(st)!);
    }
}
