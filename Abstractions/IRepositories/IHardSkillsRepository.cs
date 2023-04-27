using Domain;

namespace Abstractions.IRepositories;

public interface IHardSkillsRepository
{
    Task<HardSkill> GetById(int id);
    Task<List<HardSkill>> GetAll();
    void Add(HardSkill entity);
    void Update(HardSkill entity);
    void Delete(int id);
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}