using Application.Commands.Common;
using Domain.Entities;
using Domain.Entities.JoinEntities;
using Domain.Enums;

namespace Application.Commands.Skills.CreateSkill;

public sealed record CreateSkillCommand
    (
        string CreatedBy, bool IsActive,
        Guid ParentSkillId,
        string Description,
        SkillType SkillType,
        ICollection<Skill> ChildrenSkills,
        ICollection<EmployeeSkill> EmployeeSkills,
        ICollection<RoleSkill> RoleSkills,
        ICollection<CategoryPerSkill> CategoriesPerSkill
    ) : ICommand;