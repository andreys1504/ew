using EclipseWorks.AdminTarefas.DataAccess.EfContext;
using EclipseWorks.AdminTarefas.DataAccess.Repositories.Base;
using EclipseWorks.AdminTarefas.Domain.Repositories;

namespace EclipseWorks.AdminTarefas.DataAccess.Repositories;

public sealed class UsuarioRepository : RepositoryBase<Usuario, Guid>, IUsuarioRepository
{
    public UsuarioRepository(AppDbContext context) : base(context)
    {
    }
}
