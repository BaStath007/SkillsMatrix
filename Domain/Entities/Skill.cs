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
    private Skill
        (
        string createdBy, bool isActive, Guid? parentSkillId, 
        Description description, SkillType skillType, 
        ICollection<Skill>? childrenSkills, 
        ICollection<Employee>? employees, 
        ICollection<Position>? positions,
        ICollection<SkillCategory>? skillCategories)  
        : base(createdBy)
    {
        IsActive = isActive;
        ParentSkillId = parentSkillId;
        Description = description;
        SkillType = skillType;
        ChildrenSkills = childrenSkills;
        Employees = employees;
        Positions = positions;
        SkillCategories = skillCategories;
    }

    // This is called from static method Update
    private Skill
        (
            Guid id, DateTime createdAt, DateTime? updatedAt, DateTime? deletedAt, string createdBy,
            string? updatedBy, string? deletedBy, bool isActive, bool isDeleted,
            Guid? parentSkillId, Description description, SkillType skillType,
            ICollection<Skill>? childrenSkills, ICollection<Employee>? employees,
            ICollection<Position>? positions, ICollection<SkillCategory>? skillCategories
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
        Employees = employees;
        Positions = positions;
        SkillCategories = skillCategories;
    }

    public Guid? ParentSkillId { get; private set; } 
    public Description Description { get; private set; } = default!;
    public SkillType SkillType { get; private set; } = SkillType.None;

    // Navigation Properties
    public virtual Skill? ParentSkill { get; private set; } 
    public virtual ICollection<Skill>? ChildrenSkills { get; private set; }
    public virtual ICollection<Employee>? Employees { get; private set; }
    public virtual ICollection<Position>? Positions { get; private set; }
    public virtual ICollection<SkillCategory>? SkillCategories { get; private set; }

    public static Skill Create
        (
            string createdBy, bool isActive,
            Guid? parentSkillId, 
            Description description,
            SkillType skillType,
            ICollection<Skill>? childrenSkills,
            ICollection<Employee>? employees,
            ICollection<Position>? positions,
            ICollection<SkillCategory>? skillCategories
        )
        =>new(
            createdBy, isActive,
            parentSkillId, 
            description, skillType,
            childrenSkills, employees, positions,
            skillCategories
        );

    public static Skill Update
        (
            Guid id, DateTime createdAt, DateTime? updatedAt, DateTime? deletedAt,
            string createdBy, string? updatedBy, string? deletedBy, bool isActive,
            bool isDeleted, Guid? parentSkillId,
            Description description, SkillType skillType,
            ICollection<Skill>? childrenSkills, ICollection<Employee>? employees,
            ICollection<Position>? positions, ICollection<SkillCategory>? skillCategories
        )
        => new(
            id, createdAt, updatedAt, deletedAt,
            createdBy, updatedBy, deletedBy,  isActive, isDeleted, 
            parentSkillId, description,
            skillType, childrenSkills,
            employees, positions, skillCategories
        );
}
