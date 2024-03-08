
namespace EclipseWorks.AdminTarefas.Api;

public class Program
{
    public static void Main(string[] args)
    {
        WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
        BuildApplication(builder);

        WebApplication app = builder.Build();
        PostBuildApplication(app);

        app.Run();
    }

    private static void BuildApplication(WebApplicationBuilder builder)
    {
        Ioc.Dependencies.Register(builder.Services, databaseConnectionString: builder.Configuration["DatabaseConnectionString"]);
        builder.Services.AddCors();
        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
    }

    private static void PostBuildApplication(WebApplication app)
    {
        app.UseCors(cors => cors
            .AllowAnyMethod()
            .AllowAnyOrigin()
            .AllowAnyHeader()
        );

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();
        app.UseAuthorization();
        app.MapControllers();
    }
}
