using Application.Commands.Common;
using Application.DTOs.EmployeeSkillDTOs;
using Domain.Entities;

namespace Application.Commands.Employees.CreateEmployee;

public sealed record CreateEmployeeCommand(
    string CreatedBy, bool IsActive, Guid? RoleId, Guid? TeamId,
    string FirstName, string EmployeeMiddleName, string LastName,
    string Email, int Age, ICollection<EmployeeSkillCreateDTO> EmployeeSkillCreateDTOs
    ) : ICommand;