using EclipseWorks.AdminTarefas.Base.ApplicationLayer.ApplicationsServices;
using EclipseWorks.AdminTarefas.Base.DataAccessLayer;
using EclipseWorks.AdminTarefas.Domain.Repositories;

namespace EclipseWorks.AdminTarefas.Application.Services.Tarefa.RemoverTarefaProjeto;

public sealed class RemoverTarefaProjetoAppService
{
    private readonly ITarefaRepository _tarefaRepository;
    private readonly ITransaction _transaction;

    public RemoverTarefaProjetoAppService(
        ITarefaRepository tarefaRepository,
        ITransaction transaction)
    {
        _tarefaRepository = tarefaRepository;
        _transaction = transaction;
    }

    public async Task<AppResponse<bool>> Handle(RemoverTarefaProjetoRequest request)
    {
        if (request.Validate() == false)
            return new AppResponse<bool>(request.Notifications);


        Domain.Entities.Tarefa tarefa = await _tarefaRepository.BuscarPrimeiroRegistroAsync(
            where: tarefa => tarefa.Id == request.IdTarefa);

        _tarefaRepository.Excluir(tarefa);

        await _transaction.CommitAsync();

        return new AppResponse<bool>(true);
    }
}
