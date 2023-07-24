using Domain.Entities.JoinEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Application.Data.Configurations.JointEntities;

public sealed class RolePermissionConfiguration : IEntityTypeConfiguration<RolePermission>
{
    public void Configure(EntityTypeBuilder<RolePermission> builder)
    {
        builder.HasKey(x => new { x.RoleId, x.PermissionId });

        // Configure the relationship to the 'Role' entity
        builder.HasOne(χ => χ.Role)
            .WithMany()
            .HasForeignKey(χ => χ.RoleId);

        // Configure the relationship to the 'Permission' entity
        builder.HasOne(χ => χ.Permission)
            .WithMany()
            .HasForeignKey(χ => χ.PermissionId);
    }
}
