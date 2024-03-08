using EclipseWorks.AdminTarefas.DataAccess.EfContext;
using EclipseWorks.AdminTarefas.DataAccess.Repositories.Base;
using EclipseWorks.AdminTarefas.Domain.Repositories;

namespace EclipseWorks.AdminTarefas.DataAccess.Repositories;

public sealed class TarefaRepository : RepositoryBase<Tarefa, Guid>, ITarefaRepository
{
    public TarefaRepository(AppDbContext context) : base(context)
    {
    }
}