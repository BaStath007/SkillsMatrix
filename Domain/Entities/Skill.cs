using Domain.Entities.JoinEntities;
using Domain.Enums;
using Domain.Primitives;
using Domain.ValueObjects;

namespace Domain.Entities;

public class Skill : Entity
{
    private Skill(string createdBy)
        : base(createdBy)
    {
    }
    private Skill(
        string createdBy, Guid? parentSkillId, 
        Description description, SkillType skillType, Skill? parentSkill, 
        ICollection<Skill>? childrenSkills, 
        ICollection<EmployeeSkill>? employeeSkills, 
        ICollection<RoleSkill>? roleSkills,
        ICollection<CategoryPerSkill>? categoriesPerSkill)  
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

    private Skill(
        string createdBy, string? updatedBy, bool? isActive,
        Guid? parentSkillId, Description description, SkillType skillType, Skill? parentSkill,
        ICollection<Skill>? childrenSkills, ICollection<EmployeeSkill>? employeeSkills,
        ICollection<RoleSkill>? roleSkills, ICollection<CategoryPerSkill>? categoriesPerSkill)
        : base(createdBy)
    {
        UpdatedAt = DateTime.UtcNow;
        UpdatedBy = updatedBy;
        IsActive = isActive;
        ParentSkillId = parentSkillId;
        Description = description;
        SkillType = skillType;
        ParentSkill = parentSkill ?? default!;
        ChildrenSkills = childrenSkills;
        EmployeeSkills = employeeSkills;
        RoleSkills = roleSkills;
        CategoriesPerSkill = categoriesPerSkill;
    }

    public Guid? ParentSkillId { get; private set; } 
    public Description Description { get; private set; } = default!;
    public SkillType SkillType { get; private set; } = SkillType.None;

    // Navigation Properties
    public virtual Skill? ParentSkill { get; private set; } 
    public virtual ICollection<Skill>? ChildrenSkills { get; private set; }
    public virtual ICollection<EmployeeSkill>? EmployeeSkills { get; private set; }
    public virtual ICollection<RoleSkill>? RoleSkills { get; private set; }
    public virtual ICollection<CategoryPerSkill>? CategoriesPerSkill { get; private set; }

    public static Skill Create(
        string createdBy, Guid? parentSkillId, 
        Description description,
        SkillType skillType, Skill? parentSkill,
        ICollection<Skill>? childrenSkills,
        ICollection<EmployeeSkill>? employeeSkills,
        ICollection<RoleSkill>? roleSkills,
        ICollection<CategoryPerSkill>? categoriesPerSkill)
            =>new(
            createdBy, parentSkillId, 
            description, skillType, parentSkill,
            childrenSkills, employeeSkills, roleSkills,
            categoriesPerSkill);

    public static Skill Update
        (
            string createdBy, string? updatedBy, bool? isActive, Guid? parentSkillId,
            Description description, SkillType skillType, Skill? parentSkill,
            ICollection<Skill>? childrenSkills, ICollection<EmployeeSkill>? employeeSkills,
            ICollection<RoleSkill>? roleSkills, ICollection<CategoryPerSkill>? categoriesPerSkill
        )
            => new(
            createdBy, updatedBy, isActive, parentSkillId, description,
            skillType, parentSkill, childrenSkills,
            employeeSkills, roleSkills, categoriesPerSkill);
}
