using Application.Data.IRepositories;
using Application.DTOs.EmployeeDTOs;

namespace Infrastructure.Persistence.Repositories;

public class EmployeeRepository : IEmployeeRepository
{
    public void Add(EmployeeCreateDTO entity)
    {
        throw new NotImplementedException();
    }

    public Task<List<EmployeeGetDTO>> GetAll(CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<EmployeeGetDTO?> GetById(Guid id, CancellationToken cancelationToken)
    {
        throw new NotImplementedException();
    }

    public void SoftDelete(EmployeeDeleteDTO entity)
    {
        throw new NotImplementedException();
    }

    public void Update(EmployeeUpdateDTO entity)
    {
        throw new NotImplementedException();
    }
}
