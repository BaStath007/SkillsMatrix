using Domain.Entities.JoinEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Application.Data.Configurations.JointEntities;

public sealed class TeamPositionConfiguration : IEntityTypeConfiguration<TeamPosition>
{
    public void Configure(EntityTypeBuilder<TeamPosition> builder)
    {
        // Configure the primary key
        builder.HasKey(x => new { x.TeamId, x.PositionId });

        // Configure the relationship to the 'Team' entity
        builder.HasOne(χ => χ.Team)
            .WithMany()
            .HasForeignKey(χ => χ.TeamId);

        // Configure the relationship to the 'Position' entity
        builder.HasOne(χ => χ.Position)
            .WithMany()
            .HasForeignKey(χ => χ.PositionId);
    }
}
