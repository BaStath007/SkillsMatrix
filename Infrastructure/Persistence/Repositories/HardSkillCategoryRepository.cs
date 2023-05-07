using Application.Data;
using Application.Data.IRepositories;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories;

public class HardSkillCategoryRepository : IHardSkillCategoryRepository
{
    private readonly ISkillsMatrixDbContext _context;

    public HardSkillCategoryRepository(SkillsMatrixDbContext context)
    {
        _context = context;
    }
    public void Add(HardSkillCategory entity)
    {
        _context.HardSkillCategories.Add(entity);
    }

    public void Delete(HardSkillCategory entity)
    {
        throw new NotImplementedException();
    }

    public Task<List<HardSkillCategory>> GetAll(CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public async Task<HardSkillCategory?> GetById(int id, CancellationToken cancellationToken)
    {
        var hsCategory = await _context.HardSkillCategories.AsNoTracking().Include(c => c.HardSkills)
            .FirstOrDefaultAsync(c => c.Id == id, cancellationToken);
        return hsCategory;
    }

    public Task<int> SaveChangesAsync(CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public void Update(HardSkillCategory entity)
    {
        throw new NotImplementedException();
    }
}
