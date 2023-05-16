using Domain.Shared;

namespace Domain.Entities.JoinEntities;

public class CategoryPerTeam
{
    private CategoryPerTeam(Guid teamId, Guid teamCategoryId, 
        Option<Team> team, Option<TeamCategory> teamCategory)
    {
        TeamId = teamId;
        TeamCategoryId = teamCategoryId;
        Team = team;
        TeamCategory = teamCategory;
    }

    public Guid TeamId { get; set; } = Guid.Empty;
    public Guid TeamCategoryId { get; set; } = Guid.Empty;

    // Navigation Properties
    public virtual Option<Team> Team { get; set; }
    public virtual Option<TeamCategory> TeamCategory { get; set; }

    public static CategoryPerTeam Create(Guid teamId, Guid teamCategoryId,
        Option<Team> team, Option<TeamCategory> teamCategory)
            => new(teamId, teamCategoryId, team, teamCategory);
}
