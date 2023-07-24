using Domain.Entities;
using Domain.Enums;
using Domain.Primitives;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Application.Data.Configurations;

public sealed class TeamConfiguration : IEntityTypeConfiguration<Team>
{
    public void Configure(EntityTypeBuilder<Team> builder)
    {
        builder.HasKey(x => x.Id);

        builder.HasOne(x => x.ParentTeam)
            .WithMany();

        builder.HasMany(x => x.ChildrenTeams)
            .WithOne();

        builder.OwnsOne(
            s => s.Description,
            d => d.Property(x => x.Value));

        builder.Property(t => t.TeamType)
            .HasConversion(
                tt => tt.Name,
                tt => Enumeration<TeamType>.FromName(tt)!);
    }
}