using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Application.Data.Configurations;

public sealed class TeamCategoryConfiguration : IEntityTypeConfiguration<TeamCategory>
{
    public void Configure(EntityTypeBuilder<TeamCategory> builder)
    {
        builder.HasKey(x => x.Id);

        builder.OwnsOne(
            s => s.Description,
            d => d.Property(x => x.Value));
    }
}
