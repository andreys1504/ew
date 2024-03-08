using EclipseWorks.AdminTarefas.Base.DataAccessLayer;
using EclipseWorks.AdminTarefas.Domain.Entities;
using EclipseWorks.AdminTarefas.Domain.Repositories.TarefaRepository.MediaDiariaTarefasConcluidasPorUsuario;

namespace EclipseWorks.AdminTarefas.Domain.Repositories;

public interface ITarefaRepository : IRepositoryBase<Tarefa, Guid>
{
    Task<IEnumerable<MediaDiariaTarefasConcluidasPorUsuarioModel>> MediaDiariaTarefasConcluidasPorUsuarioAsync(
        int intervaloDias,
        DateTime dataReferencia);
}
