using Domain.Entities.JoinEntities;
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
            ICollection<CategoryPerTeam>? categoriesPerTeam
        ) : base(createdBy)
    {
        Description = description;
        CategoriesPerTeam = categoriesPerTeam;
    }

    public Description Description { get; private set; } = default!;

    // Navigation Properties
    public virtual ICollection<CategoryPerTeam>? CategoriesPerTeam { get; private set; }

    public static TeamCategory Create
        (
            string createdBy, Description description,
            ICollection<CategoryPerTeam>? categoriesPerTeam
        )
        => new TeamCategory
        (
            createdBy, description, categoriesPerTeam
        );
}
