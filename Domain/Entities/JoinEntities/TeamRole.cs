using Domain.Shared;

namespace Domain.Entities.JoinEntities;

public class TeamRole
{
    public TeamRole()
    {
        
    }
    private TeamRole(Guid teamId, Guid roleId, Option<Team> team, Option<Role> role)
    {
        TeamId = teamId;
        RoleId = roleId;
        Team = team;
        Role = role;
    }

    public Guid TeamId { get; set; } = Guid.Empty;
    public Guid RoleId { get; set; } = Guid.Empty;

    // Navigation Properties
    public virtual Option<Team> Team { get; set; }
    public virtual Option<Role> Role { get; set; }

    public static TeamRole Create(Guid teamId, Guid roleId, Option<Team> team,
        Option<Role> role) 
            => new(teamId, roleId, team, role);
}
