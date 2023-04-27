using GenericDomain;

namespace Domain.Helpers;

/// <summary>
/// 
/// Helper class for a possible feature which showcases the relevant info about a certain (class)skill,
/// like a similar skill or hyper/sub-category etc.
/// 
/// </summary>
public sealed class Tag : BaseClass
{

    // Navigation Properties
    public HardSkill? HardSkill { get; set; } // C#
    public Tag()
    {

    }
}
