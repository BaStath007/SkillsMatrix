using Domain.Entities.JoinEntities;
using Domain.Primitives;
using Domain.Shared;
using Domain.ValueObjects;

namespace Domain.Entities;

public class TeamCategory : Entity
{
    public TeamCategory(string createdBy)
        : base(createdBy)
    {
        
    }
    private TeamCategory(string createdBy, Option<Description> description, 
        Option<ICollection<CategoryPerTeam>> categoriesPerTeam)
        : base(createdBy)
    {
        Description = description;
        CategoriesPerTeam = categoriesPerTeam;
    }

    public Option<Description> Description { get; set; }

    // Navigation Properties
    public virtual Option<ICollection<CategoryPerTeam>> CategoriesPerTeam { get; set; }

    public static TeamCategory Create(string createdBy, Option<Description> description,
        Option<ICollection<CategoryPerTeam>> categoriesPerTeam)
        => new(createdBy, description, categoriesPerTeam);
}
