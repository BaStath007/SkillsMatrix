using Application.Data.IRepositories;
using Application.Exceptions;
using Application.Queries.Common;
using Domain.Shared;

namespace Application.Queries.Employees.GetAllEmployees;

public sealed class GetAllEmployeesQueryHandler : IQueryHandler<GetAllEmployeesQuery, GetAllEmployeesResponse>
{
    private readonly IEmployeeRepository _employeeRepository;

    public GetAllEmployeesQueryHandler(IEmployeeRepository employeeRepository)
    {
        _employeeRepository = employeeRepository;
    }

    public async Task<Result<GetAllEmployeesResponse>> Handle(GetAllEmployeesQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var employees = await _employeeRepository.GetAll(cancellationToken);
            if (employees == null)
            {
                return new Error(
                            "Employee.NullReference",
                            $"A error occured while trying to retrieve the employees from the database." +
                                $"\nPlease try again later.");
            }
            var response = new GetAllEmployeesResponse(employees);
            
            return response;
        }
        catch (BadRequestException ex)
        {
            return ex.Error;
        }
    }
}
