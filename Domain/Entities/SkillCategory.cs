using Domain.Entities.JoinEntities;
using Domain.Primitives;
using Domain.ValueObjects;
using System.ComponentModel.DataAnnotations.Schema;

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
    private SkillCategory(string createdBy, Description description, 
        ICollection<CategoryPerSkill> categoriesPerSkill) 
        : base(createdBy)
    {
        Description = description;
        CategoriesPerSkill = categoriesPerSkill;
    }

    [NotMapped]
    public Description Description { get; set; }

    // Navigation Properties
    public virtual ICollection<CategoryPerSkill> CategoriesPerSkill { get; set; }

    public static SkillCategory Create(string createdBy, Description description, 
        ICollection<CategoryPerSkill> categoriesPerSkill) 
        => new(
            createdBy, description, categoriesPerSkill);
}
