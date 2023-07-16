using Domain.Entities;
using Domain.Enums;
using Domain.ValueObjects;

namespace Application.DTOs.SkillDTOs;

public sealed class SkillGetDTO
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
    public Guid? ParentSkillId { get; set; }
    public Description Description { get; set; }
    public SkillType SkillType { get; set; }
    public Skill? ParentSkill { get; set; }
    public ICollection<Skill>? ChildrenSkills { get; set; }
    public ICollection<Employee>? Employees { get; set; }
    public ICollection<Position>? Positions { get; set; }
    public ICollection<SkillCategory>? SkillCategories { get; set; }

    private SkillGetDTO
        (
            Guid id, DateTime createdAt, DateTime? updatedAt,
            DateTime? deletedAt, string createdBy, string? updatedBy,
            string? deletedBy, bool isActive, bool isDeleted, Guid? parentSkillId,
            Description description, SkillType skillType, Skill? parentSkill,
            ICollection<Skill>? childrenSkills, ICollection<Employee>? employees,
            ICollection<Position>? positions, ICollection<SkillCategory>? skillCategories
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
        ParentSkillId = parentSkillId;
        Description = description;
        SkillType = skillType;
        ParentSkill = parentSkill;
        ChildrenSkills = childrenSkills;
        Employees = employees;
        Positions = positions;
        SkillCategories = skillCategories;
    }

    public static SkillGetDTO Create
        (
            Guid id, DateTime createdAt, DateTime? updatedAt, DateTime? deletedAt,
            string createdBy, string? updatedBy, string? deletedBy, bool isActive,
            bool isDeleted, Guid? parentSkillId,
            Description description, SkillType skillType, Skill? parentSkill,
            ICollection<Skill>? childrenSkills, ICollection<Employee>? employees,
            ICollection<Position>? positions, ICollection<SkillCategory>? skillCategories
        )
        => new SkillGetDTO
        (
            id, createdAt, updatedAt, deletedAt,
            createdBy, updatedBy, deletedBy, isActive, isDeleted,
            parentSkillId, description, skillType,
            parentSkill, childrenSkills,
            employees, positions, skillCategories
        );
}
