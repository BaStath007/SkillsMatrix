using Application.DTOs.EmployeeSkillDTOs;
using Domain.Entities;

namespace Application.Data.IRepositories;

public interface IEmployeeSkillRepository
{
    Task<List<EmployeeSkillGetDTO>> GetSkillsByEmployeeId(
        Guid employeeId,
        ICollection<Skill> skills,
        CancellationToken cancellationToken);

    void AddEmployeeSkills(
        Guid employeeId,
        ICollection<EmployeeSkillCreateDTO> employeeSkillCreateDTOs);

    void UpdateEmployeeSkills(
        Guid employeeId,
        ICollection<EmployeeSkillGetDTO> employeeSkillGetDTOs,
        ICollection<EmployeeSkillAddOrUpdateDTO> employeeSkillUpdateDTOs);
}
