using EclipseWorks.AdminTarefas.Base.ApplicationLayer.Request;

namespace EclipseWorks.AdminTarefas.Application.Services.Tarefa.TarefasPorProjeto;

public sealed class TarefasPorProjetoRequest : AppRequest
{
    public required Guid IdProjeto { get; init; }

    public override bool Validate()
    {
        ValidateBase(idUsuarioRequired: false);

        AddNotifications(new Contract()
            .IsGuid(IdProjeto, nameof(IdProjeto), "Projeto inválido")
        );

        return IsValid;
    }
}
