using Domain;
using Microsoft.EntityFrameworkCore;

namespace Application.Data;

public interface ISkillsMatrixDbContext
{
	DbSet<HardSkill> HardSkills { get; set; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
