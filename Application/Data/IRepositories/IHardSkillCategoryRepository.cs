using Application.DTOs;
using Domain;

namespace Application.Data.IRepositories;

public interface IHardSkillCategoryRepository
{
    Task<HardSkillCategory?> GetById(int id, CancellationToken cancellationToken);
    Task<List<HardSkillCategory>> GetAll(CancellationToken cancellationToken);
    void Add(HardSkillCategory entity);
    void Update(HardSkillCategory entity);
    void Delete(HardSkillCategory entity);
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
