using Dapper;
using EclipseWorks.AdminTarefas.DataAccess.EfContext;
using EclipseWorks.AdminTarefas.DataAccess.Repositories.Base;
using EclipseWorks.AdminTarefas.Domain.Repositories;
using EclipseWorks.AdminTarefas.Domain.Repositories.TarefaRepository.MediaDiariaTarefasConcluidasPorUsuario;
using Microsoft.EntityFrameworkCore;

namespace EclipseWorks.AdminTarefas.DataAccess.Repositories;

public sealed class TarefaRepository : RepositoryBase<Tarefa, Guid>, ITarefaRepository
{
    private readonly AppDbContext _context;

    public TarefaRepository(AppDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<IEnumerable<MediaDiariaTarefasConcluidasPorUsuarioModel>> MediaDiariaTarefasConcluidasPorUsuarioAsync(
		int intervaloDias,
		DateTime dataReferencia)
    {
        string dataInicio = dataReferencia.AddDays(-intervaloDias).DateToYYYYMMDD();
        string dataFim = dataReferencia.DateToYYYYMMDD();

        string sql = 
			$@"
					SET DATEFORMAT YMD
					SELECT
						QtdPorUsuario.IdUsuario AS IdUsuario
						,usuario.Nome AS NomeUsuario
						,QtdPorUsuario.Quantidade / {intervaloDias}.0 AS MediaDiaria
					FROM
						(SELECT 
							projeto.IdUsuario AS IdUsuario
							,COUNT(tarefa.Id) AS Quantidade 
						FROM 
							Tarefa tarefa 
							JOIN Projeto projeto ON tarefa.IdProjeto = projeto.Id
						WHERE
							tarefa.DataVencimento BETWEEN '{dataInicio}' AND '{dataFim}'
						GROUP BY 
							projeto.IdUsuario) AS QtdPorUsuario
						JOIN Usuario usuario ON QtdPorUsuario.IdUsuario = usuario.Id
			";

        return await _context.Database.GetDbConnection().QueryAsync<MediaDiariaTarefasConcluidasPorUsuarioModel>(sql);
    }
}