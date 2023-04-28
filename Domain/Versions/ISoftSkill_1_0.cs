using Domain.Helpers;

namespace Domain.Versions;

public interface ISoftSkill_1_0
{

    // Navigation Properties
    public List<Trait>? Traits { get; set; } // Empathy, Teamworking etc.
    public List<SoftSkillCategory>? Categories { get; set; }
}
