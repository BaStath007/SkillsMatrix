using Domain.Entities;
using Domain.Shared;
using Domain.ValueObjects;
using System.ComponentModel.DataAnnotations;

namespace Application.DTOs.EmployeeDTOs;

public sealed class EmployeeGetDTO
{
    public Guid Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public DateTime? DeletedAt { get; set; }
    public string CreatedBy { get; set; }
    public string? UpdatedBy { get; set; }
    public string? DeletedBy { get; set; }
    public bool IsActive { get; set; }
    public bool IsDeleted { get; set; }
    public Guid? RoleId { get;  set; }
    public Guid? TeamId { get;  set; }
    public FirstName FirstName { get;  set; }
    public MiddleName EmployeeMiddleName { get;  set; }
    public LastName LastName { get;  set; }
    public string FullName { get;  set; }
    [EmailAddress]
    public Email Email { get;  set; }
    public Age Age { get;  set; }
    public  Position? Role { get;  set; }
    public  Team? Team { get;  set; }
    public  ICollection<Skill>? Skills { get;  set; }

    private EmployeeGetDTO
        (
            Guid id, DateTime createdAt, DateTime? updatedAt, DateTime? deletedAt, string createdBy,
            string? updatedBy, string? deletedBy, bool isActive, bool isDeleted, Guid? roleId, Guid? teamId,
            FirstName firstName, MiddleName employeeMiddleName, LastName lastName, Email email,
            Age age, ICollection<Skill>? skills
        )
    {
        Id = id;
        CreatedAt = createdAt;
        UpdatedAt = updatedAt;
        DeletedAt = deletedAt;
        CreatedBy = createdBy;
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
                   StringExtensions.CreateMiddleName(Option<MiddleName>.Some(employeeMiddleName)) +
                   $"{lastName.Value}";
        Email = email;
        Age = age;
        Skills = skills;
    }

    public static EmployeeGetDTO Create
        (
            Guid id, DateTime createdAt, DateTime? updatedAt, DateTime? deletedAt,
            string createdBy, string? updatedBy, string? deletedBy, bool isActive,
            bool isDeleted, Guid? roleId, Guid? teamId, FirstName firstName, MiddleName employeeMiddleName,
            LastName lastName, Email email, Age age, ICollection<Skill>? skills
        )
        => new EmployeeGetDTO
        (
            id, createdAt, updatedAt, deletedAt,
            createdBy, updatedBy, deletedBy, isActive, isDeleted,
            roleId, teamId, firstName, employeeMiddleName,
            lastName, email, age, skills
        );
}
