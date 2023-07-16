using Domain.Entities;
using Domain.Entities.JoinEntities;
using Microsoft.EntityFrameworkCore;

namespace Application.Data;

public interface ISkillsMatrixDbContext
{
    public DbSet<Skill> Skills { get; set; }
    public DbSet<SkillCategory> SkillCategories { get; set; }
    public DbSet<TeamCategory> TeamCategories { get; set; }
    public DbSet<Team> Teams { get; set; }
    public DbSet<Position> Positions { get; set; }
    public DbSet<Employee> Employees { get; set; }
    public DbSet<CategoryPerSkill> CategoriesPerSkill { get; set; }
    public DbSet<CategoryPerTeam> CategoriesPerTeam { get; set; }
    public DbSet<EmployeeSkill> EmployeeSkills { get; set; }
    public DbSet<PositionSkill> PositionSkills { get; set; }
    public DbSet<TeamPosition> TeamPositions { get; set; }
    public Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
