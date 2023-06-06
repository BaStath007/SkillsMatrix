using Domain.Entities.JoinEntities;
using Domain.Primitives;
using Domain.ValueObjects;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities;

public class TeamCategory : Entity
{
    public TeamCategory(string createdBy)
        : base(createdBy)
    {
        
    }
    private TeamCategory(string createdBy, Description description, 
        ICollection<CategoryPerTeam> categoriesPerTeam)
        : base(createdBy)
    {
        Description = description;
        CategoriesPerTeam = categoriesPerTeam;
    }

    [NotMapped]
    public Description Description { get; set; }

    // Navigation Properties
    public virtual ICollection<CategoryPerTeam> CategoriesPerTeam { get; set; }

    public static TeamCategory Create(string createdBy, Description description,
        ICollection<CategoryPerTeam> categoriesPerTeam)
        => new(createdBy, description, categoriesPerTeam);
}
