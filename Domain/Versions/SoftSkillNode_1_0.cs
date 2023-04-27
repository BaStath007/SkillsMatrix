using Domain.Helpers;
using GenericDomain;

namespace Domain.Versions;

public class SoftSkillNode_1_0 : NodeModel<SoftSkillNode_1_0>
{

    // Navigation Properties
    public virtual List<Trait>? Traits { get; set; } // Empathy, Teamworking etc.
    public virtual SoftSkillCategory? Category { get; set; }
    public SoftSkillNode_1_0()
    {

    }
}
