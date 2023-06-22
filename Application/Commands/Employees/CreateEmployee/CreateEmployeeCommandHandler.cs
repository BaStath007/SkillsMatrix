using Application.Commands.Common;
using Application.Data;
using Application.Data.IRepositories;
using Application.DTOs.EmployeeDTOs;
using Application.Exceptions;
using Domain.Shared;
using Domain.ValueObjects;

namespace Application.Commands.Employees.CreateEmployee;

public sealed class CreateEmployeeCommandHandler : ICommandHandler<CreateEmployeeCommand>
{
    private readonly IEmployeeRepository _repository;
    private readonly IUnitOfWork _unit;

    public CreateEmployeeCommandHandler(IEmployeeRepository repository, IUnitOfWork unit)
    {
        _repository = repository;
        _unit = unit;
    }

    public async Task<Result> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var result = TryCreateValueObjects(request);
            if (result.IsFailure)
            {
                return result;
            }
            _repository.Add(result.Data);
            await _unit.SaveChangesAsync(cancellationToken);
        }
        catch (BadRequestException ex)
        {
            return ex.Error;
        }

        return Result.Success();
    }

    private static Result<EmployeeCreateDTO> TryCreateValueObjects(CreateEmployeeCommand request)
    {
        var firstNameResult = FirstName.Create(request.FirstName);
        if (firstNameResult.IsFailure)
        {
            return firstNameResult.Error;
        }
        var middleNameResult = MiddleName.Create(request.EmployeeMiddleName);
        if (middleNameResult is not null && middleNameResult.IsFailure)
        {
            return middleNameResult.Error;
        }
        var lastNameResult = LastName.Create(request.LastName);
        if (lastNameResult.IsFailure)
        {
            return lastNameResult.Error;
        }
        var emailResult = Email.Create(request.Email);
        if (emailResult.IsFailure)
        {
            return emailResult.Error;
        }
        var ageResult = Age.Create(request.Age);
        if (ageResult.IsFailure)
        {
            return ageResult.Error;
        }
        Option<MiddleName> optionalMiddleName;
        if (middleNameResult?.Data is not null)
        {
            optionalMiddleName = Option<MiddleName>.Some(middleNameResult.Data);
        }
        else
        {
            optionalMiddleName = Option<MiddleName>.None();
        }
        var employee = EmployeeCreateDTO.Create(
                request.CreatedBy, request.IsActive, request.RoleId, request.TeamId,
                firstNameResult.Data, optionalMiddleName, lastNameResult.Data,
                emailResult.Data, ageResult.Data, request.EmployeeSkills
                );

        return employee;
    }
}
