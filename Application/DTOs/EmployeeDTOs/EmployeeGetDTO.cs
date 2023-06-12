using Domain.Entities;
using Domain.Entities.JoinEntities;
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
    public Option<MiddleName> EmployeeMiddleName { get;  set; }
    public LastName LastName { get;  set; }
    public string FullName { get;  set; }
    [EmailAddress]
    public Email Email { get;  set; }
    public Age Age { get;  set; }
    public  Role? Role { get;  set; }
    public  Team? Team { get;  set; }
    public  ICollection<EmployeeSkill>? EmployeeSkills { get;  set; }

    private EmployeeGetDTO
        (
            Guid id, DateTime createdAt, DateTime? updatedAt, DateTime? deletedAt, string createdBy,
            string? updatedBy, string? deletedBy, bool isActive, bool isDeleted, Guid? roleId, Guid? teamId,
            FirstName firstName, Option<MiddleName> employeeMiddleName, LastName lastName, Email email,
            Age age, ICollection<EmployeeSkill>? employeeSkills
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
                   $"{MiddleName.Create(employeeMiddleName.Map(name => name.Value).Reduce(string.Empty))} " +
                   $"{lastName.Value}";
        Email = email;
        Age = age;
        EmployeeSkills = employeeSkills;
    }

    public static EmployeeGetDTO Create
        (
            Guid id, DateTime createdAt, DateTime? updatedAt, DateTime? deletedAt,
            string createdBy, string? updatedBy, string? deletedBy, bool isActive,
            bool isDeleted, Guid? roleId, Guid? teamId, FirstName firstName, Option<MiddleName> employeeMiddleName,
            LastName lastName, Email email, Age age, ICollection<EmployeeSkill>? employeeSkills
        )
        => new EmployeeGetDTO
        (
            id, createdAt, updatedAt, deletedAt,
            createdBy, updatedBy, deletedBy, isActive, isDeleted,
            roleId, teamId, firstName, employeeMiddleName,
            lastName, email, age, employeeSkills
        );
}
