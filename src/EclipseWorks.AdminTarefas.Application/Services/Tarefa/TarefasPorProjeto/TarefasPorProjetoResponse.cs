namespace EclipseWorks.AdminTarefas.Application.Services.Tarefa.TarefasPorProjeto;

public sealed record TarefasPorProjetoResponse
{
    public required Guid IdTarefa { get; init; }
    public required Guid IdProjeto { get; init; }
    public required string NomeProjeto { get; init; }
    public required string Titulo { get; init; }
    public required DateOnly DataVencimento { get; init; }
    public required int IdStatus { get; init; }
    public required string Status { get; init; }
}
