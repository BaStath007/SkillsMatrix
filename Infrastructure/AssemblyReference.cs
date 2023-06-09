using Application;
using Application.Data;
using Application.Data.IRepositories;
using Infrastructure.Persistence;
using Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public static class AssemblyReference
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddApplication();

        if (configuration.GetValue<bool>("UseInMemoryDatabase"))
        {
            services.AddDbContext<BaseSkillsMatrixDbContext>(options =>
                {
                    options.UseInMemoryDatabase("SkillsMatrixDb");
                    options.EnableSensitiveDataLogging();
                });

            services.AddDbContext<SkillsMatrixDbContext>(options =>
                options.UseInMemoryDatabase("SkillsMatrixDb"));
        }
        else
        {
            services.AddDbContext<BaseSkillsMatrixDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                builder =>
                    builder.MigrationsAssembly(typeof(BaseSkillsMatrixDbContext).Assembly.FullName)));

            services.AddDbContext<SkillsMatrixDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                builder =>
                    builder.MigrationsAssembly(typeof(SkillsMatrixDbContext).Assembly.FullName)));
        }
        
        services.AddScoped<ISkillsMatrixDbContext, SkillsMatrixDbContext>();
        services.AddScoped<ISkillRepository, SkillsRepository>();
        services.AddScoped<IEmployeeRepository, EmployeeRepository>();
        services.AddScoped<SkillCategoryRepository>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        
        return services;
        
    }
}
