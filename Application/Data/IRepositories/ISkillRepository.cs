using Application.DTOs.SkillDTOs;

namespace Application.Data.IRepositories;

public interface ISkillRepository
{
    Task<SkillGetDTO?> GetById(Guid id, CancellationToken cancelationToken);
    Task<List<SkillGetDTO>> GetAll(CancellationToken cancellationToken);
    void Add(SkillCreateDTO entity);
    void Update(SkillUpdateDTO entity);
    void SoftDelete(SkillDeleteDTO entity);
}