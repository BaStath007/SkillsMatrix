using Application.Commands.Common;
using Domain.Entities.JoinEntities;
using Domain.Entities;
using Domain.Enums;
using Domain.Shared;
using Domain.ValueObjects;

namespace Application.Commands.Skills.UpdateSkill;

public sealed record UpdateSkillCommand
    (
        Guid IdProvidedByUser, Guid OriginalId, DateTime CreatedAt, DateTime UpdatedAt,
        DateTime DeletedAt, Option<string> CreatedBy, Option<string> UpdatedBy,
        Option<string> DeletedBy, bool IsActive, bool IsDeleted, Guid ParentSkillId,
        Option<Description> Description, SkillType SkillType, Option<Skill> ParentSkill,
        Option<ICollection<Skill>> ChildrenSkills, Option<ICollection<EmployeeSkill>> EmployeeSkills,
        Option<ICollection<RoleSkill>> RoleSkills, Option<ICollection<CategoryPerSkill>> CategoriesPerSkill
    ) : ICommand;
