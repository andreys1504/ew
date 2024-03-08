using EclipseWorks.AdminTarefas.Base.ApplicationLayer.Request;

namespace EclipseWorks.AdminTarefas.Application.Services.Tarefa.RemoverTarefaProjeto;

public sealed class RemoverTarefaProjetoRequest : AppRequest
{
    public required Guid IdTarefa { get; init; }

    public override bool Validate()
    {
        ValidateBase(idUsuarioRequired: false);

        AddNotifications(new Contract()
            .IsGuid(IdTarefa, nameof(IdTarefa), "Tarefa inválida")
        );

        return IsValid;
    }
}
