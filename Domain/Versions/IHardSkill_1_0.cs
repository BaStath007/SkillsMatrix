using Domain.Helpers;

namespace Domain.Versions;

public interface IHardSkill_1_0
{
    public string? Version { get; set; }

    // Navigation Properties

    // A tag could be a different skill that works well with the one having this tag, it could be a category that the skill belongs to,
    // it could be a subskill of the aforementioned skill.
    public  List<Tag>? Tags { get; set; }
    public  List<HardSkillCategory>? Categories { get; set; }
}
