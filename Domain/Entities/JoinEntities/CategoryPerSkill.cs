namespace Domain.Entities.JoinEntities;

/// <summary>
/// 
/// This is a class that represents the different categories each skill belongs to.
/// 
/// </summary>
public class CategoryPerSkill
{
    public CategoryPerSkill()
    {
        
    }
    private CategoryPerSkill(Guid skillId, Guid skillCategoryId, 
        Skill skill, SkillCategory skillCategory)
    {
        SkillId = skillId;
        SkillCategoryId = skillCategoryId;
        Skill = skill;
        SkillCategory = skillCategory;
    }

    public Guid SkillId { get; set; } = Guid.Empty;
    public Guid SkillCategoryId { get; set; } = Guid.Empty;

    // Navigation Properties
    public virtual Skill Skill { get; set; }
    public virtual SkillCategory SkillCategory { get; set; }

    public static CategoryPerSkill Create(Guid skillId, Guid skillCategoryId,
        Skill skill, SkillCategory skillCategory)
            => new(skillId, skillCategoryId, skill, skillCategory);
}
