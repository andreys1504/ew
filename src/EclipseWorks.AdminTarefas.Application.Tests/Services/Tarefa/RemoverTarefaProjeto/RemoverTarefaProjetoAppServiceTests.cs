using EclipseWorks.AdminTarefas.Application.Services.Tarefa.RemoverTarefaProjeto;
using EclipseWorks.AdminTarefas.Domain.Constants.PrioridadeTarefa;
using EclipseWorks.AdminTarefas.Domain.Constants.StatusTarefa;
using EclipseWorks.AdminTarefas.Tests.Mocks.DataAccess;
using EclipseWorks.AdminTarefas.Tests.Mocks.DataAccess.Repositories;

namespace EclipseWorks.AdminTarefas.Application.Tests.Services.Tarefa.RemoverTarefaProjeto;

public sealed class RemoverTarefaProjetoAppServiceTests
{
    [Fact(DisplayName = "Sucesso")]
    [Trait("Application", nameof(RemoverTarefaProjetoAppService))]
    public async Task Sucesso()
    {
        //arrange
        var tarefaRepository = new TarefaRepositoryMock();
        var tarefa = new Domain.Entities.Tarefa(
            idProjeto: new Guid("8dccad04-fa86-4347-aebc-5b8917113f68"),
            titulo: "Reunião Equipe",
            descricao: null,
            dataVencimento: DateOnly.FromDateTime(DateTime.Now.AddDays(2)),
            idStatus: (int)StatusTarefaConstants.Pendente,
            idPrioridadeTarefa: (int)PrioridadeTarefaConstants.Baixa);
        await tarefaRepository.CadastrarAsync(tarefa);
        var appService = new RemoverTarefaProjetoAppService(tarefaRepository: tarefaRepository, transaction: new TransactionMock());
        var request = new RemoverTarefaProjetoRequest
        {
            IdTarefa = tarefa.Id,
            IdUsuario = new Guid("8dccad04-fa86-4347-aebc-5b8917113f68"),
        };

        //act
        var response = await appService.Handle(request);

        //assert
        Assert.True(response.Success);
    }


    [Fact(DisplayName = "Campos Obrigatórios - NomeProjeto Não Informado")]
    [Trait("Application", nameof(RemoverTarefaProjetoAppService))]
    public async Task CamposObrigatorios_NomeProjetoNaoInformado()
    {
        //arrange
        var appService = new RemoverTarefaProjetoAppService(tarefaRepository: null, transaction: null);
        var request = new RemoverTarefaProjetoRequest
        {
            IdTarefa = Guid.Empty,
            IdUsuario = new Guid("8dccad04-fa86-4347-aebc-5b8917113f68")
        };

        //act
        var response = await appService.Handle(request);

        //assert
        Assert.False(response.Success);
        Assert.Contains(response.Notifications, notification => notification.Key == nameof(RemoverTarefaProjetoRequest.IdTarefa));
    }
}
