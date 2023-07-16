using Domain.Entities;
using Domain.Entities.JoinEntities;
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
            .WithOne()
            .HasForeignKey(x => x.ParentTeamId);

        builder.HasMany(x => x.Positions)
            .WithMany(x => x.Teams)
            .UsingEntity<TeamPosition>(
            x => x.HasOne<Position>()
            .WithMany()
            .HasForeignKey(x => x.PositionId),
            x => x.HasOne<Team>()
            .WithMany()
            .HasForeignKey(x => x.TeamId),
            x => x.HasKey(e => new { e.TeamId, e.PositionId }));

        builder.HasMany(x => x.TeamCategories)
            .WithMany(x => x.Teams)
            .UsingEntity<CategoryPerTeam>(
            x => x.HasOne<TeamCategory>()
            .WithMany()
            .HasForeignKey(x => x.TeamCategoryId),
            x => x.HasOne<Team>()
            .WithMany()
            .HasForeignKey(x => x.TeamId),
            x => x.HasKey(e => new { e.TeamId, e.TeamCategoryId }));

        builder.OwnsOne(
            s => s.Description,
            d => d.Property(x => x.Value));

        builder.Property(t => t.TeamType)
            .HasConversion(
                tt => tt.Name,
                tt => Enumeration<TeamType>.FromName(tt)!);
    }
}