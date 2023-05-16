using Domain.Entities;
using Domain.Entities.JoinEntities;
using Domain.Enums;
using Domain.Shared;
using Domain.ValueObjects;

namespace Application.DTOs;

public sealed class SkillCreateDTO
{
    public Option<string> CreatedBy { get; set; }
    public Guid ParentSkillId { get; set; }
    public Option<Description> Description { get; set; }
    public SkillType SkillType { get; set; } 
    public Option<Skill> ParentSkill { get; set; }
    public Option<ICollection<Skill>> ChildrenSkills { get; set; }
    public Option<ICollection<EmployeeSkill>> EmployeeSkills { get; set; }
    public Option<ICollection<RoleSkill>> RoleSkills { get; set; }
    public Option<ICollection<CategoryPerSkill>> CategoriesPerSkill { get; set; }

    public SkillCreateDTO
        (
            Option<string> createdBy, Guid parentSkillId,
            Option<Description> description,
            SkillType skillType, Option<Skill> parentSkill,
            Option<ICollection<Skill>> childrenSkills,
            Option<ICollection<EmployeeSkill>> employeeSkills,
            Option<ICollection<RoleSkill>> roleSkills,
            Option<ICollection<CategoryPerSkill>> categoriesPerSkill
        )
    {
        CreatedBy = createdBy;
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
