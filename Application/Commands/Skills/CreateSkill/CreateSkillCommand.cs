using Application.Commands.Common;
using Domain.Entities;

namespace Application.Commands.Skills.CreateSkill;

public sealed record CreateSkillCommand
    (
        string CreatedBy, bool IsActive,
        Guid ParentSkillId,
        string Description,
        string SkillType,
        ICollection<Skill> ChildrenSkills,
        ICollection<Employee> Employees,
        ICollection<Position> Positions,
        ICollection<SkillCategory> SkillCategories
    ) : ICommand<Guid>;