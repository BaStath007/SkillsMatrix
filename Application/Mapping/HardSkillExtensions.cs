using Application.DTOs;
using Domain;

namespace Application.Mapping;

public static class HardSkillExtensions
{
    public static HardSkill ToDomain(HardSkillCreateDTO model)
    {
        return new HardSkill
        {
            Name = model.Name,
            Description = model.Description,
            Version = model.Version,
            Nodes = model.HardSkills,
            Tags = model.Tags,
            Categories = model.Categories
        };
    }
}
