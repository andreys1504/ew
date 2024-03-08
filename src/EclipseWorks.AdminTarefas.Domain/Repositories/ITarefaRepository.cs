using EclipseWorks.AdminTarefas.Base.DataAccessLayer;
using EclipseWorks.AdminTarefas.Domain.Entities;

namespace EclipseWorks.AdminTarefas.Domain.Repositories;

public interface ITarefaRepository : IRepositoryBase<Tarefa, Guid>
{
}
