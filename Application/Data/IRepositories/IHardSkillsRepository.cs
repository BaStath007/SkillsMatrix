using Application.DTOs;

namespace Application.Data.IRepositories;

public interface IHardSkillsRepository
{
    Task<HardSkillGetDTO?> GetById(int id, CancellationToken cancelationToken);
    Task<List<HardSkillGetDTO>> GetAll(CancellationToken cancellationToken);
    void Add(HardSkillCreateDTO entity);
    void Update(HardSkillUpdateDTO entity);
    void Delete(int id);
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}