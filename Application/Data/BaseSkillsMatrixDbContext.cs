using Application.Shared;
using Domain.Entities;
using Domain.Entities.JoinEntities;
using Domain.Shared;
using Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace Application.Data;

public class BaseSkillsMatrixDbContext : DbContext, ISkillsMatrixDbContext
{
    public DbSet<Skill> Skills { get; set; }
    public DbSet<SkillCategory> SkillCategories { get; set; }
    public DbSet<TeamCategory> TeamCategories { get; set; }
    public DbSet<Team> Teams { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<Employee> Employees { get; set; }
    public DbSet<CategoryPerSkill> CategoriesPerSkill { get; set; }
    public DbSet<CategoryPerTeam> CategoriesPerTeam { get; set; }
    public DbSet<EmployeeSkill> EmployeeSkills { get; set; }
    public DbSet<RoleSkill> RoleSkills { get; set; }
    public DbSet<TeamRole> TeamRoles { get; set; }

    public BaseSkillsMatrixDbContext(DbContextOptions<BaseSkillsMatrixDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CategoryPerSkill>().HasKey(c => new { c.SkillId, c.SkillCategoryId });
        modelBuilder.Entity<CategoryPerTeam>().HasKey(c => new { c.TeamId, c.TeamCategoryId });
        modelBuilder.Entity<EmployeeSkill>().HasKey(c => new { c.SkillId, c.EmployeeId });
        modelBuilder.Entity<RoleSkill>().HasKey(c => new { c.SkillId, c.RoleId });
        modelBuilder.Entity<TeamRole>().HasKey(c => new { c.TeamId, c.RoleId });

        //modelBuilder.Entity<Age>().HasNoKey();
        //modelBuilder.Entity<Description>().HasNoKey();
        //modelBuilder.Entity<Email>().HasNoKey();
        //modelBuilder.Entity<FirstName>().HasNoKey();
        //modelBuilder.Entity<LastName>().HasNoKey();

        modelBuilder.Owned<Age>();
        modelBuilder.Owned<Description>();
        modelBuilder.Owned<Email>();
        modelBuilder.Owned<FirstName>();
        modelBuilder.Owned<LastName>();

        base.OnModelCreating(modelBuilder);
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        var number = base.SaveChangesAsync(cancellationToken);
        return number;
    }
}
