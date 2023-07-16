using Application.Commands.Common;
using Application.Data;
using Application.Data.IRepositories;
using Application.DTOs.EmployeeDTOs;
using Application.Exceptions;
using Domain.Shared;
using Domain.ValueObjects;

namespace Application.Commands.Employees.DeleteEmployee;

public sealed class DeleteEmployeeCommandHandler : ICommandHandler<DeleteEmployeeCommand>
{
    private readonly IEmployeeRepository _repository;
    private readonly IUnitOfWork _unit;

    public DeleteEmployeeCommandHandler(IEmployeeRepository repository, IUnitOfWork unit)
    {
        _repository = repository;
        _unit = unit;
    }

    public async Task<Result> Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var dbEmployee = await _repository.GetById(request.Id, cancellationToken);
            if (dbEmployee == null)
            {
                return Result.Failure(new Error
                        (
                            "Employee.NotFound",
                            $"The requested employee with Id: {request.Id} was not found."
                        )
                );
            }

            var employeeToDelete = EmployeeDeleteDTO.Create
                (
                    dbEmployee.Id,
                    dbEmployee.CreatedAt,
                    dbEmployee.UpdatedAt,
                    DateTime.UtcNow,
                    dbEmployee.CreatedBy,
                    dbEmployee.UpdatedBy,
                    request.DeletedBy,
                    false,
                    true,
                    dbEmployee.RoleId,
                    dbEmployee.TeamId,
                    dbEmployee.FirstName,
                    Option<MiddleName>.Some(dbEmployee.EmployeeMiddleName),
                    dbEmployee.LastName,
                    dbEmployee.Email,
                    dbEmployee.Age,
                    dbEmployee.Skills
            );

            _repository.SoftDelete(employeeToDelete);
            await _unit.SaveChangesAsync(cancellationToken);

            return Result.Success();
        }
        catch (BadRequestException ex)
        {
            return Result.Failure(ex.Error);
        }
    }
}
