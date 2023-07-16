using Application.Data.Configurations;
using Application.Data.Configurations.JointEntities;
using Domain.Entities;
using Domain.Entities.JoinEntities;
using Microsoft.EntityFrameworkCore;

namespace Application.Data;

public class BaseSkillsMatrixDbContext : DbContext, ISkillsMatrixDbContext
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

    // Helper entities for authorization
    public DbSet<Role> Roles { get; set; }
    public DbSet<Permission> Permissions { get; set; }
    public DbSet<RolePermission> RolePermissions { get; set; }
    public DbSet<EmployeeRole> EmployeeRoles { get; set; }

    public BaseSkillsMatrixDbContext(DbContextOptions<BaseSkillsMatrixDbContext> options)
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
        modelBuilder.ApplyConfiguration(new EmployeeRoleConfiguration());
        modelBuilder.ApplyConfiguration(new RolePermissionConfiguration());

        base.OnModelCreating(modelBuilder);
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return base.SaveChangesAsync(cancellationToken);
    }
}
