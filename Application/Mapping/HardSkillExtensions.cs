using Application.DTOs;
using Domain;

namespace Application.Mapping;

public static class HardSkillExtensions
{
    public static HardSkill CreateToDomain(HardSkillCreateDTO entity)
    {
        return new HardSkill
        {
            Name = entity.Name,
            Description = entity.Description,
            Version = entity.Version,
            Nodes = entity.HardSkills,
            Tags = entity.Tags,
            Categories = entity.Categories
        };
    }

    public static HardSkill UpdateToDomain(HardSkillUpdateDTO entity)
    {
        return new HardSkill
        {
            Id = entity.Id,
            Name = entity.Name,
            Description = entity.Description,
            Version = entity.Version,
            Nodes = entity.HardSkills,
            Tags = entity.Tags,
            Categories = entity.Categories
        };
    }

    public static HardSkillGetDTO GetToApplication(HardSkill entity)
    {
        return new HardSkillGetDTO
        {
            Id = entity.Id,
            Name = entity.Name,
            Description = entity.Description,
            Version = entity.Version,
            HardSkills = entity.Nodes,
            Tags = entity.Tags,
            Categories = entity.Categories
        };
    }
}
