using EclipseWorks.AdminTarefas.Base.DomainLayer;

namespace EclipseWorks.AdminTarefas.Domain.Entities;

public class Usuario : Entity<Guid>
{
    protected Usuario() : base()
    {
    }

    public Usuario(
        string nome) : base(id: Guid.NewGuid())
    {
        Nome = nome.TrimString();
    }

    public string Nome { get; private set; }
    public ICollection<Projeto> Projetos { get; private set; }
}