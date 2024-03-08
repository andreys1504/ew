using EclipseWorks.AdminTarefas.Base.ApplicationLayer.ApplicationsServices;
using EclipseWorks.AdminTarefas.Base.DataAccessLayer;
using EclipseWorks.AdminTarefas.Domain.Repositories;

namespace EclipseWorks.AdminTarefas.Application.Services.Tarefa.AtualizarTarefa;

public sealed class AtualizarTarefaAppService
{
    private readonly ITarefaRepository _tarefaRepository;
    private readonly ILogAlteracaoRepository _logAlteracaoRepository;
    private readonly ITransaction _transaction;
    

    public AtualizarTarefaAppService(
        ITarefaRepository tarefaRepository,
        ILogAlteracaoRepository logAlteracaoRepository,
        ITransaction transaction)
    {
        _tarefaRepository = tarefaRepository;
        _logAlteracaoRepository = logAlteracaoRepository;
        _transaction = transaction;
    }

    public async Task<AppResponse<bool>> Handle(AtualizarTarefaRequest request)
    {
        if (request.Validate() == false)
            return new AppResponse<bool>(request.Notifications);


        Domain.Entities.Tarefa tarefa = await _tarefaRepository.BuscarPrimeiroRegistroAsync(
            where: tarefa => tarefa.Id == request.IdTarefa);

        tarefa.Editar(
            idStatusTarefa: request.IdStatus,
            titulo: request.Titulo,
            descricao: request.Descricao);
        _tarefaRepository.Editar(tarefa);

        Guid idUsuario = request.IdUsuario.Value;
        await LogarAlteracoesAsync(tarefa, idUsuario);

        await _transaction.CommitAsync();

        return new AppResponse<bool>(true);
    }

    private async Task LogarAlteracoesAsync(Domain.Entities.Tarefa tarefa, Guid idUsuario)
    {
        string idTarefa = tarefa.Id.ToString();

        IEnumerable<LogAlteracao> logs = [
            new LogAlteracao(
                idEntidade: idTarefa,
                campo: "IdStatus",
                valor: tarefa.IdStatus.ToString(),
                idUsuario: idUsuario),

            new LogAlteracao(
                idEntidade: idTarefa,
                campo: "Titulo",
                valor: tarefa.Titulo,
                idUsuario: idUsuario),

            new LogAlteracao(
                idEntidade: idTarefa,
                campo: "Descricao",
                valor: tarefa.Descricao,
                idUsuario: idUsuario),
        ];
        await _logAlteracaoRepository.CadastrarAsync(entities: logs);
    }
}