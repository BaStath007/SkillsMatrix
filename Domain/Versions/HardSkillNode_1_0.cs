using Domain.Helpers;
using GenericDomain;

namespace Domain.Versions;

public class HardSkillNode_1_0 : NodeModel<HardSkillNode_1_0>
{
    public string? Version { get; set; }

    // Navigation Properties

    // A tag could be a different skill that works well with the one having this tag, it could be a category that the skill belongs to,
    // it could be a subskill of the aforementioned skill.
    public virtual List<Tag>? Tags { get; set; }
    public virtual HardSkillCategory? Category { get; set; }


    public HardSkillNode_1_0()
    {

    }
}
