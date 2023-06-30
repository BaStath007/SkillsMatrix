using Application.Data;
using Application.Data.IRepositories;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories;

public sealed class SkillCategoryRepository : ISkillCategoryRepository
{
    private readonly ISkillsMatrixDbContext _context;

    public SkillCategoryRepository(SkillsMatrixDbContext context)
    {
        _context = context;
    }

    public async Task<SkillCategory?> GetById(Guid id, CancellationToken cancellationToken)
    {
        var category = await _context.SkillCategories.AsNoTracking()
            .FirstOrDefaultAsync(c => c.Id == id, cancellationToken);
        return category;
    }

    public Task<List<SkillCategory>> GetAll(CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public void Add(SkillCategory entity)
    {
        _context.SkillCategories.Add(entity);
    }

    public void Update(SkillCategory entity)
    {
        throw new NotImplementedException();
    }

    public void SoftDelete(SkillCategory entity)
    {
        throw new NotImplementedException();
    }
}
