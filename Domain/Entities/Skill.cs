using Domain.Entities.JoinEntities;
using Domain.Enums;
using Domain.Primitives;
using Domain.Shared;
using Domain.ValueObjects;

namespace Domain.Entities;

public class Skill : Entity
{
    private Skill(Option<string> createdBy, Guid parentSkillId, 
        Option<Description> description, SkillType skillType, Option<Skill> parentSkill, 
        Option<ICollection<Skill>> childrenSkills, 
        Option<ICollection<EmployeeSkill>> employeeSkills, 
        Option<ICollection<RoleSkill>> roleSkills,
        Option<ICollection<CategoryPerSkill>> categoriesPerSkill)  
        : base(createdBy)
    {
        ParentSkillId = parentSkillId;
        Description = description;
        SkillType = skillType;
        ParentSkill = parentSkill;
        ChildrenSkills = childrenSkills;
        EmployeeSkills = employeeSkills;
        RoleSkills = roleSkills;
        CategoriesPerSkill = categoriesPerSkill;
    }

    private Skill(DateTime updatedAt,DateTime deletedAt, Option<string> createdBy, 
        Option<string> updatedBy, Option<string> deletedBy, bool isActive, bool isDeleted,
        Guid parentSkillId, Option<Description> description, SkillType skillType, Option<Skill> parentSkill,
        Option<ICollection<Skill>> childrenSkills, Option<ICollection<EmployeeSkill>> employeeSkills,
        Option<ICollection<RoleSkill>> roleSkills, Option<ICollection<CategoryPerSkill>> categoriesPerSkill)
        : base(createdBy)
    {
        UpdatedAt = updatedAt;
        DeletedAt = deletedAt;
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

    public Guid ParentSkillId { get; set; } = Guid.Empty;
    public Option<Description> Description { get; set; }
    public SkillType SkillType { get; set; } = SkillType.None;

    // Navigation Properties
    public virtual Option<Skill> ParentSkill { get; set; }
    public virtual Option<ICollection<Skill>> ChildrenSkills { get; set;}
    public virtual Option<ICollection<EmployeeSkill>> EmployeeSkills { get; set;}
    public virtual Option<ICollection<RoleSkill>> RoleSkills { get; set;}
    public virtual Option<ICollection<CategoryPerSkill>> CategoriesPerSkill { get; set; }

    public static Skill Create(
        Option<string> createdBy, Guid parentSkillId, 
        Option<Description> description,
        SkillType skillType, Option<Skill> parentSkill,
        Option<ICollection<Skill>> childrenSkills,
        Option<ICollection<EmployeeSkill>> employeeSkills,
        Option<ICollection<RoleSkill>> roleSkills,
        Option<ICollection<CategoryPerSkill>> categoriesPerSkill)
            =>new(
            createdBy, parentSkillId, 
            description, skillType, parentSkill,
            childrenSkills, employeeSkills, roleSkills,
            categoriesPerSkill);

    public static Skill Update(
        DateTime updatedAt, DateTime deletedAt, Option<string> createdBy, Option<string> updatedBy,
        Option<string> deletedBy, bool isActive, bool isDeleted, Guid parentSkillId,
        Option<Description> description, SkillType skillType, Option<Skill> parentSkill,
        Option<ICollection<Skill>> childrenSkills, Option<ICollection<EmployeeSkill>> employeeSkills,
        Option<ICollection<RoleSkill>> roleSkills, Option<ICollection<CategoryPerSkill>> categoriesPerSkill)
            => new(
            updatedAt, deletedAt, createdBy, updatedBy, deletedBy, 
            isActive, isDeleted, parentSkillId, description,
            skillType, parentSkill, childrenSkills,
            employeeSkills, roleSkills, categoriesPerSkill);
}
