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
    private Employee
        (
            string createdBy, Guid? roleId, Guid? teamId, FirstName firstName,
            Option<MiddleName> employeeMiddleName, LastName lastName, Email email,
            Age age, ICollection<EmployeeSkill>? employeeSkills
        ) : base(createdBy)
    {
        RoleId = roleId;
        TeamId = teamId;
        FirstName = firstName;
        EmployeeMiddleName = employeeMiddleName;
        LastName = lastName;
        FullName = $"{firstName.Value} " +
                   StringExtensions.CreateMiddleName(employeeMiddleName) +
                   $"{lastName.Value}";
        Email = email;
        Age = age;
        EmployeeSkills = employeeSkills;
    }

    private Employee
        (
            Guid id, DateTime createdAt, DateTime? updatedAt, DateTime? deletedAt, string createdBy,
            string? updatedBy, string? deletedBy, bool isActive, bool isDeleted, Guid? roleId, Guid? teamId,
            FirstName firstName, Option<MiddleName> employeeMiddleName, LastName lastName, Email email,
            Age age, ICollection<EmployeeSkill>? employeeSkills

        ) :base(createdBy)
    {
        Id = id;
        CreatedAt = createdAt;
        UpdatedAt = updatedAt;
        DeletedAt = deletedAt;
        UpdatedBy = updatedBy;
        DeletedBy = deletedBy;
        IsActive = isActive;
        IsDeleted = isDeleted;
        RoleId = roleId;
        TeamId = teamId;
        FirstName = firstName;
        EmployeeMiddleName = employeeMiddleName;
        LastName = lastName;
        FullName = $"{firstName.Value} " +
                   StringExtensions.CreateMiddleName(employeeMiddleName) +
                   $"{lastName.Value}";
        Email = email;
        Age = age;
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
    
    public static Employee Create
        (
            string createdBy, Guid? roleId, Guid? teamId, 
            FirstName firstName, Option<MiddleName> employeeMiddleName, LastName lastName,
            Email email, Age age, ICollection<EmployeeSkill>? employeeSkills)
        => new
        (
            createdBy, roleId, teamId, 
            firstName, employeeMiddleName, lastName, email,
            age, employeeSkills
        );

    public static Employee Update
        (
            Guid id, DateTime createdAt, DateTime? updatedAt, DateTime? deletedAt,
            string createdBy, string? updatedBy, string? deletedBy, bool isActive,
            bool isDeleted, Guid? roleId, Guid? teamId, FirstName firstName, Option<MiddleName> employeeMiddleName,
            LastName lastName, Email email, Age age, ICollection<EmployeeSkill>? employeeSkills
        )
        => new Employee
        (
            id, createdAt, updatedAt, deletedAt,
            createdBy, updatedBy, deletedBy, isActive, isDeleted,
            roleId, teamId, firstName, employeeMiddleName,
            lastName, email, age, employeeSkills
        );
}
