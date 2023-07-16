using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Application.Data.Configurations;

public sealed class SkillCategoryConfiguration : IEntityTypeConfiguration<SkillCategory>
{
    public void Configure(EntityTypeBuilder<SkillCategory> builder)
    {
        builder.HasKey(x => x.Id);

        builder.OwnsOne(
            s => s.Description,
            d => d.Property(x => x.Value));
    }
}
