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
    public HardSkill? Hardskill { get; }

    public Tag()
    {

    }

    //public Tag(string name, string? description, HardSkill? hardskill)
    //{
    //    Name = name;
    //    Description = description;
    //    Hardskill = hardskill;
    //}

    //public Tag(int id, string name, string? description, HardSkill? hardskill)
    //{
    //    Id = id;
    //    Name = name;
    //    Description = description;
    //    Hardskill = hardskill;
    //}
}
