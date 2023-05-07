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

    public static HardSkillGetDTO? GetHSToApplication(HardSkill? entity)
    {
        if (entity == null) return null;

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

    public static List<HardSkillGetDTO> GetAllHSToApplication(List<HardSkill> dbHardSkills)
    {
        var hardSkills = new List<HardSkillGetDTO>();
        foreach (var dbHardSkill in dbHardSkills)
        {
            var hardSkill = new HardSkillGetDTO
                (
                    dbHardSkill.Id,
                    dbHardSkill.Name,
                    dbHardSkill.Description,
                    dbHardSkill.Version,
                    dbHardSkill.Nodes,
                    dbHardSkill.Tags,
                    dbHardSkill.Categories
                );
            hardSkills.Add(hardSkill);
        }
        return hardSkills;
    }

    public static HardSkill DeleteToDomain(HardSkillDeleteDTO entity)
    {
        return new HardSkill
        {
            Id = entity.Id
        };
    }
}
