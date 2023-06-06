using Domain.Entities;
using Domain.Entities.JoinEntities;
using Domain.Enums;
using Domain.Shared;
using Domain.ValueObjects;

namespace Application.DTOs;

public sealed class SkillCreateDTO
{
    public string CreatedBy { get; set; }
    public Guid ParentSkillId { get; set; }
    public Description Description { get; set; }
    public SkillType SkillType { get; set; } 
    public string UpdatedBy { get; set; }
    public string DeletedBy { get; set; }
    public Skill ParentSkill { get; set; }
    public ICollection<Skill> ChildrenSkills { get; set; }
    public ICollection<EmployeeSkill> EmployeeSkills { get; set; }
    public ICollection<RoleSkill> RoleSkills { get; set; }
    public ICollection<CategoryPerSkill> CategoriesPerSkill { get; set; }

    private SkillCreateDTO
        (
            string createdBy, Guid parentSkillId,
            Description description,
            SkillType skillType, Skill parentSkill,
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
        ParentSkill = parentSkill;
        ChildrenSkills = childrenSkills;
        EmployeeSkills = employeeSkills;
        RoleSkills = roleSkills;
        CategoriesPerSkill = categoriesPerSkill;
        UpdatedBy = "something";
        DeletedBy = "something"; 
    }

    //public static SkillCreateDTO Create(Option<string> createdBy, Guid parentSkillId,
    //    Option<Description> description,
    //    SkillType skillType, Option<Skill> parentSkill,
    //    Option<ICollection<Skill>> childrenSkills,
    //    Option<ICollection<EmployeeSkill>> employeeSkills,
    //    Option<ICollection<RoleSkill>> roleSkills,
    //    Option<ICollection<CategoryPerSkill>> categoriesPerSkill)
    //        => new(
    //            createdBy, parentSkillId,
    //            description, skillType, parentSkill,
    //            childrenSkills, employeeSkills,
    //            roleSkills,
    //            categoriesPerSkill);

    public static SkillCreateDTO Create(string createdBy, Guid parentSkillId,
        Description description,
        SkillType skillType, Skill parentSkill,
        ICollection<Skill> childrenSkills,
        ICollection<EmployeeSkill> employeeSkills,
        ICollection<RoleSkill> roleSkills,
        ICollection<CategoryPerSkill> categoriesPerSkill)
            => new(
                createdBy, parentSkillId,
                description, skillType, parentSkill,
                childrenSkills, employeeSkills,
                roleSkills,
                categoriesPerSkill);

    //public static SkillCreateDTO Create(Guid parentSkillId, SkillType skillType)
    //        => new(
    //            Option<string>.None(), parentSkillId,
    //            Option<Description>.None(), skillType, Option<Skill>.None(),
    //            Option<ICollection<Skill>>.None(), Option<ICollection<EmployeeSkill>>.None(),
    //            Option<ICollection<RoleSkill>>.None(),
    //            Option<ICollection<CategoryPerSkill>>.None());
}
