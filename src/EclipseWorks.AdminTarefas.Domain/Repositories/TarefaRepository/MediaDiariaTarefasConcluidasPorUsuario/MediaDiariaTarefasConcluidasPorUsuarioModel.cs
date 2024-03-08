namespace EclipseWorks.AdminTarefas.Domain.Repositories.TarefaRepository.MediaDiariaTarefasConcluidasPorUsuario;

public sealed record MediaDiariaTarefasConcluidasPorUsuarioModel
{
    public required Guid IdUsuario { get; init; }
    public required string NomeUsuario { get; init; }
    public required decimal MediaDiaria { get; init; }
}
