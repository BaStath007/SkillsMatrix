using Application.Data;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence;

public class SkillsMatrixDbContext : DbContext, ISkillsMatrixDbContext
{
    public DbSet<HardSkill> HardSkills { get; set; }

    public SkillsMatrixDbContext(DbContextOptions<SkillsMatrixDbContext> options)
        :base(options)
    {
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return base.SaveChangesAsync(cancellationToken);
    }
}
