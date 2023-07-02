using Domain.Entities;
using Domain.Entities.JoinEntities;
using Domain.Enums;
using Domain.Primitives;
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

        modelBuilder.Entity<Skill>
            (
                b =>
                {
                    b.OwnsOne
                    (
                        s => s.Description,
                        d => d.Property(x => x.Value)
                    );
                    b.Property(s => s.SkillType)
                        .HasConversion(
                            st => st.Name,
                            st => Enumeration<SkillType>.FromName(st)!
                    );
                }
            );

        modelBuilder.Entity<Role>
            (
                b => b.OwnsOne
                (
                    s => s.Description,
                    d => d.Property(x => x.Value)
                )
            );

        modelBuilder.Entity<Team>
            (
                b =>
                {
                    b.OwnsOne
                    (
                        s => s.Description,
                        d => d.Property(x => x.Value)
                    );
                    b.Property(t => t.TeamType)
                        .HasConversion(
                            tt => tt.Name,
                            tt => Enumeration<TeamType>.FromName(tt)!
                    );
                }
            );

        modelBuilder.Entity<SkillCategory>
            (
                b => b.OwnsOne
                (
                    s => s.Description,
                    d => d.Property(x => x.Value)
                )
            );

        modelBuilder.Entity<TeamCategory>
            (
                b => b.OwnsOne
                (
                    s => s.Description,
                    d => d.Property(x => x.Value)
                )
            );

        modelBuilder.Entity<Employee>
            (
                b =>
                {
                    b.OwnsOne
                    (
                        e => e.Age,
                        a => a.Property(x => x.Value)
                    );
                    b.OwnsOne
                    (
                        e => e.FirstName,
                        fn => fn.Property(x => x.Value)
                    );
                    b.Property(e => e.EmployeeMiddleName)
                        .HasConversion(
                            o => o.Map(mn => mn.Value).Reduce(MiddleName.Create(string.Empty)!.Data.Value),
                            o => Option<MiddleName>.Some(MiddleName.Create(o)!.Data).Map(mn => mn)
                    );
                    b.OwnsOne
                    (
                        e => e.LastName,
                        ln => ln.Property(x => x.Value)
                    );
                    b.OwnsOne
                    (
                        e => e.Email,
                        em => em.Property(x => x.Value)
                    );
                }
            );
        base.OnModelCreating(modelBuilder);
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return base.SaveChangesAsync();
    }
}
