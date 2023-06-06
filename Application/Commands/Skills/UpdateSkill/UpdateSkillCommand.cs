using Application.Commands.Common;
using Domain.Entities;
using Domain.Entities.JoinEntities;
using Domain.Enums;
using Domain.ValueObjects;

namespace Application.Commands.Skills.UpdateSkill;

public sealed record UpdateSkillCommand
    (
        Guid Id, string CreatedBy, string? UpdatedBy, bool? IsActive,
        Guid? ParentSkillId, Description Description, SkillType SkillType, Skill? ParentSkill,
        ICollection<Skill>? ChildrenSkills, ICollection<EmployeeSkill>? EmployeeSkills,
        ICollection<RoleSkill>? RoleSkills, ICollection<CategoryPerSkill>? CategoriesPerSkill
    ) : ICommand;
