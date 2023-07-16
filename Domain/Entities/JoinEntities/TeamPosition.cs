namespace Domain.Entities.JoinEntities;

public class TeamPosition
{
    private TeamPosition()
    {
        
    }
    private TeamPosition
        (
            Guid teamId, Guid positionId,
            Team team, Position position
        )
    {
        TeamId = teamId;
        PositionId = positionId;
        Team = team;
        Position = position;
    }

    public Guid TeamId { get; set; } = Guid.Empty;
    public Guid PositionId { get; set; } = Guid.Empty;

    // Navigation Properties
    public virtual Team Team { get; set; } = default!;
    public virtual Position Position { get; set; } = default!;

    public static TeamPosition Create
        (
            Guid teamId, Guid positionId,
            Team team, Position position
        ) 
        => new TeamPosition
        (
            teamId, positionId, team, position
        );
}
