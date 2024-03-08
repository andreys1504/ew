using EclipseWorks.AdminTarefas.Application.Services.Projeto.CriarProjeto;
using EclipseWorks.AdminTarefas.Application.Services.Projeto.ProjetosPorUsuario;
using EclipseWorks.AdminTarefas.Application.Services.Tarefa.AdicionarComentarioTarefa;
using EclipseWorks.AdminTarefas.Application.Services.Tarefa.AtualizarTarefa;
using EclipseWorks.AdminTarefas.Application.Services.Tarefa.CriarTarefa;
using EclipseWorks.AdminTarefas.Application.Services.Tarefa.MediaTarefasConcluidasPorUsuarios;
using EclipseWorks.AdminTarefas.Application.Services.Tarefa.RemoverTarefaProjeto;
using EclipseWorks.AdminTarefas.Application.Services.Tarefa.TarefasPorProjeto;
using Microsoft.Extensions.DependencyInjection;

namespace EclipseWorks.AdminTarefas.Application.Services;

public static class ApplicationServicesMappings
{
    public static void Register(IServiceCollection services)
    {
        //Projeto
        services.AddTransient<CriarProjetoAppService, CriarProjetoAppService>();
        services.AddTransient<ProjetosPorUsuarioAppService, ProjetosPorUsuarioAppService>();

        //Tarefa
        services.AddTransient<AdicionarComentarioTarefaAppService, AdicionarComentarioTarefaAppService>();
        services.AddTransient<AtualizarTarefaAppService, AtualizarTarefaAppService>();
        services.AddTransient<CriarTarefaAppService, CriarTarefaAppService>();
        services.AddTransient<MediaTarefasConcluidasPorUsuariosAppService, MediaTarefasConcluidasPorUsuariosAppService>();
        services.AddTransient<RemoverTarefaProjetoAppService, RemoverTarefaProjetoAppService>();
        services.AddTransient<TarefasPorProjetoAppService, TarefasPorProjetoAppService>();
    }
}
