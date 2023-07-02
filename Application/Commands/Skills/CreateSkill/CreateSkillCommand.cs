using Application.Commands.Common;
using Domain.Entities;
using Domain.Entities.JoinEntities;

namespace Application.Commands.Skills.CreateSkill;

public sealed record CreateSkillCommand
    (
        string CreatedBy, bool IsActive,
        Guid ParentSkillId,
        string Description,
        string SkillType,
        ICollection<Skill> ChildrenSkills,
        ICollection<EmployeeSkill> EmployeeSkills,
        ICollection<RoleSkill> RoleSkills,
        ICollection<CategoryPerSkill> CategoriesPerSkill
    ) : ICommand<Guid>;