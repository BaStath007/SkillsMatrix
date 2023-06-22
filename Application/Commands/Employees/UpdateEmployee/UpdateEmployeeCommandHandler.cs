﻿using Application.Commands.Common;
using Application.Data;
using Application.Data.IRepositories;
using Application.DTOs.EmployeeDTOs;
using Application.Exceptions;
using Domain.Entities;
using Domain.Entities.JoinEntities;
using Domain.Shared;
using Domain.ValueObjects;

namespace Application.Commands.Employees.UpdateEmployee;

public sealed class UpdateEmployeeCommandHandler : ICommandHandler<UpdateEmployeeCommand>
{
    private readonly IEmployeeRepository _repository;
    private readonly IUnitOfWork _unit;

    public UpdateEmployeeCommandHandler(IEmployeeRepository repository, IUnitOfWork unit)
    {
        _repository = repository;
        _unit = unit;
    }

    public async Task<Result> Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var oldEmployee = await _repository.GetById(request.Id, cancellationToken);
            if (oldEmployee is null)
            {
                return new Error(
                    "Employee.NotFound",
                    $"The requested employee with Id: {request.Id} was not found.");
            }

            var result = TryUpdateValueObjects(request, oldEmployee);
            if (result.IsFailure)
            {
                return result;
            }

            var newEmployee = EmployeeUpdateDTO.Create(
                oldEmployee.Id,
                oldEmployee.CreatedAt,
                DateTime.UtcNow,
                oldEmployee.DeletedAt,
                oldEmployee.CreatedBy,
                request.UpdatedBy,
                oldEmployee.DeletedBy,
                oldEmployee.IsActive,
                oldEmployee.IsDeleted,
                oldEmployee.RoleId,
                oldEmployee.TeamId,
                oldEmployee.FirstName,
                oldEmployee.EmployeeMiddleName,
                oldEmployee.LastName,
                oldEmployee.Email,
                oldEmployee.Age,
                oldEmployee.EmployeeSkills);

            _repository.Update(newEmployee);
            await _unit.SaveChangesAsync(cancellationToken);

            return Result.Success();
        }
        catch (BadRequestException ex)
        {
            return ex.Error;
        }
    }

    private static Result TryUpdateValueObjects(UpdateEmployeeCommand request, EmployeeGetDTO oldEmployee)
    {
        if (!FirstNameMatch(request, oldEmployee))
        {
            var firstNameResult = FirstName.Create(request.FirstName);
            if (firstNameResult.IsFailure)
            {
                return firstNameResult;
            }
            oldEmployee.FirstName = firstNameResult.Data;
        }

        if (!MiddleNameMatch(request, oldEmployee))
        {
            var middleNameResult = MiddleName.Create(request.EmployeeMiddleName);
            if (middleNameResult is not null)
            {
                if (middleNameResult.IsFailure)
                {
                    return middleNameResult;
                }
                oldEmployee.EmployeeMiddleName = Option<MiddleName>.Some(middleNameResult.Data);
            }
        }

        if (!LastNameMatch(request, oldEmployee))
        {
            var lastNameResult = LastName.Create(request.LastName);
            if (lastNameResult.IsFailure)
            {
                return lastNameResult;
            }
            oldEmployee.LastName = lastNameResult.Data;
        }

        if (!AgeMatch(request, oldEmployee))
        {
            var ageResult = Age.Create(request.Age);
            if (ageResult.IsFailure)
            {
                return ageResult;
            }
            oldEmployee.Age = ageResult.Data;
        }

        if (!EmailMatch(request, oldEmployee))
        {
            var emailResult = Email.Create(request.Email);
            if (emailResult.IsFailure)
            {
                return emailResult;
            }
            oldEmployee.Email = emailResult.Data;
        }

        return Result.Success();
    }

    private static bool EmailMatch(UpdateEmployeeCommand request, EmployeeGetDTO oldEmployee)
    {
        return oldEmployee.Email.Value == request.Email;
    }

    private static bool AgeMatch(UpdateEmployeeCommand request, EmployeeGetDTO oldEmployee)
    {
        return oldEmployee.Age.Value == request.Age;
    }

    private static bool LastNameMatch(UpdateEmployeeCommand request, EmployeeGetDTO oldEmployee)
    {
        return oldEmployee.LastName.Value == request.LastName;
    }

    private static bool MiddleNameMatch(UpdateEmployeeCommand request, EmployeeGetDTO oldEmployee)
    {
        return oldEmployee.EmployeeMiddleName.Map(mn => mn.Value).Reduce(default!) == request.EmployeeMiddleName;
    }

    private static bool FirstNameMatch(UpdateEmployeeCommand request, EmployeeGetDTO oldEmployee)
    {
        return oldEmployee.FirstName.Value == request.FirstName;
    }
}