using Domain.Entities.JoinEntities;
using Domain.Primitives;
using Domain.Shared;
using Domain.ValueObjects;

namespace Domain.Entities;

/// <summary>
/// 
/// This class represents a possible category that a skill could belong to.
/// 
/// </summary>
public class SkillCategory : Entity
{
    public SkillCategory(string createdBy)
        : base(createdBy)
    {
        
    }
    private SkillCategory(string createdBy, Option<Description> description, 
        Option<ICollection<CategoryPerSkill>> categoriesPerSkill) 
        : base(createdBy)
    {
        Description = description;
        CategoriesPerSkill = categoriesPerSkill;
    }

    public Option<Description> Description { get; set; }

    // Navigation Properties
    public virtual Option<ICollection<CategoryPerSkill>> CategoriesPerSkill { get; set; }

    public static SkillCategory Create(string createdBy, Option<Description> description, 
        Option<ICollection<CategoryPerSkill>> categoriesPerSkill) 
        => new(
            createdBy, description, categoriesPerSkill);
}
