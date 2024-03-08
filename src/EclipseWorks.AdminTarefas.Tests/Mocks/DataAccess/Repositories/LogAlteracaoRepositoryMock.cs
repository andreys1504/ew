using EclipseWorks.AdminTarefas.Domain.Entities;
using EclipseWorks.AdminTarefas.Domain.Repositories;
using EclipseWorks.AdminTarefas.Tests.Mocks.DataAccess.Repositories.Base;

namespace EclipseWorks.AdminTarefas.Tests.Mocks.DataAccess.Repositories;

public sealed class LogAlteracaoRepositoryMock : RepositoryBaseMock<LogAlteracao, Guid>, ILogAlteracaoRepository
{
    public LogAlteracaoRepositoryMock(List<LogAlteracao> entities = null) : base(entities ?? [])
    {
    }
}
