using EclipseWorks.AdminTarefas.Base.DataAccessLayer;
using EclipseWorks.AdminTarefas.DataAccess.EfContext;

namespace EclipseWorks.AdminTarefas.DataAccess;

public sealed class Transaction : ITransaction
{
    private readonly AppDbContext _context;

    public Transaction(AppDbContext context)
    {
        _context = context;
    }

    public async Task CommitAsync()
    {
        await _context.SaveChangesAsync();
    }

    public void Dispose()
    {
    }
}
