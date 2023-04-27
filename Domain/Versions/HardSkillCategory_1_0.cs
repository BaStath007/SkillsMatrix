using GenericDomain;

namespace Domain.Versions;

public class HardSkillCategory_1_0 : BaseClass
{
    // Navigation Properties
    public virtual List<HardSkill>? HardSkills { get; set; }
}
