using Microsoft.EntityFrameworkCore;

namespace EclipseWorks.AdminTarefas.DataAccess.EfContext;

public sealed class AppDbContext : DbContext
{
    public AppDbContext(
        DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<LogAlteracao> LogsAlteracoes { get; set; }
    public DbSet<PrioridadeTarefa> PrioridadesTarefas { get; set; }
    public DbSet<Projeto> Projetos { get; set; }
    public DbSet<StatusTarefa> StatusTarefas { get; set; }
    public DbSet<Tarefa> Tarefas { get; set; }
    public DbSet<Usuario> Usuarios { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);

        base.OnModelCreating(modelBuilder);
    }
}