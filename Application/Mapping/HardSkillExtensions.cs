using Application.DTOs;
using Domain.Entities;

namespace Application.Mapping;

public static class HardSkillExtensions
{
    public static Skill CreateToDomain(SkillCreateDTO skill)
    {
        var skillDTO = Skill.Create(skill.CreatedBy.Map(s => s).Reduce(string.Empty),
            skill.ParentSkillId, skill.Description.Map(s => s).Reduce(null!),
            skill.SkillType, skill.ParentSkill.Map(s => s).Reduce(null!),
            skill.ChildrenSkills.Map(s => s).Reduce(null!),
            skill.EmployeeSkills.Map(s => s).Reduce(null!),
            skill.RoleSkills.Map(s => s).Reduce(null!),
            skill.CategoriesPerSkill.Map(s => s).Reduce(null!));
        return skillDTO;
    }

    public static Skill UpdateToDomain(SkillUpdateDTO skill)
    {
        return Skill.Update(skill.UpdatedAt, skill.DeletedAt,
            skill.CreatedBy.Map(s => s).Reduce(string.Empty),
            skill.UpdatedBy.Map(s => s).Reduce(string.Empty),
            skill.DeletedBy.Map(s => s).Reduce(string.Empty),
            skill.IsActive, skill.IsDeleted, skill.ParentSkillId,
        skill.Description.Map(s => s).Reduce(null!), skill.SkillType,
        skill.ParentSkill.Map(s => s).Reduce(null!),
        skill.ChildrenSkills.Map(s => s).Reduce(null!),
        skill.EmployeeSkills.Map(s => s).Reduce(null!),
        skill.RoleSkills.Map(s => s).Reduce(null!),
        skill.CategoriesPerSkill.Map(s => s).Reduce(null!));
    }

    public static SkillGetDTO? GetSkillToApplication(Skill? skill)
    {
        if (skill == null) return null;
        return new SkillGetDTO(skill.Id, skill.CreatedAt, skill.UpdatedAt,
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
            var skillDTO = new SkillGetDTO(domainSkill.Id, domainSkill.CreatedAt, domainSkill.UpdatedAt,
            domainSkill.DeletedAt, domainSkill.CreatedBy, domainSkill.UpdatedBy,
            domainSkill.DeletedBy, domainSkill.IsActive, domainSkill.IsDeleted,
            domainSkill.ParentSkillId, domainSkill.Description, domainSkill.SkillType,
            domainSkill.ParentSkill, domainSkill.ChildrenSkills, domainSkill.EmployeeSkills,
            domainSkill.RoleSkills, domainSkill.CategoriesPerSkill);
            skillDTOs.Add(skillDTO);
        }
        return skillDTOs;
    }
}
