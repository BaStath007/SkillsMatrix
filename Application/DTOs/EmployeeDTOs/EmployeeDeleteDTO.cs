using Domain.Entities;
using Domain.Shared;
using Domain.ValueObjects;
using System.ComponentModel.DataAnnotations;

namespace Application.DTOs.EmployeeDTOs;

public sealed class EmployeeDeleteDTO
{
    public Guid Id { get; private init; }
    public DateTime CreatedAt { get; private init; }
    public DateTime? UpdatedAt { get; private init; }
    public DateTime? DeletedAt { get; private init; }
    public string CreatedBy { get; private init; }
    public string? UpdatedBy { get; private init; }
    public string? DeletedBy { get; private init; }
    public bool IsActive { get; private init; }
    public bool IsDeleted { get; private init; }
    public FirstName FirstName { get; private init; }
    public Option<MiddleName> EmployeeMiddleName { get; private init; }
    public LastName LastName { get; private init; }
    [EmailAddress]
    public Email Email { get; private init; }
    public Age Age { get; private init; }
    public Guid? PositionId { get; private init; }
    public Guid? TeamId { get; private init; }
    public ICollection<Skill>? Skills { get; private init; }

    private EmployeeDeleteDTO
        (
            Guid id, DateTime createdAt, DateTime? updatedAt, DateTime? deletedAt,
            string createdBy, string? updatedBy, string? deletedBy,
            bool isActive, bool isDeleted, Guid? positionId, Guid? teamId,
            FirstName firstName, Option<MiddleName> employeeMiddleName,
            LastName lastName, Email email, Age age,
            ICollection<Skill>? skills
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
        FirstName = firstName;
        EmployeeMiddleName = employeeMiddleName;
        LastName = lastName;
        Email = email;
        Age = age;
        PositionId = positionId;
        TeamId = teamId;
        Skills = skills;
    }

    public static EmployeeDeleteDTO Create
        (
            Guid id, DateTime createdAt, DateTime? updatedAt, DateTime? deletedAt,
            string createdBy, string? updatedBy, string? deletedBy, bool isActive,
            bool isDeleted, Guid? positionId, Guid? teamId, FirstName firstName, Option<MiddleName> employeeMiddleName,
            LastName lastName, Email email, Age age, ICollection<Skill>? skills
        )
        => new EmployeeDeleteDTO
        (
            id, createdAt, updatedAt, deletedAt,
            createdBy, updatedBy, deletedBy, isActive, isDeleted,
            positionId, teamId, firstName, employeeMiddleName,
            lastName, email, age, skills
        );
}
