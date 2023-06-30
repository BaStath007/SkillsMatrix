using Application.DTOs.EmployeeDTOs;
using Application.DTOs.EmployeeSkillDTOs;

namespace Application.Data.IRepositories;

public interface IEmployeeRepository
{
    Task<EmployeeGetDTO?> GetById(Guid id, CancellationToken cancelationToken);
    Task<List<EmployeeGetDTO>> GetAll(CancellationToken cancellationToken);
    Guid Add(EmployeeCreateDTO employeeDTO);
    Guid Update(EmployeeUpdateDTO employeeDTO);
    void SoftDelete(EmployeeDeleteDTO employeeDTO);
}