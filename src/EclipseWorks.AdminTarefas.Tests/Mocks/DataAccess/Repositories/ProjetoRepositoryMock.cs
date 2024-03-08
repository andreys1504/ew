using EclipseWorks.AdminTarefas.Domain.Entities;
using EclipseWorks.AdminTarefas.Domain.Repositories;
using EclipseWorks.AdminTarefas.Tests.Mocks.DataAccess.Repositories.Base;

namespace EclipseWorks.AdminTarefas.Tests.Mocks.DataAccess.Repositories;

public sealed class ProjetoRepositoryMock : RepositoryBaseMock<Projeto, Guid>, IProjetoRepository
{
    public ProjetoRepositoryMock(List<Projeto> entities = null) : base(entities ?? [])
    {
    }
}
