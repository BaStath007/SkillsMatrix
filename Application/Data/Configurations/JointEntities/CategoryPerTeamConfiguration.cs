using Domain.Entities.JoinEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Application.Data.Configurations.JointEntities;

public sealed class CategoryPerTeamConfiguration : IEntityTypeConfiguration<CategoryPerTeam>
{
    public void Configure(EntityTypeBuilder<CategoryPerTeam> builder)
    {
        // Configure the primary key
        builder.HasKey(x => new { x.TeamId, x.TeamCategoryId });

        // Configure the relationship to the 'Team' entity
        builder.HasOne(χ => χ.Team)
            .WithMany()
            .HasForeignKey(χ => χ.TeamId);

        // Configure the relationship to the 'TeamCategory' entity
        builder.HasOne(χ => χ.TeamCategory)
            .WithMany()
            .HasForeignKey(χ => χ.TeamCategoryId);
    }
}
