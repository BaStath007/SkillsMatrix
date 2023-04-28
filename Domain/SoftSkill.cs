using Domain.Helpers;
using Domain.Versions;
using GenericDomain;

namespace Domain;

public class SoftSkill : NodeModel<SoftSkill>, ISoftSkill_1_0
{
    public SoftSkill()
    {

    }

    // Navigation Properties
    public List<Trait>? Traits { get; set; }
    public List<SoftSkillCategory>? Categories { get; set; }
}