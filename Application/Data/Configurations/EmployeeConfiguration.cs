using Domain.Entities;
using Domain.Shared;
using Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Application.Data.Configurations;

public sealed class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
{
    public void Configure(EntityTypeBuilder<Employee> builder)
    {
        builder.HasKey(x => x.Id);

        builder.OwnsOne(
            e => e.Age,
            a => a.Property(x => x.Value));

        builder.OwnsOne(
            e => e.FirstName,
            fn => fn.Property(x => x.Value));

        builder.Property(e => e.EmployeeMiddleName)
            .HasConversion(
                o => o.Map(mn => mn.Value).Reduce(MiddleName.Create(string.Empty)!.Data.Value),
                o => Option<MiddleName>.Some(MiddleName.Create(o)!.Data).Map(mn => mn));

        builder.OwnsOne(
            e => e.LastName,
            ln => ln.Property(x => x.Value));

        builder.OwnsOne(
            e => e.Email,
            em => em.Property(x => x.Value));
    }
}
