using EclipseWorks.AdminTarefas.Base.ApplicationLayer.ApplicationsServices;
using EclipseWorks.AdminTarefas.Domain.Repositories;

namespace EclipseWorks.AdminTarefas.Application.Services.Tarefa.TarefasPorProjeto;

public sealed class TarefasPorProjetoAppService
{
    private readonly ITarefaRepository _tarefaRepository;

    public TarefasPorProjetoAppService(ITarefaRepository tarefaRepository)
    {
        _tarefaRepository = tarefaRepository;
    }

    public async Task<AppResponse<IList<TarefasPorProjetoResponse>>> Handle(TarefasPorProjetoRequest request)
    {
        if (request.Validate() == false)
            return new AppResponse<IList<TarefasPorProjetoResponse>>(request.Notifications);


        var tarefasProjeto = await _tarefaRepository.BuscarAsync(
            where: tarefa => tarefa.IdProjeto == request.IdProjeto,
            select: tarefa => new TarefasPorProjetoResponse
            {
                IdTarefa = tarefa.Id,
                IdProjeto = tarefa.IdProjeto,
                NomeProjeto = tarefa.Projeto.Nome,
                Titulo = tarefa.Titulo,
                DataVencimento = tarefa.DataVencimento,
                IdStatus = tarefa.IdStatus,
                Status = tarefa.StatusTarefa.Nome
            },
            includes:
            [
                tarefa => tarefa.Projeto,
                tarefa => tarefa.StatusTarefa,
            ]
        );

        return new AppResponse<IList<TarefasPorProjetoResponse>>(data: tarefasProjeto);
    }
}
