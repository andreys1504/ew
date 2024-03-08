using EclipseWorks.AdminTarefas.Base.DataAccessLayer;

namespace EclipseWorks.AdminTarefas.Tests.Mocks.DataAccess;

public sealed class TransactionMock : ITransaction
{
    public Task CommitAsync()
    {
        return Task.CompletedTask;
    }

    public void Dispose()
    {
    }
}
