using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using System.Text.Json.Serialization;

namespace Presentation;

public static class AssemblyReference
{
    public static IServiceCollection AddPresentation(this IServiceCollection services)
    {
        //services.AddScoped<HardSkillsController>();

        //var mvcBuilder = services.AddMvcCore();
        //mvcBuilder.AddApiExplorer();
        //mvcBuilder.AddAuthorization();
        //mvcBuilder.AddControllersAsServices();

        var assembly = Assembly.GetExecutingAssembly(); //typeof(Presentation.AssemblyReference).Assembly;
        services.AddControllers()
            .AddJsonOptions(options => {
                options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
            })
            .AddApplicationPart(assembly);

        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();


        return services;
        
    }
}
