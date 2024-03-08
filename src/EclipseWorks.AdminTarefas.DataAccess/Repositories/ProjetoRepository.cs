using EclipseWorks.AdminTarefas.DataAccess.EfContext;
using EclipseWorks.AdminTarefas.DataAccess.Repositories.Base;
using EclipseWorks.AdminTarefas.Domain.Repositories;

namespace EclipseWorks.AdminTarefas.DataAccess.Repositories;

public sealed class ProjetoRepository : RepositoryBase<Projeto, Guid>, IProjetoRepository
{
    public ProjetoRepository(AppDbContext context) : base(context)
    {
    }
}