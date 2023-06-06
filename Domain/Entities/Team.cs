using Domain.Entities.JoinEntities;
using Domain.Enums;
using Domain.Primitives;
using Domain.ValueObjects;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities;

public class Team : Entity
{
    public Team(string createdBy)
        : base(createdBy)
    {
        
    }
    private Team(string createdBy, Guid parentTeamId,
        Description description, TeamType teamType,
        Team parentTeam, ICollection<Team> childrenTeams,
        ICollection<Employee> employees, ICollection<TeamRole> teamRoles,
        ICollection<CategoryPerTeam> categoriesPerTeam)
        : base(createdBy)
    {
        ParentTeamId = parentTeamId;
        Description = description;
        TeamType = teamType;
        ParentTeam = parentTeam;
        ChildrenTeams = childrenTeams;
        Employees = employees;
        TeamRoles = teamRoles;
        CategoriesPerTeam = categoriesPerTeam;
    }

    public Guid ParentTeamId { get; set; } = Guid.Empty;
    [NotMapped]
    public Description Description { get; set; }
    public TeamType TeamType { get; set; } = TeamType.None;

    // Navigation Properties
    public Team ParentTeam { get; set; }
    public ICollection<Team> ChildrenTeams { get; set; }
    public ICollection<Employee> Employees { get; set; }
    public ICollection<TeamRole> TeamRoles { get; set; }
    public ICollection<CategoryPerTeam> CategoriesPerTeam { get; set; }

    public static Team Create(
        string createdBy, Guid parentTeamId, Description description,
        TeamType teamType, Team ParentTeam, ICollection<Team> childrenTeams,
        ICollection<Employee> employees, ICollection<TeamRole> teamRole,
        ICollection<CategoryPerTeam> categoriesPerTeam)
            => new(
                createdBy, parentTeamId,
            description, teamType, ParentTeam,
            childrenTeams, employees, teamRole,
            categoriesPerTeam);
}
