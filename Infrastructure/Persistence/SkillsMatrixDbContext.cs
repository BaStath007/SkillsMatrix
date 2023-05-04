using Application.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence;

public class SkillsMatrixDbContext : BaseSkillsMatrixDbContext
{
    public SkillsMatrixDbContext(DbContextOptions<BaseSkillsMatrixDbContext> options)
        :base(options)
    {
    }
}
