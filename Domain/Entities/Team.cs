using Domain.Entities.JoinEntities;
using Domain.Enums;
using Domain.Primitives;
using Domain.ValueObjects;

namespace Domain.Entities;

public class Team : Entity
{
    private Team(string createdBy)
        : base(createdBy)
    {
        
    }
    private Team(string createdBy, Guid? parentTeamId,
        Description description, TeamType teamType,
        Team? parentTeam, ICollection<Team>? childrenTeams,
        ICollection<Employee>? employees, ICollection<TeamRole>? teamRoles,
        ICollection<CategoryPerTeam>? categoriesPerTeam)
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

    public Guid? ParentTeamId { get; private set; } = Guid.Empty;
    public Description Description { get; private set; } = default!;
    public TeamType TeamType { get; private set; } = TeamType.None;

    // Navigation Properties
    public Team? ParentTeam { get; private set; }
    public ICollection<Team>? ChildrenTeams { get; private set; }
    public ICollection<Employee>? Employees { get; private set; }
    public ICollection<TeamRole>? TeamRoles { get; private set; }
    public ICollection<CategoryPerTeam>? CategoriesPerTeam { get; private set; }

    public static Team Create(
        string createdBy, Guid? parentTeamId, Description description,
        TeamType teamType, Team? ParentTeam, ICollection<Team>? childrenTeams,
        ICollection<Employee>? employees, ICollection<TeamRole>? teamRole,
        ICollection<CategoryPerTeam>? categoriesPerTeam)
            => new(
                createdBy, parentTeamId,
            description, teamType, ParentTeam,
            childrenTeams, employees, teamRole,
            categoriesPerTeam);
}
