using Domain.Entities.JoinEntities;
using Domain.Enums;
using Domain.Primitives;
using Domain.Shared;
using Domain.ValueObjects;

namespace Domain.Entities;

public class Team : Entity
{
    private Team(Option<string> createdBy, Guid parentTeamId,
        Option<Description> description, TeamType teamType,
        Option<Team> parentTeam, Option<ICollection<Team>> childrenTeams,
        Option<ICollection<Employee>> employees, Option<ICollection<TeamRole>> teamRoles,
        Option<ICollection<CategoryPerTeam>> categoriesPerTeam)
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
    public Option<Description> Description { get; set; }
    public TeamType TeamType { get; set; } = TeamType.None;

    // Navigation Properties
    public Option<Team> ParentTeam { get; set; }
    public Option<ICollection<Team>> ChildrenTeams { get; set; }
    public Option<ICollection<Employee>> Employees { get; set; }
    public Option<ICollection<TeamRole>> TeamRoles { get; set; }
    public Option<ICollection<CategoryPerTeam>> CategoriesPerTeam { get; set; }

    public static Team Create(
        Option<string> createdBy, Guid parentTeamId, Option<Description> description,
        TeamType teamType, Option<Team> ParentTeam, Option<ICollection<Team>> childrenTeams,
        Option<ICollection<Employee>> employees, Option<ICollection<TeamRole>> teamRole,
        Option<ICollection<CategoryPerTeam>> categoriesPerTeam)
            => new(
                createdBy, parentTeamId,
            description, teamType, ParentTeam,
            childrenTeams, employees, teamRole,
            categoriesPerTeam);
}
