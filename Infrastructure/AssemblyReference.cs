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
        services.AddDbContext<SkillsMatrixDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
            builder => 
                builder.MigrationsAssembly(typeof(SkillsMatrixDbContext).Assembly.FullName)));
        services.AddScoped<ISkillsMatrixDbContext, SkillsMatrixDbContext>();
        services.AddScoped<IHardSkillsRepository, HardSkillsRepository>();
        
        return services;
        
    }
}
