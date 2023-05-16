using Application.Data;
using Application.Data.IRepositories;
using Domain;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories;

public class SkillCategoryRepository : ISkillCategoryRepository
{
    private readonly ISkillsMatrixDbContext _context;

    public SkillCategoryRepository(SkillsMatrixDbContext context)
    {
        _context = context;
    }
    public void Add(SkillCategory entity)
    {
        _context.SkillCategories.Add(entity);
    }

    public void Delete(SkillCategory entity)
    {
        throw new NotImplementedException();
    }

    public Task<List<SkillCategory>> GetAll(CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public async Task<SkillCategory?> GetById(Guid id, CancellationToken cancellationToken)
    {
        var hsCategory = await _context.SkillCategories.AsNoTracking()
            .FirstOrDefaultAsync(c => c.Id == id, cancellationToken);
        return hsCategory;
    }

    public Task<int> SaveChangesAsync(CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public void Update(SkillCategory entity)
    {
        throw new NotImplementedException();
    }
}
