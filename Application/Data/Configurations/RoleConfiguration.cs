using Domain.Entities;
using Domain.Entities.JoinEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Application.Data.Configurations;

public sealed class RoleConfiguration : IEntityTypeConfiguration<Role>
{
    public void Configure(EntityTypeBuilder<Role> builder)
    {
        // Configure the primary key
        builder.HasKey(x => x.Id);
        
        IEnumerable<Role> roles = Role.GetValues()
            .Select(x => Role.Create(x.Value.ToString()!));

        builder.HasData(roles);
    }
}
