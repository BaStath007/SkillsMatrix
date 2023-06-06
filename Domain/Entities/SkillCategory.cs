using Domain.Entities.JoinEntities;
using Domain.Primitives;
using Domain.ValueObjects;

namespace Domain.Entities;

/// <summary>
/// 
/// This class represents a possible category that a skill could belong to.
/// 
/// </summary>
public class SkillCategory : Entity
{
    private SkillCategory(string createdBy)
        : base(createdBy)
    {
        
    }
    private SkillCategory(string createdBy, Description description, 
        ICollection<CategoryPerSkill>? categoriesPerSkill) 
        : base(createdBy)
    {
        Description = description;
        CategoriesPerSkill = categoriesPerSkill;
    }

    public Description Description { get; private set; } = default!;

    // Navigation Properties
    public virtual ICollection<CategoryPerSkill>? CategoriesPerSkill { get; private set; }

    public static SkillCategory Create(string createdBy, Description description, 
        ICollection<CategoryPerSkill>? categoriesPerSkill) 
        => new(
            createdBy, description, categoriesPerSkill);
}
