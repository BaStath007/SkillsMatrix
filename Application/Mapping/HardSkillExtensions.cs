using Application.DTOs;
using Domain.Entities;

namespace Application.Mapping;

public static class HardSkillExtensions
{
    public static Skill CreateToDomain(SkillCreateDTO skill)
    {
        return Skill.Create(skill.CreatedBy, skill.ParentSkillId, skill.Description,
            skill.SkillType, skill.ParentSkill, skill.ChildrenSkills,
            skill.EmployeeSkills, skill.RoleSkills, skill.CategoriesPerSkill);
    }

    public static Skill UpdateToDomain(SkillUpdateDTO skill)
    {
        return Skill.Update(skill.UpdatedAt, skill.DeletedAt, skill.CreatedBy, skill.UpdatedBy,
        skill.DeletedBy, skill.IsActive, skill.IsDeleted, skill.ParentSkillId,
        skill.Description, skill.SkillType, skill.ParentSkill,
        skill.ChildrenSkills, skill.EmployeeSkills,
        skill.RoleSkills, skill.CategoriesPerSkill);
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
        var skills = new List<SkillGetDTO>();
        foreach (var dbSkill in dbSkills)
        {
            var skill = new SkillGetDTO(dbSkill.Id, dbSkill.CreatedAt, dbSkill.UpdatedAt,
            dbSkill.DeletedAt, dbSkill.CreatedBy, dbSkill.UpdatedBy,
            dbSkill.DeletedBy, dbSkill.IsActive, dbSkill.IsDeleted,
            dbSkill.ParentSkillId, dbSkill.Description, dbSkill.SkillType,
            dbSkill.ParentSkill, dbSkill.ChildrenSkills, dbSkill.EmployeeSkills,
            dbSkill.RoleSkills, dbSkill.CategoriesPerSkill);
            skills.Add(skill);
        }
        return skills;
    }
}
