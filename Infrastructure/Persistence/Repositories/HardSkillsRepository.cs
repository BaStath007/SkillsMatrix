using Application.Data;
using Application.Data.IRepositories;
using Application.DTOs;
using Application.Mapping;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories
{
    public class HardSkillsRepository : IHardSkillsRepository
    {
        private readonly ISkillsMatrixDbContext _context;

        public HardSkillsRepository(SkillsMatrixDbContext context)
        {
            _context = context;
        }

        public void Add(HardSkillCreateDTO entity)
        {
            _context.HardSkills.Add(HardSkillExtensions.CreateToDomain(entity));
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<HardSkillGetDTO>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<HardSkillGetDTO> GetById(int id, CancellationToken cancellationToken)
        {
            var hardSkill = await _context.HardSkills.FirstOrDefaultAsync(hs => hs.Id == id, cancellationToken);
            return HardSkillExtensions.GetToApplication(hardSkill);
        }

        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
            return await _context.SaveChangesAsync(cancellationToken); 
        }

        public void Update(HardSkillUpdateDTO entity)
        {
            _context.HardSkills.Update(HardSkillExtensions.UpdateToDomain(entity));
        }
    }
}