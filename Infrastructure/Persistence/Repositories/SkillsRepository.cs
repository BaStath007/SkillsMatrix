using Application.Data;
using Application.Data.IRepositories;
using Application.DTOs.SkillDTOs;
using Application.Mapping;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories;

public sealed class SkillsRepository : ISkillRepository
{
    private readonly ISkillsMatrixDbContext _context;
    public SkillsRepository(SkillsMatrixDbContext context)
    {
        _context = context;
    }

    public async Task<SkillGetDTO?> GetById(Guid id, CancellationToken cancellationToken)
    {
        var skill = await _context.Skills.AsNoTracking().Include(s => s.Description)
            .Include(s => s.ChildrenSkills)
            .Include(s => s.Employees)
            .Include(s => s.Positions)
            .Include(s => s.SkillCategories)
            .FirstOrDefaultAsync(s => s.Id == id, cancellationToken);

        return SkillExtensions.GetSkillToApplication(skill);
    }

    public async Task<List<SkillGetDTO>> GetAll(CancellationToken cancellationToken)
    {
        var skills = await _context.Skills
            .Include(s => s.Employees)
            .ToListAsync(cancellationToken);

        return SkillExtensions.GetAllSkillsToApplication(skills);
    }

    public Guid Add(SkillCreateDTO entity)
    {
        var skill = SkillExtensions.CreateToDomain(entity);

        _context.Skills.Add(skill);

        return skill.Id;
    }
    
    public void Update(SkillUpdateDTO entity)
    {
        _context.Skills.Update(SkillExtensions.UpdateToDomain(entity));
    }

    public void SoftDelete(SkillDeleteDTO entity)
    {
        _context.Skills.Update(SkillExtensions.DeleteToDomain(entity));
    }
}