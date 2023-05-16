using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Data;

public interface ISkillsMatrixDbContext
{
    public DbSet<Skill> Skills { get; set; }
    public DbSet<SkillCategory> SkillCategories { get; set; }
    public Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
