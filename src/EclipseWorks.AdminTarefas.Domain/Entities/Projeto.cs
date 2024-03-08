using EclipseWorks.AdminTarefas.Base.DomainLayer;

namespace EclipseWorks.AdminTarefas.Domain.Entities;

public class Projeto : Entity<Guid>
{
    protected Projeto() : base()
    {
    }

    public Projeto(
        string nome, 
        Guid idUsuario) : base(id: Guid.NewGuid())
    {
        Nome = nome.TrimString();
        IdUsuario = idUsuario;
    }

    public string Nome { get; private set; }
    public Guid IdUsuario { get; private set; }
    public Usuario Usuario { get; private set; }
    public ICollection<Tarefa> Tarefas { get; private set; }
}