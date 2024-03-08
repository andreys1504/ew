using EclipseWorks.AdminTarefas.Base.ApplicationLayer.Request;

namespace EclipseWorks.AdminTarefas.Application.Services.Tarefa.AtualizarTarefa;

public sealed class AtualizarTarefaRequest : AppRequest
{
    public Guid IdTarefa { get; set; }
    public required string Titulo { get; init; }
    public required string Descricao { get; init; }
    public required int IdStatus { get; init; }

    public override bool Validate()
    {
        ValidateBase();

        AddNotifications(new Contract()
            .IsGuid(IdTarefa, nameof(IdTarefa), "Tarefa inválida")

            .IsNotNullOrWhiteSpace(Titulo, nameof(Titulo), "Título não informado")
            .IsGreaterOrEqualsThan(Titulo, 2, nameof(Titulo), "Título inválido")
            .IsLowerOrEqualsThan(Titulo, 45, nameof(Titulo), "Título não deve ser maior que 45 caracteres")

            .IsGreaterOrEqualsThan(Descricao, 2, nameof(Descricao), "Descrição inválida")
            .IsLowerOrEqualsThan(Descricao, 300, nameof(Descricao), "Descrição não deve ser maior que 300 caracteres")

            .IsGreaterOrEqualsThan(IdStatus, 1, nameof(IdStatus), "Status inválido")
        );

        return IsValid;
    }
}
