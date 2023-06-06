using Application.DTOs;

namespace Application.Data.IRepositories;

public interface ISkillsRepository
{
    Task<SkillGetDTO?> GetById(Guid id, CancellationToken cancelationToken);
    Task<List<SkillGetDTO>> GetAll(CancellationToken cancellationToken);
    void Add(SkillCreateDTO entity);
    void Update(SkillUpdateDTO entity);
    void SoftDelete(SkillDeleteDTO entity);
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}