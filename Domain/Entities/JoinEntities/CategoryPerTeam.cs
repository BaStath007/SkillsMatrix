namespace Domain.Entities.JoinEntities;

public class CategoryPerTeam
{
    private CategoryPerTeam()
    {
        
    }
    private CategoryPerTeam(Guid teamId, Guid teamCategoryId, 
        Team team, TeamCategory teamCategory)
    {
        TeamId = teamId;
        TeamCategoryId = teamCategoryId;
        Team = team;
        TeamCategory = teamCategory;
    }

    public Guid TeamId { get; set; } = Guid.Empty;
    public Guid TeamCategoryId { get; set; } = Guid.Empty;

    // Navigation Properties
    public virtual Team Team { get; set; } = default!;
    public virtual TeamCategory TeamCategory { get; set; } = default!; 

    public static CategoryPerTeam Create(Guid teamId, Guid teamCategoryId,
        Team team, TeamCategory teamCategory)
            => new(teamId, teamCategoryId, team, teamCategory);
}
