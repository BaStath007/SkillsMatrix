using Infrastructure;
using Presentation;

namespace Web;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add Services to the container.
        builder.Services
            .AddInfrastructure(builder.Configuration)
            .AddPresentation();

        var app = builder.Build();

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My Skill Matrix");
                c.RoutePrefix = string.Empty; // Makes Swagger the default landing page
            });
        }
        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}