using Application.Commands.Common;
using Domain.Entities;
using Domain.Entities.JoinEntities;
using Domain.Enums;
using Domain.Shared;
using Domain.ValueObjects;

namespace Application.Commands.Skills.CreateSkill;

public sealed record CreateSkillCommand
    (
        Option<string> CreatedBy, Guid ParentSkillId,
        Option<Description> Description,
        SkillType SkillType, Option<Skill> ParentSkill,
        Option<ICollection<Skill>> ChildrenSkills,
        Option<ICollection<EmployeeSkill>> EmployeeSkills,
        Option<ICollection<RoleSkill>> RoleSkills,
        Option<ICollection<CategoryPerSkill>> CategoriesPerSkill
    ) : ICommand;