﻿namespace Domain.Entities.JoinEntities;

public class TeamRole
{
    private TeamRole()
    {
        
    }
    private TeamRole
        (
            Guid teamId, Guid roleId,
            Team team, Role role
        )
    {
        TeamId = teamId;
        RoleId = roleId;
        Team = team;
        Role = role;
    }

    public Guid TeamId { get; set; } = Guid.Empty;
    public Guid RoleId { get; set; } = Guid.Empty;

    // Navigation Properties
    public virtual Team Team { get; set; } = default!;
    public virtual Role Role { get; set; } = default!;

    public static TeamRole Create
        (
            Guid teamId, Guid roleId,
            Team team, Role role
        ) 
        => new TeamRole
        (
            teamId, roleId, team, role
        );
}
