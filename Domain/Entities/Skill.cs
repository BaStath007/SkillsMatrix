using Domain.Entities.JoinEntities;
using Domain.Enums;
using Domain.Primitives;
using Domain.ValueObjects;

namespace Domain.Entities;

public class Skill : Entity
{
    public Skill(string createdBy)
        : base(createdBy)
    {
    }
    private Skill(string createdBy, Guid parentSkillId, 
        Description description, SkillType skillType, Skill parentSkill, 
        ICollection<Skill> childrenSkills, 
        ICollection<EmployeeSkill> employeeSkills, 
        ICollection<RoleSkill> roleSkills,
        ICollection<CategoryPerSkill> categoriesPerSkill)  
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

    private Skill(DateTime? updatedAt,DateTime? deletedAt, string createdBy, 
        string? updatedBy, string? deletedBy, bool isActive, bool isDeleted,
        Guid parentSkillId, Description description, SkillType skillType, Skill parentSkill,
        ICollection<Skill> childrenSkills, ICollection<EmployeeSkill> employeeSkills,
        ICollection<RoleSkill> roleSkills, ICollection<CategoryPerSkill> categoriesPerSkill)
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
        ParentSkill = parentSkill ?? default!;
        ChildrenSkills = childrenSkills;
        EmployeeSkills = employeeSkills;
        RoleSkills = roleSkills;
        CategoriesPerSkill = categoriesPerSkill;
    }

    public Guid ParentSkillId { get; set; } = Guid.Empty;
    public Description Description { get; set; }
    public SkillType SkillType { get; set; } = SkillType.None;

    // Navigation Properties
    public virtual Skill? ParentSkill { get; set; } 
    public virtual ICollection<Skill>? ChildrenSkills { get; set;}
    public virtual ICollection<EmployeeSkill>? EmployeeSkills { get; set;}
    public virtual ICollection<RoleSkill>? RoleSkills { get; set;}
    public virtual ICollection<CategoryPerSkill>? CategoriesPerSkill { get; set; }

    public static Skill Create(
        string createdBy, Guid parentSkillId, 
        Description description,
        SkillType skillType, Skill parentSkill,
        ICollection<Skill> childrenSkills,
        ICollection<EmployeeSkill> employeeSkills,
        ICollection<RoleSkill> roleSkills,
        ICollection<CategoryPerSkill> categoriesPerSkill)
            =>new(
            createdBy, parentSkillId, 
            description, skillType, parentSkill,
            childrenSkills, employeeSkills, roleSkills,
            categoriesPerSkill);

    public static Skill Update(
        DateTime? updatedAt, DateTime? deletedAt, string createdBy, string? updatedBy,
        string? deletedBy, bool isActive, bool isDeleted, Guid parentSkillId,
        Description description, SkillType skillType, Skill parentSkill,
        ICollection<Skill> childrenSkills, ICollection<EmployeeSkill> employeeSkills,
        ICollection<RoleSkill> roleSkills, ICollection<CategoryPerSkill> categoriesPerSkill)
            => new(
            updatedAt, deletedAt, createdBy, updatedBy, deletedBy, 
            isActive, isDeleted, parentSkillId, description,
            skillType, parentSkill, childrenSkills,
            employeeSkills, roleSkills, categoriesPerSkill);
}
