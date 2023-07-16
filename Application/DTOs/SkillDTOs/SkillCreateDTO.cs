using Domain.Entities;
using Domain.Enums;
using Domain.ValueObjects;

namespace Application.DTOs.SkillDTOs;

public sealed class SkillCreateDTO
{
    public string CreatedBy { get; private init; }
    public bool IsActive { get; private init; }
    public Guid ParentSkillId { get; private init; }
    public Description Description { get; private init; }
    public SkillType SkillType { get; private init; }
    public ICollection<Skill> ChildrenSkills { get; private init; }
    public ICollection<Employee> Employees { get; private init; }
    public ICollection<Position> Positions { get; private init; }
    public ICollection<SkillCategory> SkillCategories { get; private init; }

    private SkillCreateDTO
        (
            string createdBy, bool isActive,
            Guid parentSkillId,
            Description description,
            SkillType skillType,
            ICollection<Skill> childrenSkills,
            ICollection<Employee> employees,
            ICollection<Position> positions,
            ICollection<SkillCategory> skillCategories
        )
    {
        CreatedBy = createdBy;
        IsActive = isActive;
        ParentSkillId = parentSkillId;
        Description = description;
        SkillType = skillType ?? SkillType.None;
        ChildrenSkills = childrenSkills;
        Employees = employees;
        Positions = positions;
        SkillCategories = skillCategories;
    }

    public static SkillCreateDTO Create
        (
            string createdBy, bool isActive,
            Guid parentSkillId,
            Description description,
            SkillType skillType,
            ICollection<Skill> childrenSkills,
            ICollection<Employee> employees,
            ICollection<Position> positions,
            ICollection<SkillCategory> skillCategories
        )
        => new
        (
            createdBy, isActive, parentSkillId,
            description, skillType,
            childrenSkills, employees,
            positions,
            skillCategories
        );
}
