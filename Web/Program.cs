using Application;
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
            .AddApplication()
            .AddInfrastructure(builder.Configuration)
            .AddPresentation();

        builder.Services.AddSwaggerGen();
        var app = builder.Build();

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }
        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}