using Domain;
using Domain.Helpers;

namespace Application.DTOs;

public sealed class HardSkillDeleteDTO
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }
    public string? Version { get; set; }
    public List<HardSkill>? HardSkills { get; set; }
    public List<Tag>? Tags { get; set; }
    public List<HardSkillCategory>? Categories { get; set; }

    public HardSkillDeleteDTO()
    {

    }
    public HardSkillDeleteDTO
        (
            int id,
            string name,
            string? description,
            string? version,
            List<HardSkill>? hardSkills,
            List<Tag>? tags,
            List<HardSkillCategory>? categories
        )
    {
        Id = id;
        Name = name;
        Description = description;
        Version = version;
        HardSkills = hardSkills;
        Tags = tags;
        Categories = categories;
    }
}
