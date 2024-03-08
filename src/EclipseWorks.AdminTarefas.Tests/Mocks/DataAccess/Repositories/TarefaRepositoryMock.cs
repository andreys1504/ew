using EclipseWorks.AdminTarefas.Domain.Entities;
using EclipseWorks.AdminTarefas.Domain.Repositories;
using EclipseWorks.AdminTarefas.Tests.Mocks.DataAccess.Repositories.Base;

namespace EclipseWorks.AdminTarefas.Tests.Mocks.DataAccess.Repositories;

public sealed class TarefaRepositoryMock : RepositoryBaseMock<Tarefa, Guid>, ITarefaRepository
{
    public TarefaRepositoryMock(List<Tarefa> entities = null) : base(entities ?? [])
    {
    }
}
