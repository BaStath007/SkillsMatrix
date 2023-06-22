using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System.Reflection;
using System.Text.Json.Serialization;

namespace Presentation;

public static class AssemblyReference
{
    public static IServiceCollection AddPresentation(this IServiceCollection services)
    {
        //services.AddScoped<SkillsController>();

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
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "My Skill Matrix", Version = "v1" });
        });


        return services;
        
    }
}
