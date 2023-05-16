using Application.Data;
using Application.Data.IRepositories;
using Application.DTOs;
using Application.Mapping;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories
{
    public class SkillsRepository : ISkillsRepository
    {
        private readonly ISkillsMatrixDbContext _context;

        public SkillsRepository(SkillsMatrixDbContext context)
        {
            _context = context;
        }

        public async Task<SkillGetDTO?> GetById(Guid id, CancellationToken cancellationToken)
        {
            var skill = await _context.Skills.AsNoTracking()
                .FirstOrDefaultAsync(hs => hs.Id == id, cancellationToken);
            return HardSkillExtensions.GetSkillToApplication(skill);
        }

        public async Task<List<SkillGetDTO>> GetAll(CancellationToken cancellationToken)
        {
            var hardSkills = await _context.Skills.ToListAsync(cancellationToken);
            return HardSkillExtensions.GetAllSkillsToApplication(hardSkills);
        }

        public void Add(SkillCreateDTO entity)
        {
            _context.Skills.Add(HardSkillExtensions.CreateToDomain(entity));
        }
        
        public void Update(SkillUpdateDTO entity)
        {
            _context.Skills.Update(HardSkillExtensions.UpdateToDomain(entity));
        }

        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
            return await _context.SaveChangesAsync(cancellationToken); 
        }
    }
}