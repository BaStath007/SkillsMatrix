using Application.Data;
using Application.Data.IRepositories;
using Application.DTOs;
using Application.Mapping;

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
            _context.HardSkills.Add(HardSkillExtensions.ToDomain(entity));
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<HardSkillGetDTO>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<HardSkillGetDTO> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
            return await _context.SaveChangesAsync(cancellationToken); 
        }

        public void Update(HardSkillUpdateDTO entity)
        {
            throw new NotImplementedException();
        }
    }
}