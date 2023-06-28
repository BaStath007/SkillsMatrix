﻿using Application.Data;
using Application.Data.IRepositories;
using Application.DTOs.SkillDTOs;
using Application.Mapping;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories
{
    public class SkillsRepository : ISkillRepository
    {
        private readonly ISkillsMatrixDbContext _context;
        public SkillsRepository(SkillsMatrixDbContext context)
        {
            _context = context;
        }

        public async Task<SkillGetDTO?> GetById(Guid id, CancellationToken cancellationToken)
        {
            var skill = await _context.Skills.AsNoTracking().Include(s => s.Description)
                .Include(s => s.ParentSkill).Include(s => s.ChildrenSkills)
                .Include(s => s.EmployeeSkills).Include(s => s.RoleSkills)
                .Include(s => s.CategoriesPerSkill)
                .FirstOrDefaultAsync(s => s.Id == id, cancellationToken);
            return SkillExtensions.GetSkillToApplication(skill);
        }

        public async Task<List<SkillGetDTO>> GetAll(CancellationToken cancellationToken)
        {
            var skills = await _context.Skills.Include(s => s.EmployeeSkills).ToListAsync(cancellationToken);
            return SkillExtensions.GetAllSkillsToApplication(skills);
        }

        public void Add(SkillCreateDTO entity)
        {
            _context.Skills.Add(SkillExtensions.CreateToDomain(entity));
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
}