using Domain.Entities;
using Domain.Entities.JoinEntities;
using Domain.Enums;
using Domain.ValueObjects;

namespace Application.DTOs;

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
    public Guid ParentSkillId { get; set; } 
    public Description Description { get; set; }
    public SkillType SkillType { get; set; } 
    public Skill ParentSkill { get; set; }
    public ICollection<Skill> ChildrenSkills { get; set; }
    public ICollection<EmployeeSkill> EmployeeSkills { get; set; }
    public ICollection<RoleSkill> RoleSkills { get; set; }
    public ICollection<CategoryPerSkill> CategoriesPerSkill { get; set; }

    public SkillGetDTO(Guid id, DateTime createdAt, DateTime? updatedAt,
        DateTime? deletedAt, string createdBy, string? updatedBy,
        string? deletedBy, bool isActive, bool isDeleted, Guid parentSkillId,
        Description description, SkillType skillType, Skill parentSkill,
        ICollection<Skill> childrenSkills, ICollection<EmployeeSkill> employeeSkills,
        ICollection<RoleSkill> roleSkills, ICollection<CategoryPerSkill> categoriesPerSkill)
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
        EmployeeSkills = employeeSkills;
        RoleSkills = roleSkills;
        CategoriesPerSkill = categoriesPerSkill;
    }
}
