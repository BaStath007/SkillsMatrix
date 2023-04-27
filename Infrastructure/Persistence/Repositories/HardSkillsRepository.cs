using Application.Data;
using Application.Data.IRepositories;
using Domain;

namespace Infrastructure.Persistence.Repositories
{
    public class HardSkillsRepository : IHardSkillsRepository
    {
        private readonly ISkillsMatrixDbContext _context;

        public HardSkillsRepository(SkillsMatrixDbContext context)
        {
            _context = context;
        }

        public void Add(HardSkill entity)
        {
            _context.HardSkills.Add(entity);
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<HardSkill>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<HardSkill> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public void Update(HardSkill entity)
        {
            throw new NotImplementedException();
        }
    }
}