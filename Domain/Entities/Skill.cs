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

    // This is called from static method Create
    private Skill(
        string createdBy, bool isActive, Guid? parentSkillId, 
        Description description, SkillType skillType, 
        ICollection<Skill>? childrenSkills, 
        ICollection<EmployeeSkill>? employeeSkills, 
        ICollection<RoleSkill>? roleSkills,
        ICollection<CategoryPerSkill>? categoriesPerSkill)  
        : base(createdBy)
    {
        IsActive = isActive;
        ParentSkillId = parentSkillId;
        Description = description;
        SkillType = skillType;
        ChildrenSkills = childrenSkills;
        EmployeeSkills = employeeSkills;
        RoleSkills = roleSkills;
        CategoriesPerSkill = categoriesPerSkill;
    }

    // This is called from static method Update
    private Skill
        (
            Guid id, DateTime createdAt, DateTime? updatedAt, DateTime? deletedAt, string createdBy,
            string? updatedBy, string? deletedBy, bool isActive, bool isDeleted,
            Guid? parentSkillId, Description description, SkillType skillType,
            ICollection<Skill>? childrenSkills, ICollection<EmployeeSkill>? employeeSkills,
            ICollection<RoleSkill>? roleSkills, ICollection<CategoryPerSkill>? categoriesPerSkill
        ) : base(createdBy)
    {
        Id = id;
        CreatedAt = createdAt;
        UpdatedAt = updatedAt;
        DeletedAt = deletedAt;
        UpdatedBy = updatedBy;
        DeletedBy = deletedBy;
        IsActive = isActive;
        IsDeleted = isDeleted;
        ParentSkillId = parentSkillId;
        Description = description;
        SkillType = skillType;
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

    public static Skill Create
        (
            string createdBy, bool isActive,
            Guid? parentSkillId, 
            Description description,
            SkillType skillType,
            ICollection<Skill>? childrenSkills,
            ICollection<EmployeeSkill>? employeeSkills,
            ICollection<RoleSkill>? roleSkills,
            ICollection<CategoryPerSkill>? categoriesPerSkill
        )
        =>new(
            createdBy, isActive,
            parentSkillId, 
            description, skillType,
            childrenSkills, employeeSkills, roleSkills,
            categoriesPerSkill
        );

    public static Skill Update
        (
            Guid id, DateTime createdAt, DateTime? updatedAt, DateTime? deletedAt,
            string createdBy, string? updatedBy, string? deletedBy, bool isActive,
            bool isDeleted, Guid? parentSkillId,
            Description description, SkillType skillType,
            ICollection<Skill>? childrenSkills, ICollection<EmployeeSkill>? employeeSkills,
            ICollection<RoleSkill>? roleSkills, ICollection<CategoryPerSkill>? categoriesPerSkill
        )
        => new(
            id, createdAt, updatedAt, deletedAt,
            createdBy, updatedBy, deletedBy,  isActive, isDeleted, 
            parentSkillId, description,
            skillType, childrenSkills,
            employeeSkills, roleSkills, categoriesPerSkill
        );
}
