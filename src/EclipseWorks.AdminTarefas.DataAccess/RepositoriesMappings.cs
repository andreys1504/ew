using EclipseWorks.AdminTarefas.DataAccess.Repositories;
using EclipseWorks.AdminTarefas.Domain.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace EclipseWorks.AdminTarefas.DataAccess;

public static class RepositoriesMappings
{
    public static void Register(IServiceCollection services)
    {
        services.AddTransient<ILogAlteracaoRepository, LogAlteracaoRepository>();
        services.AddTransient<IProjetoRepository, ProjetoRepository>();
        services.AddTransient<ITarefaRepository, TarefaRepository>();
        services.AddTransient<IUsuarioRepository, UsuarioRepository>();
    }
}