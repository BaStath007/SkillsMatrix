using GenericDomain;

namespace Domain.Helpers;

/// <summary>
/// 
/// Helper class for implementing our BL i.e. a Soft Skill is composed by some traits.
/// In order to verify that you have a certain Soft Skill you need to have certain traits,
/// each one at a spesific degree.
/// 
/// </summary>
public sealed class Trait : BaseClass
{

    // Navigation Properties
    public SoftSkill? SoftSkill { get; set; } // Leadership
    public Trait()
    {

    }
}
