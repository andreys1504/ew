using EclipseWorks.AdminTarefas.Base.ApplicationLayer.Request;

namespace EclipseWorks.AdminTarefas.Application.Services.Projeto.CriarProjeto;

public sealed class CriarProjetoRequest : AppRequest
{
    public required string NomeProjeto { get; init; }

    public override bool Validate()
    {
        ValidateBase();

        AddNotifications(new Contract()
            .IsNotNullOrWhiteSpace(NomeProjeto, nameof(NomeProjeto), "Nome do Projeto não informado")
            .IsGreaterOrEqualsThan(NomeProjeto, 2, nameof(NomeProjeto), "Nome do Projeto inválido")
            .IsLowerOrEqualsThan(NomeProjeto, 45, nameof(NomeProjeto), "Nome do Projeto não deve ser maior que 45 caracteres")
        );

        return IsValid;
    }
}
