namespace Domain.Entities.JoinEntities;

public class CategoryPerTeam
{
    public CategoryPerTeam()
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
    public virtual Team Team { get; set; }
    public virtual TeamCategory TeamCategory { get; set; }

    public static CategoryPerTeam Create(Guid teamId, Guid teamCategoryId,
        Team team, TeamCategory teamCategory)
            => new(teamId, teamCategoryId, team, teamCategory);
}
