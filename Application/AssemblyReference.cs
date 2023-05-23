using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Application;

public static class AssemblyReference
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        var assembly = Assembly.GetExecutingAssembly(); //typeof(Application.AssemblyReference).Assembly;
        services.AddMediatR(cfg =>
            cfg.RegisterServicesFromAssembly(assembly)
            );
        return services;
    }
}
