﻿using Domain.Helpers;
using Domain.Versions;
using GenericDomain;

namespace Domain;

public class HardSkill : NodeModel<HardSkill>, IHardSkill_1_0
{
    public HardSkill()
    {
        
    }
    public HardSkill(
        string name,
        string? description,
        string? version,
        List<HardSkill>? nodes,
        List<Tag>? tags,
        List<HardSkillCategory>? categories
        )
    {
        Name = name;
        Description = description;
        Version = version;
        Nodes = nodes;
        Tags = tags;
        Categories = categories;
    }

    public string? Version { get; set; }

    // Navigation Properties
    public virtual List<Tag>? Tags { get; set; }
    public virtual List<HardSkillCategory>? Categories { get; set; }
}
