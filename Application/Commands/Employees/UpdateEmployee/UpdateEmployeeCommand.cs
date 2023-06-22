using Application.Commands.Common;
using Domain.Entities.JoinEntities;

namespace Application.Commands.Employees.UpdateEmployee;

public sealed record UpdateEmployeeCommand(
    Guid Id, string? UpdatedBy, bool IsActive,Guid? RoleId, Guid? TeamId,
    string FirstName, string EmployeeMiddleName, string LastName, string Email,
    int Age, ICollection<EmployeeSkill>? EmployeeSkills
    ) : ICommand;