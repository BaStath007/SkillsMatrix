using Domain.Entities;

namespace Application.Data.IRepositories;

public interface ISkillCategoryRepository
{
    Task<SkillCategory?> GetById(Guid id, CancellationToken cancellationToken);
    Task<List<SkillCategory>> GetAll(CancellationToken cancellationToken);
    void Add(SkillCategory entity);
    void Update(SkillCategory entity);
    void Delete(SkillCategory entity);
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
