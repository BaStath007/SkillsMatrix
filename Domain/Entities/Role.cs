using Domain.Entities.JoinEntities;
using Domain.Primitives;
using Domain.ValueObjects;

namespace Domain.Entities;

public class Role : Entity
{
    private Role(string createdBy)
        :base(createdBy)
    {
        
    }
    private Role(string createdBy, Description description, 
        ICollection<Employee>? employees, ICollection<TeamRole>? teamRoles,
        ICollection<RoleSkill>? roleSkills)
        : base(createdBy)
    {
        Description = description;
        Employees = employees;
        TeamRoles = teamRoles;
        RoleSkills = roleSkills;
    }

    public Description Description { get; private set; } = default!;

    // Navigation Properties
    public virtual ICollection<Employee>? Employees { get; private set; }
    public virtual ICollection<TeamRole>? TeamRoles { get; private set; }
    public virtual ICollection<RoleSkill>? RoleSkills { get; private set; }

    public static Role Create(
        string createdBy, Description description, ICollection<Employee>? employees,
        ICollection<TeamRole>? teamRoles, ICollection<RoleSkill>? roleSkills)
        => new(
            createdBy, description,
            employees, teamRoles, roleSkills);
}
