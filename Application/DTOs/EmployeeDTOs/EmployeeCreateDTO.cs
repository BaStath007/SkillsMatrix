using Domain.Shared;
using Domain.ValueObjects;
using System.ComponentModel.DataAnnotations;

namespace Application.DTOs.EmployeeDTOs;
public  class EmployeeCreateDTO
{
    private EmployeeCreateDTO
        (
            string createdBy, bool isActive,
            Guid? roleId, Guid? teamId, FirstName firstName,
            Option<MiddleName> employeeMiddleName, LastName lastName,
            Email email, Age age, ICollection<Guid>? skillIds
        )
    {
        CreatedBy = createdBy;
        IsActive = isActive;
        FirstName = firstName;
        EmployeeMiddleName = employeeMiddleName;
        LastName = lastName;
        Email = email;
        Age = age;
        RoleId = roleId;
        TeamId = teamId;
        SkillIds = skillIds;
    }

    public string CreatedBy { get; private init; }
    public bool IsActive { get; private init; }
    public FirstName FirstName { get; private init; } = default!;
    public Option<MiddleName> EmployeeMiddleName { get; private init; } = default!;
    public LastName LastName { get; private init; } = default!;
    [EmailAddress]
    public Email Email { get; private init; } = default!;
    public Age Age { get; private init; } = default!;
    public Guid? RoleId { get; private init; }
    public Guid? TeamId { get; private init; }
    public ICollection<Guid>? SkillIds { get; private init; }

    public static EmployeeCreateDTO Create
        (
            string createdBy, bool isActive, Guid? roleId, Guid? teamId,
            FirstName firstName, Option<MiddleName> middleName, LastName lastName,
            Email email, Age age, ICollection<Guid>? skillIds
        )
        => new(
            createdBy, isActive, roleId, teamId,
            firstName, middleName, lastName, email,
            age, skillIds);
}
