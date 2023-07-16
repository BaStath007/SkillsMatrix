using Domain.Primitives;
using Domain.ValueObjects;

namespace Domain.Entities;

public class TeamCategory : Entity
{
    private TeamCategory(string createdBy)
        : base(createdBy)
    {
        
    }
    private TeamCategory
        (
            string createdBy, Description description, 
            ICollection<Team>? teams
        ) : base(createdBy)
    {
        Description = description;
        Teams = teams;
    }

    public Description Description { get; private set; } = default!;

    // Navigation Properties
    public virtual ICollection<Team>? Teams { get; private set; }

    public static TeamCategory Create
        (
            string createdBy, Description description,
            ICollection<Team>? teams
        )
        => new TeamCategory
        (
            createdBy, description, teams
        );
}
