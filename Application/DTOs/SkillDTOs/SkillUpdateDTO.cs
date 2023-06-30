using Domain.Entities;
using Domain.Entities.JoinEntities;
using Domain.Enums;
using Domain.ValueObjects;

namespace Application.DTOs.SkillDTOs;

public sealed class SkillUpdateDTO
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
    public Guid? ParentSkillId { get; private init; }
    public Description Description { get; private init; }
    public SkillType SkillType { get; private init; }
    public ICollection<Skill>? ChildrenSkills { get; private init; }
    public ICollection<EmployeeSkill>? EmployeeSkills { get; private init; }
    public ICollection<RoleSkill>? RoleSkills { get; private init; }
    public ICollection<CategoryPerSkill>? CategoriesPerSkill { get; private init; }

    private SkillUpdateDTO
        (
            Guid id, DateTime createdAt, DateTime? deletedAt,
            string createdBy, string? updatedBy, string? deletedBy,
            bool isActive, bool isDeleted, Guid? parentSkillId,
            Description description, SkillType skillType,
            ICollection<Skill>? childrenSkills, ICollection<EmployeeSkill>? employeeSkills,
            ICollection<RoleSkill>? roleSkills, ICollection<CategoryPerSkill>? categoriesPerSkill
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
        ParentSkillId = parentSkillId;
        Description = description;
        SkillType = skillType;
        ChildrenSkills = childrenSkills;
        EmployeeSkills = employeeSkills;
        RoleSkills = roleSkills;
        CategoriesPerSkill = categoriesPerSkill;
    }

    public static SkillUpdateDTO Create
        (
            Guid id, DateTime createdAt, DateTime? deletedAt,
            string createdBy, string? updatedBy, string? deletedBy,
            bool isActive, bool isDeleted, Guid? parentSkillId,
            Description description, SkillType skillType,
            ICollection<Skill>? childrenSkills, ICollection<EmployeeSkill>? employeeSkills,
            ICollection<RoleSkill>? roleSkills, ICollection<CategoryPerSkill>? categoriesPerSkill
        )
        => new SkillUpdateDTO
        (
            id, createdAt, deletedAt, createdBy,
            updatedBy, deletedBy, isActive,
            isDeleted, parentSkillId, description,
            skillType, childrenSkills, employeeSkills,
            roleSkills, categoriesPerSkill
        );
}
