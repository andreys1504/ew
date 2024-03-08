namespace EclipseWorks.AdminTarefas.Application.Services.Tarefa.CriarTarefa;

public sealed record CriarTarefaResponse
{
    public required Guid IdTarefa { get; init; }
    public required Guid IdProjeto { get; init; }
    public required string TituloTarefa { get; init; }
}
