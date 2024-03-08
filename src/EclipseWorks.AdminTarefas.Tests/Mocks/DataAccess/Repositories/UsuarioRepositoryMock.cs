using EclipseWorks.AdminTarefas.Domain.Entities;
using EclipseWorks.AdminTarefas.Domain.Repositories;
using EclipseWorks.AdminTarefas.Tests.Mocks.DataAccess.Repositories.Base;

namespace EclipseWorks.AdminTarefas.Tests.Mocks.DataAccess.Repositories;

public sealed class UsuarioRepositoryMock : RepositoryBaseMock<Usuario, Guid>, IUsuarioRepository
{
    public UsuarioRepositoryMock(List<Usuario> entities = null) : base(entities ?? [])
    {
    }
}
