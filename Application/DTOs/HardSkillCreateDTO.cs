using Domain;
using Domain.Helpers;

namespace Application.DTOs;

public sealed class HardSkillCreateDTO
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }
    public string? Version { get; set; }
    public List<HardSkill>? HardSkills { get; set; }
    public List<Tag>? Tags { get; set; }
    public List<HardSkillCategory>? Categories { get; set; }

    public HardSkillCreateDTO()
    {
        
    }
    public HardSkillCreateDTO(
        string name,
        string? description,
        string? version,
        List<HardSkill>? hardSkills,
        List<Tag>? tags,
        List<HardSkillCategory>? categories
        )
    {
        Name = name;
        Description = description;
        Version = version;
        HardSkills = hardSkills;
        Tags = tags;
        Categories = categories;
    }
}
