using Domain.Primitives;
using Domain.ValueObjects;

namespace Domain.Entities;

public class Position : Entity
{
    private Position(string createdBy)
        :base(createdBy)
    {
        
    }
    private Position
        (
            string createdBy, Description description, 
            ICollection<Employee>? employees, ICollection<Team>? teams,
            ICollection<Skill>? skills
        ) : base(createdBy)
    {
        Description = description;
        Employees = employees;
        Teams = teams;
        Skills = skills;
    }

    public Description Description { get; private set; } = default!;

    // Navigation Properties
    public virtual ICollection<Employee>? Employees { get; private set; }
    public virtual ICollection<Team>? Teams { get; private set; }
    public virtual ICollection<Skill>? Skills { get; private set; }

    public static Position Creat
        (
            string createdBy, Description description, ICollection<Employee>? employees,
            ICollection<Team>? teams, ICollection<Skill>? skills
        )
        => new
        (
            createdBy, description,
            employees, teams, skills
        );
}
