using Domain.Shared;
using Domain.ValueObjects;
using System.ComponentModel.DataAnnotations;

namespace Application.DTOs.EmployeeDTOs;

public sealed class EmployeeUpdateDTO
{
    private EmployeeUpdateDTO
        (
            Guid id, DateTime createdAt, DateTime? deletedAt,
            string createdBy, string? updatedBy, string? deletedBy,
            bool isActive, bool isDeleted, Guid? positionId, Guid? teamId,
            FirstName firstName, Option<MiddleName> employeeMiddleName,
            LastName lastName, Email email, Age age
        )
    {
        Id = id;
        CreatedAt = createdAt;
        UpdatedAt = DateTime.UtcNow;
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
    }

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

    public static EmployeeUpdateDTO Create
        (
            Guid id, DateTime createdAt, DateTime? deletedAt, string createdBy,
            string? updatedBy, string? deletedBy, bool isActive, bool isDeleted,
            Guid? positionId, Guid? teamId, FirstName firstName, Option<MiddleName> employeeMiddleName,
            LastName lastName, Email email, Age age
        )
        => new
        (
            id, createdAt, deletedAt, createdBy, updatedBy,
            deletedBy, isActive, isDeleted, positionId,
            teamId, firstName, employeeMiddleName,
            lastName, email, age
        );
}
