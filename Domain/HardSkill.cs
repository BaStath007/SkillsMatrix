using Domain.Helpers;
using Domain.Versions;
using GenericDomain;

namespace Domain;

public sealed class HardSkill : HardSkillNode_1_0
{
    public HardSkill()
    {
        
    }
    public HardSkill(
        int id,
        string name,
        string? description,
        string? version,
        Dictionary<int, HardSkillNode_1_0>? nodes,
        List<Tag>? tags,
        HardSkillCategory? category
        )
    {
        Id = id;
        Name = name;
        Description = description;
        Version = version;
        Nodes = nodes;
        Tags = tags;
        Category = category;
    }

}
