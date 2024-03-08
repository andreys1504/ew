using EclipseWorks.AdminTarefas.Base.DomainLayer;

namespace EclipseWorks.AdminTarefas.Domain.Entities;

public class LogAlteracao : Entity<Guid>
{
    protected LogAlteracao() : base()
    {
    }

    public LogAlteracao(
        string idEntidade,
        string campo,
        string valor,
        Guid idUsuario) : base(id: Guid.NewGuid())
    {
        IdEntidade = idEntidade;
        Campo = campo.TrimString();
        Valor = valor.TrimString();
        DataHoraModificacao = DateTime.Now;
        IdUsuario = idUsuario;
    }

    public string IdEntidade { get; private set; }
    public string Campo { get; private set; }
    public string Valor { get; private set; }
    public DateTime DataHoraModificacao { get; private set; }
    public Guid IdUsuario { get; private set; }
}
