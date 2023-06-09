using Domain.Entities.JoinEntities;
using Domain.Enums;
using Domain.ValueObjects;
using Domain.Entities;

namespace Application.DTOs.SkillDTOs;

public sealed class SkillCreateDTO
{
    public string CreatedBy { get; private init; }
    public Guid ParentSkillId { get; private init; }
    public Description Description { get; private init; }
    public SkillType SkillType { get; private init; }
    public ICollection<Skill> ChildrenSkills { get; private init; }
    public ICollection<EmployeeSkill> EmployeeSkills { get; private init; }
    public ICollection<RoleSkill> RoleSkills { get; private init; }
    public ICollection<CategoryPerSkill> CategoriesPerSkill { get; private init; }

    private SkillCreateDTO
        (
            string createdBy, Guid parentSkillId,
            Description description,
            SkillType skillType,
            ICollection<Skill> childrenSkills,
            ICollection<EmployeeSkill> employeeSkills,
            ICollection<RoleSkill> roleSkills,
            ICollection<CategoryPerSkill> categoriesPerSkill
        )
    {
        CreatedBy = createdBy;
        ParentSkillId = parentSkillId;
        Description = description;
        SkillType = skillType;
        ChildrenSkills = childrenSkills;
        EmployeeSkills = employeeSkills;
        RoleSkills = roleSkills;
        CategoriesPerSkill = categoriesPerSkill;
    }

    public static SkillCreateDTO Create
        (
            string createdBy, Guid parentSkillId,
            Description description,
            SkillType skillType,
            ICollection<Skill> childrenSkills,
            ICollection<EmployeeSkill> employeeSkills,
            ICollection<RoleSkill> roleSkills,
            ICollection<CategoryPerSkill> categoriesPerSkill
        )
        => new
        (
            createdBy, parentSkillId,
            description, skillType,
            childrenSkills, employeeSkills,
            roleSkills,
            categoriesPerSkill
        );
}
