using EclipseWorks.AdminTarefas.Application.Services;
using EclipseWorks.AdminTarefas.Base.DataAccessLayer;
using EclipseWorks.AdminTarefas.DataAccess;
using EclipseWorks.AdminTarefas.DataAccess.EfContext;
using EclipseWorks.AdminTarefas.Domain.DomainServices;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace EclipseWorks.AdminTarefas.Ioc;

public static class Dependencies
{
    public static void Register(
        this IServiceCollection services,
        string databaseConnectionString)
    {
        ApplicationServicesMappings.Register(services);

        DomainServicesMappings.Register(services);

        //AdminTarefas.DataAccess
        services.AddDbContext<AppDbContext>(options =>
        {
            options.UseSqlServer(connectionString: databaseConnectionString);
        });
        services.AddTransient<ITransaction, Transaction>();
        RepositoriesMappings.Register(services);
    }
}