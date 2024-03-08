using EclipseWorks.AdminTarefas.Base.DomainLayer;

namespace EclipseWorks.AdminTarefas.Domain.Entities;

public class Usuario : Entity<Guid>
{
    protected Usuario() : base()
    {
    }

    public Usuario(
        string nome,
        int idTipoUsuario) : base(id: Guid.NewGuid())
    {
        Nome = nome.TrimString();
        IdTipoUsuario = idTipoUsuario;
    }

    public string Nome { get; private set; }
    public int IdTipoUsuario { get; private set; }
    public ICollection<Projeto> Projetos { get; private set; }
}