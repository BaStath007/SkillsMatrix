using Domain.Entities;
using Domain.Entities.JoinEntities;
using Domain.Enums;
using Domain.Shared;
using Domain.ValueObjects;

namespace Application.DTOs;

public sealed class SkillGetDTO
{
    public Guid Id { get; set; } 
    public DateTime CreatedAt { get; set; } 
    public DateTime UpdatedAt { get; set; } 
    public DateTime DeletedAt { get; set; } 
    public Option<string> CreatedBy { get; set; }
    public Option<string> UpdatedBy { get; set; } 
    public Option<string> DeletedBy { get; set; } 
    public bool IsActive { get; set; } 
    public bool IsDeleted { get; set; } 
    public Guid ParentSkillId { get; set; } 
    public Option<Description> Description { get; set; }
    public SkillType SkillType { get; set; } 
    public Option<Skill> ParentSkill { get; set; }
    public Option<ICollection<Skill>> ChildrenSkills { get; set; }
    public Option<ICollection<EmployeeSkill>> EmployeeSkills { get; set; }
    public Option<ICollection<RoleSkill>> RoleSkills { get; set; }
    public Option<ICollection<CategoryPerSkill>> CategoriesPerSkill { get; set; }

    public SkillGetDTO(Guid id, DateTime createdAt, DateTime updatedAt,
        DateTime deletedAt, Option<string> createdBy, Option<string> updatedBy,
        Option<string> deletedBy, bool isActive, bool isDeleted, Guid parentSkillId,
        Option<Description> description, SkillType skillType, Option<Skill> parentSkill,
        Option<ICollection<Skill>> childrenSkills, Option<ICollection<EmployeeSkill>> employeeSkills,
        Option<ICollection<RoleSkill>> roleSkills, Option<ICollection<CategoryPerSkill>> categoriesPerSkill)
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
