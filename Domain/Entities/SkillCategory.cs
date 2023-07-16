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
        ICollection<Skill>? skills) 
        : base(createdBy)
    {
        Description = description;
        Skills = skills;
    }

    public Description Description { get; private set; } = default!;

    // Navigation Properties
    public virtual ICollection<Skill>? Skills { get; private set; }

    public static SkillCategory Create
        (
            string createdBy, Description description, 
            ICollection<Skill>? skills) 
        => new SkillCategory
        (
            createdBy, description, skills
        );
}
