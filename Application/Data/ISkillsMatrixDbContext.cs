using Domain;
using Microsoft.EntityFrameworkCore;

namespace Application.Data;

public interface ISkillsMatrixDbContext
{
    public DbSet<HardSkill> HardSkills { get; set; }
    public DbSet<HardSkillCategory> HardSkillCategories { get; set; }
    public Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
