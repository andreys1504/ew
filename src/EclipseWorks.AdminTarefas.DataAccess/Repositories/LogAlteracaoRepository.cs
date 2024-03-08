using EclipseWorks.AdminTarefas.DataAccess.EfContext;
using EclipseWorks.AdminTarefas.DataAccess.Repositories.Base;
using EclipseWorks.AdminTarefas.Domain.Repositories;

namespace EclipseWorks.AdminTarefas.DataAccess.Repositories;

public sealed class LogAlteracaoRepository : RepositoryBase<LogAlteracao, Guid>, ILogAlteracaoRepository
{
    public LogAlteracaoRepository(AppDbContext context) : base(context)
    {
    }
}
