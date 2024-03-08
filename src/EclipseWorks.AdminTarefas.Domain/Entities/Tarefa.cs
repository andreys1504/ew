using EclipseWorks.AdminTarefas.Base.DomainLayer;

namespace EclipseWorks.AdminTarefas.Domain.Entities;

public class Tarefa : Entity<Guid>
{
    protected Tarefa() : base()
    {
    }

    public Tarefa(
        Guid idProjeto,
        string titulo, 
        string descricao, 
        DateOnly dataVencimento,
        int idStatus,
        int idPrioridadeTarefa) : base(id: Guid.NewGuid())
    {
        IdProjeto = idProjeto;
        Titulo = titulo.TrimString();
        Descricao = descricao.TrimString();
        DataVencimento = dataVencimento;
        IdStatus = idStatus;
        IdPrioridadeTarefa = idPrioridadeTarefa;
    }

    public Guid IdProjeto { get; private set; }
    public Projeto Projeto { get; private set; }
    public string Titulo { get; private set; }
    public string Descricao { get; private set; }
    public DateOnly DataVencimento { get; private set; }
    public int IdStatus { get; private set; }
    public StatusTarefa StatusTarefa { get; private set; }
    public int IdPrioridadeTarefa { get; private set; }
    public PrioridadeTarefa PrioridadeTarefa { get; private set; }

    public void Editar(
        int idStatusTarefa,
        string titulo,
        string descricao)
    {
        IdStatus = idStatusTarefa;
        Titulo = titulo.TrimString();
        Descricao = descricao.TrimString();
    }

    public void AdicionarProjeto(Projeto projeto)
    {
        Projeto = projeto;
    }

    public void AdicionarStatusTarefa(StatusTarefa statusTarefa)
    {
        StatusTarefa = statusTarefa;
    }
}