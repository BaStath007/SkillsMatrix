using Application.DTOs.SkillDTOs;
using Domain.Entities;

namespace Application.Mapping;

public static class SkillExtensions
{
    public static Skill CreateToDomain(SkillCreateDTO skill)
    {
        Skill skillDTO = Skill.Create
            (
                skill.CreatedBy,
                skill.ParentSkillId, skill.Description,
                skill.SkillType,
                skill.ChildrenSkills,
                skill.EmployeeSkills,
                skill.RoleSkills,
                skill.CategoriesPerSkill
            );
        return skillDTO;
    }

    public static Skill UpdateToDomain(SkillUpdateDTO skill)
    {
        return Skill.Update
            ( 
                skill.Id, skill.CreatedAt, skill.UpdatedAt, skill.DeletedAt,
                skill.CreatedBy, skill.UpdatedBy, skill.DeletedBy,
                skill.IsActive, skill.IsDeleted, skill.ParentSkillId,
                skill.Description, skill.SkillType,
                skill.ChildrenSkills,
                skill.EmployeeSkills,
                skill.RoleSkills,
                skill.CategoriesPerSkill
            );
    }

    public static Skill DeleteToDomain(SkillDeleteDTO skill)
    {
        return Skill.Update
            (
                skill.Id, skill.CreatedAt, skill.UpdatedAt, skill.DeletedAt,
                skill.CreatedBy, skill.UpdatedBy, skill.DeletedBy,
                skill.IsActive, skill.IsDeleted, skill.ParentSkillId,
                skill.Description, skill.SkillType,
                skill.ChildrenSkills,
                skill.EmployeeSkills,
                skill.RoleSkills,
                skill.CategoriesPerSkill
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
                skill.ParentSkill, skill.ChildrenSkills, skill.EmployeeSkills,
                skill.RoleSkills, skill.CategoriesPerSkill
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
                    domainSkill.ParentSkill, domainSkill.ChildrenSkills, domainSkill.EmployeeSkills,
                    domainSkill.RoleSkills, domainSkill.CategoriesPerSkill
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
                    skillGetDTO.EmployeeSkills,
                    skillGetDTO.RoleSkills,
                    skillGetDTO.CategoriesPerSkill
                );
        
    }
}
