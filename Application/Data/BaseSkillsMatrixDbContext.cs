using Domain;
using Microsoft.EntityFrameworkCore;

namespace Application.Data;

public class BaseSkillsMatrixDbContext : DbContext, ISkillsMatrixDbContext
{
    public DbSet<HardSkill> HardSkills { get; set; }
    public DbSet<HardSkillCategory> HardSkillCategories { get; set; }

    public BaseSkillsMatrixDbContext(DbContextOptions<BaseSkillsMatrixDbContext> options)
        : base(options)
    {
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return base.SaveChangesAsync(cancellationToken);
    }
}
