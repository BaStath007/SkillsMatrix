using Application.Data;
using Application.Data.Configurations.JointEntities;
using Application.Data.Configurations;
using Domain.Entities.JoinEntities;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence;

public class SkillsMatrixDbContext : DbContext, ISkillsMatrixDbContext
{
    // Entities
    public DbSet<Skill> Skills { get; set; }
    public DbSet<SkillCategory> SkillCategories { get; set; }
    public DbSet<TeamCategory> TeamCategories { get; set; }
    public DbSet<Team> Teams { get; set; }
    public DbSet<Position> Positions { get; set; }
    public DbSet<Employee> Employees { get; set; }
    // Joint Entities
    public DbSet<CategoryPerSkill> CategoriesPerSkill { get; set; }
    public DbSet<CategoryPerTeam> CategoriesPerTeam { get; set; }
    public DbSet<EmployeeSkill> EmployeeSkills { get; set; }
    public DbSet<PositionSkill> PositionSkills { get; set; }
    public DbSet<TeamPosition> TeamPositions { get; set; }

    // Helper entities for authorization
    public DbSet<Role> Roles { get; set; }
    public DbSet<Permission> Permissions { get; set; }
    public DbSet<RolePermission> RolePermissions { get; set; }


    public SkillsMatrixDbContext(DbContextOptions<SkillsMatrixDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Entities configurations
        modelBuilder.ApplyConfiguration(new SkillConfiguration());
        modelBuilder.ApplyConfiguration(new EmployeeConfiguration());
        modelBuilder.ApplyConfiguration(new PositionConfiguration());
        modelBuilder.ApplyConfiguration(new TeamConfiguration());
        modelBuilder.ApplyConfiguration(new SkillCategoryConfiguration());
        modelBuilder.ApplyConfiguration(new TeamCategoryConfiguration());

        // Joint entities configurations
        modelBuilder.ApplyConfiguration(new CategoryPerSkillConfiguration());
        modelBuilder.ApplyConfiguration(new CategoryPerTeamConfiguration());
        modelBuilder.ApplyConfiguration(new EmployeeSkillConfiguration());
        modelBuilder.ApplyConfiguration(new PositionSkillConfiguration());
        modelBuilder.ApplyConfiguration(new RolePermissionConfiguration());
        modelBuilder.ApplyConfiguration(new TeamPositionConfiguration());

        base.OnModelCreating(modelBuilder);
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return base.SaveChangesAsync(cancellationToken);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.EnableSensitiveDataLogging();
        base.OnConfiguring(optionsBuilder);
    }
}