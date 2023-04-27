using Application.Data;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence;

public class SkillsMatrixDbContext : DbContext, ISkillsMatrixDbContext
{
    public DbSet<HardSkill> HardSkills { get; set; }

    public SkillsMatrixDbContext(DbContextOptions options)
        :base(options)
    {
    }
}
