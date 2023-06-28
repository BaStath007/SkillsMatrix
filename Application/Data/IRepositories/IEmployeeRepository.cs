using Application.DTOs.EmployeeDTOs;

namespace Application.Data.IRepositories;

public interface IEmployeeRepository
{
    Task<EmployeeGetDTO?> GetById(Guid id, CancellationToken cancelationToken);
    Task<List<EmployeeGetDTO>> GetAll(CancellationToken cancellationToken);
    Guid Add(EmployeeCreateDTO employeeDTO);
    void AddEmployeeSkills(Guid employeeId, ICollection<Guid> skillIds);
    void Update(EmployeeUpdateDTO employeeDTO);
    void SoftDelete(EmployeeDeleteDTO employeeDTO);
}