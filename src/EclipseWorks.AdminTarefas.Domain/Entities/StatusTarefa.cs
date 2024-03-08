using EclipseWorks.AdminTarefas.Base.DomainLayer;

namespace EclipseWorks.AdminTarefas.Domain.Entities;

public class StatusTarefa : Entity<int>
{
    protected StatusTarefa() : base()
    {
    }

    public StatusTarefa(
        int id,
        string nome) : base(id: id)
    {
        Nome = nome.TrimString();
    }

    public string Nome { get; private set; }
    public ICollection<Tarefa> Tarefas { get; private set; }
}
