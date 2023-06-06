using Domain.Entities.JoinEntities;
using Domain.Primitives;
using Domain.ValueObjects;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities;

public class Role : Entity
{
    public Role(string createdBy)
        :base(createdBy)
    {
        
    }
    private Role(string createdBy, Description description, 
        ICollection<Employee> employees, ICollection<TeamRole> teamRoles,
        ICollection<RoleSkill> roleSkills)
        : base(createdBy)
    {
        Description = description;
        Employees = employees;
        TeamRoles = teamRoles;
        RoleSkills = roleSkills;
    }

    [NotMapped]
    public Description Description { get; set; }

    // Navigation Properties
    public virtual ICollection<Employee> Employees { get; set; }
    public virtual ICollection<TeamRole> TeamRoles { get; set; }
    public virtual ICollection<RoleSkill> RoleSkills { get; set; }

    public static Role Create(
        string createdBy, Description description, ICollection<Employee> employees,
        ICollection<TeamRole> teamRoles, ICollection<RoleSkill> roleSkills)
        => new(
            createdBy, description,
            employees, teamRoles, roleSkills);
}
