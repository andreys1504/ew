using EclipseWorks.AdminTarefas.Base.ApplicationLayer.Request;

namespace EclipseWorks.AdminTarefas.Application.Services.Tarefa.AdicionarComentarioTarefa;

public sealed class AdicionarComentarioTarefaRequest : AppRequest
{
    public required Guid IdTarefa { get; init; }
    public required string Comentario { get; init; }

    public override bool Validate()
    {
        ValidateBase();

        AddNotifications(new Contract()
            .IsGuid(IdTarefa, nameof(IdTarefa), "Tarefa inválida")

            .IsNotNullOrWhiteSpace(Comentario, nameof(Comentario), "Comentário não informado")
            .IsGreaterOrEqualsThan(Comentario, 3, nameof(Comentario), "Comentário inválido")
            .IsLowerOrEqualsThan(Comentario, 300, nameof(Comentario), "Comentario não deve ser maior que 300 caracteres")
        );

        return IsValid;
    }
}
