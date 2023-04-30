using Application.DTOs;

namespace Application.Data.IRepositories;

public interface IHardSkillsRepository
{
    Task<HardSkillGetDTO> GetById(int id);
    Task<List<HardSkillGetDTO>> GetAll();
    void Add(HardSkillCreateDTO entity);
    void Update(HardSkillUpdateDTO entity);
    void Delete(int id);
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}