using Domain.Entities;
using Domain.Entities.JoinEntities;
using Domain.Enums;
using Domain.ValueObjects;

namespace Application.DTOs;

public sealed class SkillUpdateDTO
{
    public Guid Id { get; set; } 
    public string CreatedBy { get; set; } 
    public string? UpdatedBy { get; set; } 
    public bool? IsActive { get; set; }
    public Guid? ParentSkillId { get; set; } 
    public Description Description { get; set; }
    public SkillType SkillType { get; set; } 
    public Skill? ParentSkill { get; set; }
    public ICollection<Skill>? ChildrenSkills { get; set; }
    public ICollection<EmployeeSkill>? EmployeeSkills { get; set; }
    public ICollection<RoleSkill>? RoleSkills { get; set; }
    public ICollection<CategoryPerSkill>? CategoriesPerSkill { get; set; }

    public SkillUpdateDTO(Guid id, string createdBy, string? updatedBy,
        bool? isActive, Guid? parentSkillId, Description description,
        SkillType skillType, Skill? parentSkill, 
        ICollection<Skill>? childrenSkills, ICollection<EmployeeSkill>? employeeSkills, 
        ICollection<RoleSkill>? roleSkills, ICollection<CategoryPerSkill>? categoriesPerSkill)
    {
        Id = id;
        CreatedBy = createdBy;
        UpdatedBy = updatedBy;
        IsActive = isActive;
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
