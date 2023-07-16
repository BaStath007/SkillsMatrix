using Application.DTOs.SkillDTOs;
using Domain.Entities;

namespace Application.Mapping;

public static class SkillExtensions
{
    public static Skill CreateToDomain(SkillCreateDTO skillDTO)
    {
        Skill skill = Skill.Create
            (
                skillDTO.CreatedBy, skillDTO.IsActive,
                skillDTO.ParentSkillId, skillDTO.Description,
                skillDTO.SkillType,
                skillDTO.ChildrenSkills,
                skillDTO.Employees,
                skillDTO.Positions,
                skillDTO.SkillCategories
            );
        return skill;
    }

    public static Skill UpdateToDomain(SkillUpdateDTO skillDTO)
    {
        return Skill.Update
            ( 
                skillDTO.Id, skillDTO.CreatedAt, skillDTO.UpdatedAt, skillDTO.DeletedAt,
                skillDTO.CreatedBy, skillDTO.UpdatedBy, skillDTO.DeletedBy,
                skillDTO.IsActive, skillDTO.IsDeleted, skillDTO.ParentSkillId,
                skillDTO.Description, skillDTO.SkillType,
                skillDTO.ChildrenSkills,
                skillDTO.Employees,
                skillDTO.Positions,
                skillDTO.SkillCategories
            );
    }

    public static Skill DeleteToDomain(SkillDeleteDTO skillDTO)
    {
        return Skill.Update
            (
                skillDTO.Id, skillDTO.CreatedAt, skillDTO.UpdatedAt, skillDTO.DeletedAt,
                skillDTO.CreatedBy, skillDTO.UpdatedBy, skillDTO.DeletedBy,
                skillDTO.IsActive, skillDTO.IsDeleted, skillDTO.ParentSkillId,
                skillDTO.Description, skillDTO.SkillType,
                skillDTO.ChildrenSkills,
                skillDTO.Employees,
                skillDTO.Positions,
                skillDTO.SkillCategories
            );
    }

    public static SkillGetDTO? GetSkillToApplication(Skill? skill)
    {
        if (skill is null) return null;

        return SkillGetDTO.Create
            (
                skill.Id, skill.CreatedAt, skill.UpdatedAt,
                skill.DeletedAt, skill.CreatedBy, skill.UpdatedBy,
                skill.DeletedBy, skill.IsActive, skill.IsDeleted,
                skill.ParentSkillId, skill.Description, skill.SkillType,
                skill.ParentSkill, skill.ChildrenSkills, skill.Employees,
                skill.Positions, skill.SkillCategories
            );
    }

    public static List<SkillGetDTO> GetAllSkillsToApplication(List<Skill> dbSkills)
    {
        var skillDTOs = new List<SkillGetDTO>();
        foreach (var domainSkill in dbSkills)
        {
            var skillDTO = SkillGetDTO.Create
                (
                    domainSkill.Id, domainSkill.CreatedAt, domainSkill.UpdatedAt,
                    domainSkill.DeletedAt, domainSkill.CreatedBy, domainSkill.UpdatedBy,
                    domainSkill.DeletedBy, domainSkill.IsActive, domainSkill.IsDeleted,
                    domainSkill.ParentSkillId, domainSkill.Description, domainSkill.SkillType,
                    domainSkill.ParentSkill, domainSkill.ChildrenSkills, domainSkill.Employees,
                    domainSkill.Positions, domainSkill.SkillCategories
                );
            skillDTOs.Add(skillDTO);
        }
        return skillDTOs;
    }

    public static Skill? GetToDomain(SkillGetDTO? skillGetDTO)
    {
        if (skillGetDTO == null) return null;
        return Skill.Update
                (
                    skillGetDTO.Id, skillGetDTO.CreatedAt, skillGetDTO.UpdatedAt, skillGetDTO.DeletedAt,
                    skillGetDTO.CreatedBy, skillGetDTO.UpdatedBy, skillGetDTO.DeletedBy,
                    skillGetDTO.IsActive, skillGetDTO.IsDeleted, skillGetDTO.ParentSkillId,
                    skillGetDTO.Description, skillGetDTO.SkillType,
                    skillGetDTO.ChildrenSkills,
                    skillGetDTO.Employees,
                    skillGetDTO.Positions,
                    skillGetDTO.SkillCategories
                );
        
    }
}
