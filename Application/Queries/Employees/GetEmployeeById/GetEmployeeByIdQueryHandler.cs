using Application.Data.IRepositories;
using Application.Exceptions;
using Application.Queries.Common;
using Domain.Shared;

namespace Application.Queries.Employees.GetEmployeeById;

public sealed class GetEmployeeByIdQueryHandler : IQueryHandler<GetEmployeeByIdQuery, GetEmployeeByIdResponse>
{
    private readonly IEmployeeRepository _employeeRepository;

    public GetEmployeeByIdQueryHandler(IEmployeeRepository employeeRepository)
    {
        _employeeRepository = employeeRepository;
    }

    public async Task<Result<GetEmployeeByIdResponse>> Handle(GetEmployeeByIdQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var employee = await _employeeRepository.GetById(request.Id, cancellationToken);
            if (employee == null)
            {
                return new Error(
                            "Employee.NotFound",
                            $"The requested employee with Id: {request.Id} was not found.");
            }

            var response = new GetEmployeeByIdResponse(employee);
            return response;
        }
        catch (BadRequestException ex)
        {
            return ex.Error;
        }
    }
}
