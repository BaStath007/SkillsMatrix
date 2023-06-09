using Application.DTOs.EmployeeDTOs;

namespace Application.Data.IRepositories;

public interface IEmployeeRepository
{
    Task<EmployeeGetDTO?> GetById(Guid id, CancellationToken cancelationToken);
    Task<List<EmployeeGetDTO>> GetAll(CancellationToken cancellationToken);
    void Add(EmployeeCreateDTO entity);
    void Update(EmployeeUpdateDTO entity);
    void SoftDelete(EmployeeDeleteDTO entity);
}