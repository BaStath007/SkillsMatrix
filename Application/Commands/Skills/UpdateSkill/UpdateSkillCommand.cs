using Application.Commands.Common;
using Domain.Entities;

namespace Application.Commands.Skills.UpdateSkill;

public sealed record UpdateSkillCommand
    (
        Guid Id, string UpdatedBy, bool IsActive,
        Guid ParentSkillId, string Description, string SkillType,
        ICollection<Skill> ChildrenSkills, ICollection<Employee> Employees,
        ICollection<Position> Positions, ICollection<SkillCategory> SkillCategories
    ) : ICommand;
