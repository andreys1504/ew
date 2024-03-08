using EclipseWorks.AdminTarefas.Base.DomainLayer;

namespace EclipseWorks.AdminTarefas.Domain.Entities;

public class PrioridadeTarefa : Entity<int>
{
    protected PrioridadeTarefa() : base()
    {
    }

    public PrioridadeTarefa(
        int id,
        string nome) : base(id: id)
    {
        Nome = nome.TrimString();
    }

    public string Nome { get; private set; }
    public ICollection<Tarefa> Tarefas { get; private set; }
}
