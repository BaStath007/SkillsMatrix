using Domain.Entities.JoinEntities;
using Domain.Primitives;
using Domain.Shared;
using Domain.ValueObjects;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class Employee : Entity
{
    private Employee(string createdBy)
        :base(createdBy)
    {
        
    }
    private Employee(string createdBy, Guid? roleId, Guid? teamId,
        FirstName firstName, Option<MiddleName> middleName, LastName lastName, Email email,
        Age age, Role? role, Team? team, ICollection<EmployeeSkill>? employeeSkills)
        : base(createdBy)
    {
        RoleId = roleId;
        TeamId = teamId;
        FirstName = firstName;
        EmployeeMiddleName = middleName;
        LastName = lastName;
        FullName = $"{firstName.Value} " +
                   $"{MiddleName.Create(middleName.Map(name => name.Value).Reduce(string.Empty))} " +
                   $"{lastName.Value}";
        Email = email;
        Age = age;
        Role = role;
        Team = team;
        EmployeeSkills = employeeSkills;
    }
    public Guid? RoleId { get; private set; }
    public Guid? TeamId { get; private set; }
    public FirstName FirstName { get; private set; } = default!;
    public Option<MiddleName> EmployeeMiddleName { get; private set; } = default!;
    public LastName LastName { get; private set; } = default!;
    public string FullName { get; private set; } = string.Empty;
    [EmailAddress]
    public Email Email { get; private set; } = default!;
    public Age Age { get; private set; } = default!;

    // Navigation Properties
    public virtual Role? Role { get; private set; }
    public virtual Team? Team { get; private set; }
    public virtual ICollection<EmployeeSkill>? EmployeeSkills { get; private set; }

    public static Employee Create(string createdBy, Guid? roleId, Guid? teamId, 
        FirstName firstName, Option<MiddleName> middleName, LastName lastName,
        Email email, Age age, Role? role, Team? team,
        ICollection<EmployeeSkill>? employeeSkills)
        => new(
            createdBy, roleId, teamId, 
            firstName, middleName, lastName, email, age, 
            role, team, employeeSkills);
}
