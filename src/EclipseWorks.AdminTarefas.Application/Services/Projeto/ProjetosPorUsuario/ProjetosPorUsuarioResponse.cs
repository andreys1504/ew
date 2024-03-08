namespace EclipseWorks.AdminTarefas.Application.Services.Projeto.ProjetosPorUsuario;

public sealed record ProjetosPorUsuarioResponse
{
    public required Guid IdProjeto { get; init; }
    public required string NomeProjeto { get; init; }
}