namespace EclipseWorks.AdminTarefas.Application.Services.Projeto.CriarProjeto;

public sealed record CriarProjetoResponse
{
    public required Guid IdProjeto { get; init; }
    public required string NomeProjeto { get; init; }
}
