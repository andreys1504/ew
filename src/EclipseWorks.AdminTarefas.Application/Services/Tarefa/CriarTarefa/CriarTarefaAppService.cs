using EclipseWorks.AdminTarefas.Base.ApplicationLayer.ApplicationsServices;
using EclipseWorks.AdminTarefas.Base.DataAccessLayer;
using EclipseWorks.AdminTarefas.Domain.Repositories;
using Flunt.Notifications;

namespace EclipseWorks.AdminTarefas.Application.Services.Tarefa.CriarTarefa;

public sealed class CriarTarefaAppService
{
    private readonly ITarefaRepository _tarefaRepository;
    private readonly ITransaction _transaction;

    public CriarTarefaAppService(
        ITarefaRepository tarefaRepository,
        ITransaction transaction)
    {
        _tarefaRepository = tarefaRepository;
        _transaction = transaction;
    }

    public async Task<AppResponse<CriarTarefaResponse>> Handle(CriarTarefaRequest request)
    {
        if (request.Validate() == false)
            return new AppResponse<CriarTarefaResponse>(request.Notifications);


        int limiteTarefas = await _tarefaRepository.QuantidadeAsync(where: tarefa => tarefa.IdProjeto == request.IdProjeto);
        if (limiteTarefas >= 20)
            return new AppResponse<CriarTarefaResponse>(new Notification(key: "LimiteTarefas", "Limite de 20 tarefas por projeto atingido"));

        var tarefa = new Domain.Entities.Tarefa(
            idProjeto: request.IdProjeto,
            titulo: request.Titulo,
            descricao: request.Descricao,
            dataVencimento: request.DataVencimento,
            idStatus: request.IdStatus,
            idPrioridadeTarefa: request.IdPrioridadeTarefa);

        await _tarefaRepository.CadastrarAsync(tarefa);
        await _transaction.CommitAsync();

        var response = new CriarTarefaResponse
        { 
            IdTarefa = tarefa.Id,
            IdProjeto = tarefa.IdProjeto,
            TituloTarefa = tarefa.Titulo
        };

        return new AppResponse<CriarTarefaResponse>(response);
    }
}
