using Domain.Entities.JoinEntities;
using Domain.Primitives;
using Domain.Shared;
using Domain.ValueObjects;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class Employee : Entity
{
    private Employee(Option<string> createdBy, Guid roleId, Guid teamId, 
        FirstName firstName, LastName lastName, Email email, Age age, 
        Option<Role> role, Option<Team> team, Option<ICollection<EmployeeSkill>> employeeSkills)
        : base(createdBy)
    {
        RoleId = roleId;
        TeamId = teamId;
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        Age = age;
        Role = role;
        Team = team;
        EmployeeSkills = employeeSkills;
    }
    public Guid RoleId { get; set; }
    public Guid TeamId { get; set; }
    public FirstName FirstName { get; set; }
    public LastName LastName { get; set; }
    [EmailAddress]
    public Email Email { get; set; }
    public Age Age { get; set; }

    // Navigation Properties
    public virtual Option<Role> Role { get; set; }
    public virtual Option<Team> Team { get; set; }
    public virtual Option<ICollection<EmployeeSkill>> EmployeeSkills { get; set; }

    public static Employee Create(Option<string> createdBy, Guid roleId, Guid teamId, 
        FirstName firstName, LastName lastName, Email email, Age age,
        Option<Role> role, Option<Team> team, Option<ICollection<EmployeeSkill>> employeeSkills)
        => new(
            createdBy, roleId, teamId, 
            firstName, lastName, email, age, 
            role, team, employeeSkills);
}
