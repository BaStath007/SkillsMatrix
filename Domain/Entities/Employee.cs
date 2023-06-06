using Domain.Entities.JoinEntities;
using Domain.Primitives;
using Domain.ValueObjects;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities;

public class Employee : Entity
{
    public Employee(string createdBy)
        :base(createdBy)
    {
        
    }
    private Employee(string createdBy, Guid roleId, Guid teamId,
        FirstName firstName, LastName lastName, Email email, Age age, 
        Role role, Team team, ICollection<EmployeeSkill> employeeSkills)
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
    public virtual Role Role { get; set; }
    public virtual Team Team { get; set; }
    public virtual ICollection<EmployeeSkill> EmployeeSkills { get; set; }

    public static Employee Create(string createdBy, Guid roleId, Guid teamId, 
        FirstName firstName, LastName lastName, Email email, Age age,
        Role role, Team team, ICollection<EmployeeSkill> employeeSkills)
        => new(
            createdBy, roleId, teamId, 
            firstName, lastName, email, age, 
            role, team, employeeSkills);
}
