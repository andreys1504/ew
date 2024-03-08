namespace EclipseWorks.AdminTarefas.Base.DataAccessLayer;

public interface ITransaction : IDisposable
{
    Task CommitAsync();
}
