using EclipseWorks.AdminTarefas.Application.Services.Tarefa.TarefasPorProjeto;
using EclipseWorks.AdminTarefas.Domain.Constants.PrioridadeTarefa;
using EclipseWorks.AdminTarefas.Domain.Constants.StatusTarefa;
using EclipseWorks.AdminTarefas.Tests.Mocks.DataAccess.Repositories;

namespace EclipseWorks.AdminTarefas.Application.Tests.Services.Tarefa.TarefasPorProjeto;

public sealed class TarefasPorProjetoAppServiceTests
{
    [Fact(DisplayName = "Sucesso")]
    [Trait("Application", nameof(TarefasPorProjetoAppService))]
    public async Task Sucesso()
    {
        //arrange
        var tarefaRepository = new TarefaRepositoryMock();
        var tarefa = new Domain.Entities.Tarefa(
            idProjeto: new Guid("6ee48ae3-da90-4758-bbf9-86a2baa72d57"),
            titulo: "Criar Tela Login",
            descricao: null,
            dataVencimento: DateOnly.FromDateTime(DateTime.Now.AddDays(2)),
            idStatus: (int)StatusTarefaConstants.Pendente,
            idPrioridadeTarefa: (int)PrioridadeTarefaConstants.Media
        );
        tarefa.AdicionarProjeto(new Domain.Entities.Projeto(
            nome: "Front End",
            idUsuario: new Guid("8dccad04-fa86-4347-aebc-5b8917113f68"))
        );
        tarefa.AdicionarStatusTarefa(new Domain.Entities.StatusTarefa(
            id: tarefa.IdStatus,
            nome: nameof(StatusTarefaConstants.Pendente))
        );
        await tarefaRepository.CadastrarAsync(tarefa);

        var appService = new TarefasPorProjetoAppService(tarefaRepository: tarefaRepository);
        var request = new TarefasPorProjetoRequest
        {
            IdProjeto = tarefa.IdProjeto,
            IdUsuario = tarefa.Projeto.IdUsuario,
        };

        //act
        var response = await appService.Handle(request);

        //assert
        Assert.True(response.Success);
        Assert.Single(response.Data);
        Assert.Equal(tarefa.Id, response.Data.First().IdTarefa);
    }
}
