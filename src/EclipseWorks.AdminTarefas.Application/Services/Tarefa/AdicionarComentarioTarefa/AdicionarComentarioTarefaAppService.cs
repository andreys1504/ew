using EclipseWorks.AdminTarefas.Base.ApplicationLayer.ApplicationsServices;
using EclipseWorks.AdminTarefas.Base.DataAccessLayer;
using EclipseWorks.AdminTarefas.Domain.Repositories;

namespace EclipseWorks.AdminTarefas.Application.Services.Tarefa.AdicionarComentarioTarefa;

public sealed class AdicionarComentarioTarefaAppService
{
    private readonly ILogAlteracaoRepository _logAlteracaoRepository;
    private readonly ITarefaRepository _tarefaRepository;
    private readonly ITransaction _transaction;

    public AdicionarComentarioTarefaAppService(
        ILogAlteracaoRepository logAlteracaoRepository,
        ITarefaRepository tarefaRepository,
        ITransaction transaction)
    {
        _logAlteracaoRepository = logAlteracaoRepository;
        _tarefaRepository = tarefaRepository;
        _transaction = transaction;
    }

    public async Task<AppResponse<bool>> Handle(AdicionarComentarioTarefaRequest request)
    {
        if (request.Validate() == false)
            return new AppResponse<bool>(request.Notifications);


        bool tarefaExistente = await _tarefaRepository.ExistenteAsync(
            where: tarefa => tarefa.Id == request.IdTarefa);

        if (tarefaExistente == false)
            throw new Exception("Tarefa inexistente");

        await _logAlteracaoRepository.CadastrarAsync(new LogAlteracao(
            idEntidade: request.IdTarefa.ToString(),
            campo: "Comentario",
            valor: request.Comentario,
            idUsuario: request.IdUsuario.Value)
        );

        await _transaction.CommitAsync();


        return new AppResponse<bool>(true);
    }
}
