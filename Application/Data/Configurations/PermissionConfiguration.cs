using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Application.Data.Configurations;

public sealed class PermissionConfiguration : IEntityTypeConfiguration<Permission>
{
    public void Configure(EntityTypeBuilder<Permission> builder)
    {
        // Configure the primary key
        builder.HasKey(x => x.Id);

        IEnumerable<Permission> permissions = Permission.GetValues()
            .Select(x => Permission.Create(x.Value.ToString()!));

        builder.HasData(permissions);
    }
}
