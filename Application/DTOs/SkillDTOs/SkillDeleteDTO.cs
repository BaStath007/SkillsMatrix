﻿using Domain.Entities.JoinEntities;
using Domain.Entities;
using Domain.Enums;
using Domain.ValueObjects;
using Domain.Shared;

namespace Application.DTOs.SkillDTOs;

public sealed class SkillDeleteDTO
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

    private SkillDeleteDTO
        (
            Guid id, DateTime createdAt, DateTime? updatedAt,
            string createdBy, string? updatedBy, string? deletedBy, Guid? parentSkillId,
            Description description, SkillType skillType,
            ICollection<Skill>? childrenSkills, ICollection<EmployeeSkill>? employeeSkills,
            ICollection<RoleSkill>? roleSkills, ICollection<CategoryPerSkill>? categoriesPerSkill
        )
    {
        Id = id;
        CreatedAt = createdAt;
        UpdatedAt = updatedAt;
        DeletedAt = DateTime.UtcNow;
        CreatedBy = createdBy;
        UpdatedBy = updatedBy;
        DeletedBy = deletedBy;
        IsActive = false;
        IsDeleted = true;
        ParentSkillId = parentSkillId;
        Description = description;
        SkillType = skillType;
        ChildrenSkills = childrenSkills;
        EmployeeSkills = employeeSkills;
        RoleSkills = roleSkills;
        CategoriesPerSkill = categoriesPerSkill;
    }

    public static SkillDeleteDTO Create
        (
            Guid id, DateTime createdAt, DateTime? updatedAt,
            string createdBy, string? updatedBy, string? deletedBy, Guid? parentSkillId,
            Description description, SkillType skillType,
            ICollection<Skill>? childrenSkills, ICollection<EmployeeSkill>? employeeSkills,
            ICollection<RoleSkill>? roleSkills, ICollection<CategoryPerSkill>? categoriesPerSkill
        )
        => new SkillDeleteDTO
        (
            id, createdAt, updatedAt,
            createdBy, updatedBy, deletedBy,
            parentSkillId, description,
            skillType, childrenSkills,
            employeeSkills, roleSkills, categoriesPerSkill
        );
}

