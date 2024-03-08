using EclipseWorks.AdminTarefas.Domain.Entities;
using EclipseWorks.AdminTarefas.Domain.Repositories;
using EclipseWorks.AdminTarefas.Domain.Repositories.TarefaRepository.MediaDiariaTarefasConcluidasPorUsuario;
using EclipseWorks.AdminTarefas.Tests.Mocks.DataAccess.Repositories.Base;

namespace EclipseWorks.AdminTarefas.Tests.Mocks.DataAccess.Repositories;

public sealed class TarefaRepositoryMock : RepositoryBaseMock<Tarefa, Guid>, ITarefaRepository
{
    public TarefaRepositoryMock(List<Tarefa> entities = null) : base(entities ?? [])
    {
    }

    public Task<IEnumerable<MediaDiariaTarefasConcluidasPorUsuarioModel>> MediaDiariaTarefasConcluidasPorUsuarioAsync(int intervaloDias, DateTime dataReferencia)
    {
        var dataInicio = DateOnly.FromDateTime(dataReferencia.AddDays(-intervaloDias));
        var dataFim = DateOnly.FromDateTime(dataReferencia);

        var tarefasPorDataVencimento = Entities.Where(entidade => entidade.DataVencimento >= dataInicio && entidade.DataVencimento <= dataFim);
        var tarefasPorUsuarios = tarefasPorDataVencimento.GroupBy(tarefa => tarefa.Projeto.IdUsuario);

        IList<MediaDiariaTarefasConcluidasPorUsuarioModel> response = [];
        foreach (var item in tarefasPorUsuarios)
        {
            response.Add(new MediaDiariaTarefasConcluidasPorUsuarioModel
            {
                IdUsuario = item.Key,
                NomeUsuario = item.First().Projeto.Usuario.Nome,
                MediaDiaria = item.Count() / (decimal)intervaloDias
            });
        }

        return Task.FromResult((IEnumerable<MediaDiariaTarefasConcluidasPorUsuarioModel>)response);
    }
}
