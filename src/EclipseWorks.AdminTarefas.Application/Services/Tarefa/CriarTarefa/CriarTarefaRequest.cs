using EclipseWorks.AdminTarefas.Base.ApplicationLayer.Request;

namespace EclipseWorks.AdminTarefas.Application.Services.Tarefa.CriarTarefa;

public sealed class CriarTarefaRequest : AppRequest
{
    public required Guid IdProjeto { get; init; }
    public required string Titulo { get; init; }
    public required string Descricao { get; init; }
    public required DateOnly DataVencimento { get; init; }
    public required int IdStatus { get; init; }
    public required int IdPrioridadeTarefa { get; init; }

    public override bool Validate()
    {
        ValidateBase();

        AddNotifications(new Contract()
            .IsGuid(IdProjeto, nameof(IdProjeto), "Projeto inválido")

            .IsNotNullOrWhiteSpace(Titulo, nameof(Titulo), "Título não informado")
            .IsGreaterOrEqualsThan(Titulo, 2, nameof(Titulo), "Título inválido")
            .IsLowerOrEqualsThan(Titulo, 45, nameof(Titulo), "Título não deve ser maior que 45 caracteres")

            .IsGreaterOrEqualsThan(Descricao, 2, nameof(Descricao), "Descrição inválida")
            .IsLowerOrEqualsThan(Descricao, 300, nameof(Descricao), "Descrição não deve ser maior que 300 caracteres")

            .IsDateOnlyValid(DataVencimento, nameof(DataVencimento), "Data de Vencimento inválida")

            .IsGreaterOrEqualsThan(IdStatus, 1, nameof(IdStatus), "Status inválido")

            .IsGreaterOrEqualsThan(IdPrioridadeTarefa, 1, nameof(IdPrioridadeTarefa), "Prioridade inválida")
        );

        return IsValid;
    }
}
