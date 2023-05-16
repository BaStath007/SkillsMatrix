using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Data;

public class BaseSkillsMatrixDbContext : DbContext, ISkillsMatrixDbContext
{
    public DbSet<Skill> Skills { get; set; }
    public DbSet<SkillCategory> SkillCategories { get; set; }

    public BaseSkillsMatrixDbContext(DbContextOptions<BaseSkillsMatrixDbContext> options)
        : base(options)
    {
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return base.SaveChangesAsync(cancellationToken);
    }
}
