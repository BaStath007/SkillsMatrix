using Domain.Entities;
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
            .WithOne();

        builder.OwnsOne(
            s => s.Description,
            d => d.Property(x => x.Value));

        builder.Property<SkillType>("SkillType")
            .HasConversion(
                st => st.Name,
                st => Enumeration<SkillType>.FromName(st)!);
    }
}
