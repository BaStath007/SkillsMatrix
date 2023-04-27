using Domain;
using Microsoft.EntityFrameworkCore;

namespace Application.Data;

public interface ISkillsMatrixDbContext
{
	DbSet<HardSkill> HardSkills { get; set; }
}
