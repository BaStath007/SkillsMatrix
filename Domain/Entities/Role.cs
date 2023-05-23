using Domain.Entities.JoinEntities;
using Domain.Primitives;
using Domain.Shared;
using Domain.ValueObjects;

namespace Domain.Entities;

public class Role : Entity
{
    public Role(string createdBy)
        :base(createdBy)
    {
        
    }
    private Role(string createdBy, Option<Description> description, 
        Option<ICollection<Employee>> employees, Option<ICollection<TeamRole>> teamRoles,
        Option<ICollection<RoleSkill>> roleSkills)
        : base(createdBy)
    {
        Description = description;
        Employees = employees;
        TeamRoles = teamRoles;
        RoleSkills = roleSkills;
    }

    public Option<Description> Description { get; set; }

    // Navigation Properties
    public virtual Option<ICollection<Employee>> Employees { get; set; }
    public virtual Option<ICollection<TeamRole>> TeamRoles { get; set; }
    public virtual Option<ICollection<RoleSkill>> RoleSkills { get; set; }

    public static Role Create(
        string createdBy, Option<Description> description, Option<ICollection<Employee>> employees,
        Option<ICollection<TeamRole>> teamRoles, Option<ICollection<RoleSkill>> roleSkills)
        => new(
            createdBy, description,
            employees, teamRoles, roleSkills);
}
