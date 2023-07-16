using Application.Commands.Common;
using Application.DTOs.EmployeeSkillDTOs;

namespace Application.Commands.Employees.UpdateEmployee;

public sealed record UpdateEmployeeCommand(
    Guid Id, string UpdatedBy, bool IsActive, Guid? PositionId, Guid? TeamId,
    string FirstName, string EmployeeMiddleName, string LastName, string Email,
    int Age, ICollection<EmployeeSkillAddOrUpdateDTO>? EmployeeSkillUpdateDTOs
    ) : ICommand;