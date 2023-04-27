using GenericDomain;

namespace Domain.Versions;

public class SoftSkillCategory_1_0 : BaseClass
{
    // Navigation Properties
    public virtual List<SoftSkill>? SoftSkills { get; set; }
}
