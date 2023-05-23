using Application.Commands.Common;
using Domain.Entities;
using Domain.Entities.JoinEntities;
using Domain.Enums;
using Domain.Shared;
using Domain.ValueObjects;

namespace Application.Commands.Skills.CreateSkill;

public sealed record CreateSkillCommand
    (
        string CreatedBy, Guid ParentSkillId,
        string Description,
        SkillType SkillType, Skill ParentSkill,
        ICollection<Skill> ChildrenSkills,
        ICollection<EmployeeSkill> EmployeeSkills,
        ICollection<RoleSkill> RoleSkills,
        ICollection<CategoryPerSkill> CategoriesPerSkill
    ) : ICommand;