using Application.Shared;
using Domain.Entities;
using Domain.Entities.JoinEntities;
using Domain.Shared;
using Microsoft.EntityFrameworkCore;

namespace Application.Data;

public class BaseSkillsMatrixDbContext : DbContext, ISkillsMatrixDbContext
{
    public DbSet<Skill> Skills { get; set; }
    public DbSet<SkillCategory> SkillCategories { get; set; }

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


        modelBuilder.Entity<CategoryPerSkill>()
        .Property(c => c.Skill)
        .HasConversion(new OptionValueConverter<Skill>());

        modelBuilder.Entity<CategoryPerSkill>()
            .Property(c => c.SkillCategory)
            .HasConversion(new OptionValueConverter<SkillCategory>());

        modelBuilder.Entity<CategoryPerTeam>()
            .Property(c => c.TeamCategory)
            .HasConversion(new OptionValueConverter<TeamCategory>());

        modelBuilder.Entity<CategoryPerTeam>()
            .Property(c => c.Team)
            .HasConversion(new OptionValueConverter<Team>());

        modelBuilder.Entity<EmployeeSkill>()
            .Property(c => c.Employee)
            .HasConversion(new OptionValueConverter<Employee>());

        modelBuilder.Entity<EmployeeSkill>()
            .Property(c => c.Skill)
            .HasConversion(new OptionValueConverter<Skill>());

        modelBuilder.Entity<RoleSkill>()
            .Property(c => c.Skill)
            .HasConversion(new OptionValueConverter<Skill>());

        modelBuilder.Entity<RoleSkill>()
            .Property(c => c.Role)
            .HasConversion(new OptionValueConverter<Role>());

        modelBuilder.Entity<TeamRole>()
            .Property(c => c.Team)
            .HasConversion(new OptionValueConverter<Team>());
        
        modelBuilder.Entity<TeamRole>()
            .Property(c => c.Role)
            .HasConversion(new OptionValueConverter<Role>());


        base.OnModelCreating(modelBuilder);
        //    modelBuilder.Entity<Option<Employee>>().HasNoKey();
        //    modelBuilder.Entity<Option<Skill>>().HasNoKey();
        //    modelBuilder.Entity<Option<SkillCategory>>().HasNoKey();
        //    modelBuilder.Entity<Option<TeamCategory>>().HasNoKey();
        //    modelBuilder.Entity<Option<Role>>().HasNoKey();
        //    modelBuilder.Entity<Option<Team>>().HasNoKey();
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return base.SaveChangesAsync(cancellationToken);
    }
}
