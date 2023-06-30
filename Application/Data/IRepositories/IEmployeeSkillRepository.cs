using Application.DTOs.EmployeeSkillDTOs;
using Microsoft.AspNetCore.Routing.Matching;

namespace Application.Data.IRepositories;

public interface IEmployeeSkillRepository
{
    Task<List<EmployeeSkillGetDTO>> GetSkillsByEmployeeId(Guid employeeId, CancellationToken cancellationToken);
    void AddEmployeeSkills(Guid employeeId, ICollection<EmployeeSkillCreateDTO> employeeSkillCreateDTOs);
    void UpdateEmployeeSkills(Guid employeeId, ICollection<EmployeeSkillGetDTO> employeeSkillGetDTOs, ICollection<EmployeeSkillAddOrUpdateDTO> employeeSkillUpdateDTOs);
}
