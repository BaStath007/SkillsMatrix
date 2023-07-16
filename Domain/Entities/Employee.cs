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

    // This is called from static method Create
    private Employee
        (
            string createdBy, bool isActive, Guid? positionId, Guid? teamId, FirstName firstName,
            Option<MiddleName> employeeMiddleName, LastName lastName, Email email, Age age
        ) : base(createdBy)
    {
        IsActive = isActive;
        PositionId = positionId;
        TeamId = teamId;
        FirstName = firstName;
        EmployeeMiddleName = employeeMiddleName;
        LastName = lastName;
        FullName = $"{firstName.Value} " +
                   StringExtensions.CreateMiddleName(employeeMiddleName) +
                   $"{lastName.Value}";
        Email = email;
        Age = age;
    }

    // This is called from static method Update
    private Employee
        (
            Guid id, DateTime createdAt, DateTime? updatedAt, DateTime? deletedAt, string createdBy,
            string? updatedBy, string? deletedBy, bool isActive, bool isDeleted, Guid? positionId, Guid? teamId,
            FirstName firstName, Option<MiddleName> employeeMiddleName, LastName lastName, Email email, Age age

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
        PositionId = positionId;
        TeamId = teamId;
        FirstName = firstName;
        EmployeeMiddleName = employeeMiddleName;
        LastName = lastName;
        FullName = $"{firstName.Value} " +
                   StringExtensions.CreateMiddleName(employeeMiddleName) +
                   $"{lastName.Value}";
        Email = email;
        Age = age;
    }


    // This is called from static method Delete
    private Employee
        (
            Guid id, DateTime createdAt, DateTime? updatedAt, DateTime? deletedAt, string createdBy,
            string? updatedBy, string? deletedBy, bool isActive, bool isDeleted, Guid? positionId, Guid? teamId,
            FirstName firstName, Option<MiddleName> employeeMiddleName, LastName lastName, Email email,
            Age age, ICollection<Skill>? skills

        ) : base(createdBy)
    {
        Id = id;
        CreatedAt = createdAt;
        UpdatedAt = updatedAt;
        DeletedAt = deletedAt;
        UpdatedBy = updatedBy;
        DeletedBy = deletedBy;
        IsActive = isActive;
        IsDeleted = isDeleted;
        PositionId = positionId;
        TeamId = teamId;
        FirstName = firstName;
        EmployeeMiddleName = employeeMiddleName;
        LastName = lastName;
        FullName = $"{firstName.Value} " +
                   StringExtensions.CreateMiddleName(employeeMiddleName) +
                   $"{lastName.Value}";
        Email = email;
        Age = age;
        Skills = skills;
    }

    public Guid? PositionId { get; private set; }
    public Guid? TeamId { get; private set; }
    public FirstName FirstName { get; private set; } = default!;
    public Option<MiddleName> EmployeeMiddleName { get; private set; } = default!;
    public LastName LastName { get; private set; } = default!;
    public string FullName { get; private set; } = string.Empty;
    [EmailAddress]
    public Email Email { get; private set; } = default!;
    public Age Age { get; private set; } = default!;

    // Navigation Properties
    public virtual Position? Position { get; private set; }
    public virtual Team? Team { get; private set; }
    public virtual ICollection<Skill>? Skills { get; private set; }
    
    public static Employee Create
        (
            string createdBy, bool isActive, Guid? positionId, Guid? teamId, 
            FirstName firstName, Option<MiddleName> employeeMiddleName,
            LastName lastName, Email email, Age age)
        => new
        (
            createdBy, isActive, positionId, teamId, 
            firstName, employeeMiddleName, lastName, email, age
        );

    public static Employee Update
        (
            Guid id, DateTime createdAt, DateTime? updatedAt, DateTime? deletedAt,
            string createdBy, string? updatedBy, string? deletedBy, bool isActive,
            bool isDeleted, Guid? positionId, Guid? teamId, FirstName firstName, Option<MiddleName> employeeMiddleName,
            LastName lastName, Email email, Age age
        )
        => new Employee
        (
            id, createdAt, updatedAt, deletedAt,
            createdBy, updatedBy, deletedBy, isActive, isDeleted,
            positionId, teamId, firstName, employeeMiddleName,
            lastName, email, age
        );

    public static Employee Delete
        (
            Guid id, DateTime createdAt, DateTime? updatedAt, DateTime? deletedAt,
            string createdBy, string? updatedBy, string? deletedBy, bool isActive,
            bool isDeleted, Guid? positionId, Guid? teamId, FirstName firstName, Option<MiddleName> employeeMiddleName,
            LastName lastName, Email email, Age age, ICollection<Skill>? skills
        )
        => new Employee
        (
            id, createdAt, updatedAt, deletedAt,
            createdBy, updatedBy, deletedBy, isActive, isDeleted,
            positionId, teamId, firstName, employeeMiddleName,
            lastName, email, age, skills
        );

    public static Employee AddSkillsToEmployee(Employee employee, ICollection<Skill> skills)
    {
        employee.Skills = skills;
        return employee;
    }
}
