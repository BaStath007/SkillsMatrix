using Application.Commands.Common;
using Domain.Entities.JoinEntities;

namespace Application.Commands.Employees.CreateEmployee;

public sealed record CreateEmployeeCommand(
    string CreatedBy, Guid? RoleId, Guid? TeamId,
    string FirstName, string EmployeeMiddleName, string LastName,
    string Email, int Age, ICollection<EmployeeSkill> EmployeeSkills
    ) : ICommand;