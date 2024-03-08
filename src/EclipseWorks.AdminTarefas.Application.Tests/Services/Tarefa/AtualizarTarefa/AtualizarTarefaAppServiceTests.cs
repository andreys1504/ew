using EclipseWorks.AdminTarefas.Application.Services.Projeto.CriarProjeto;
using EclipseWorks.AdminTarefas.Application.Services.Tarefa.AtualizarTarefa;
using EclipseWorks.AdminTarefas.Domain.Constants.PrioridadeTarefa;
using EclipseWorks.AdminTarefas.Domain.Constants.StatusTarefa;
using EclipseWorks.AdminTarefas.Tests.Mocks.DataAccess;
using EclipseWorks.AdminTarefas.Tests.Mocks.DataAccess.Repositories;

namespace EclipseWorks.AdminTarefas.Application.Tests.Services.Tarefa.AtualizarTarefa;

public sealed class AtualizarTarefaAppServiceTests
{
    [Fact(DisplayName = "Sucesso")]
    [Trait("Application", nameof(AtualizarTarefaAppService))]
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

        var logAlteracaoRepository = new LogAlteracaoRepositoryMock();
        var appService = new AtualizarTarefaAppService(
            tarefaRepository: tarefaRepository,
            logAlteracaoRepository: logAlteracaoRepository,
            transaction: new TransactionMock()
        );
        var request = new AtualizarTarefaRequest
        {
            IdTarefa = tarefa.Id,
            Titulo = "Reunião Diretoria",
            Descricao = "Coordenadores, Gerentes, ...",
            IdStatus = (int)StatusTarefaConstants.Andamento,
            IdUsuario = new Guid("8dccad04-fa86-4347-aebc-5b8917113f68")
        };

        //act
        var response = await appService.Handle(request);

        //assert
        Assert.True(response.Success);
    }


    [Fact(DisplayName = "Campos Obrigatórios - IdTarefa Não Informada")]
    [Trait("Application", nameof(CriarProjetoAppService))]
    public async Task CamposObrigatorios_IdTarefaNaoInformada()
    {
        var appService = new AtualizarTarefaAppService(
            tarefaRepository: null,
            logAlteracaoRepository: null,
            transaction: null
        );
        var request = new AtualizarTarefaRequest
        {
            IdTarefa = Guid.Empty,
            Titulo = "Reunião Diretoria",
            Descricao = "Coordenadores, Gerentes, ...",
            IdStatus = (int)StatusTarefaConstants.Andamento,
            IdUsuario = new Guid("8dccad04-fa86-4347-aebc-5b8917113f68")
        };

        //act
        var response = await appService.Handle(request);

        //assert
        Assert.False(response.Success);
        Assert.Contains(response.Notifications, notification => notification.Key == nameof(AtualizarTarefaRequest.IdTarefa));
    }


    [Fact(DisplayName = "Campos Obrigatórios - Titulo Não Informado")]
    [Trait("Application", nameof(CriarProjetoAppService))]
    public async Task CamposObrigatorios_TituloNaoInformado()
    {
        var appService = new AtualizarTarefaAppService(
            tarefaRepository: null,
            logAlteracaoRepository: null,
            transaction: null
        );
        var request = new AtualizarTarefaRequest
        {
            IdTarefa = new Guid("8dccad04-fa86-4347-aebc-5b8917113f68"),
            Titulo = null,
            Descricao = "Coordenadores, Gerentes, ...",
            IdStatus = (int)StatusTarefaConstants.Andamento,
            IdUsuario = new Guid("8dccad04-fa86-4347-aebc-5b8917113f68")
        };

        //act
        var response = await appService.Handle(request);

        //assert
        Assert.False(response.Success);
        Assert.Contains(response.Notifications, notification => notification.Key == nameof(AtualizarTarefaRequest.Titulo));
    }


    [Fact(DisplayName = "Campos Obrigatórios - IdStatus Não Informado")]
    [Trait("Application", nameof(CriarProjetoAppService))]
    public async Task CamposObrigatorios_IdStatusNaoInformado()
    {
        var appService = new AtualizarTarefaAppService(
            tarefaRepository: null,
            logAlteracaoRepository: null,
            transaction: null
        );
        var request = new AtualizarTarefaRequest
        {
            IdTarefa = new Guid("8dccad04-fa86-4347-aebc-5b8917113f68"),
            Titulo = "Reunião Diretoria",
            Descricao = "Coordenadores, Gerentes, ...",
            IdStatus = 0,
            IdUsuario = new Guid("8dccad04-fa86-4347-aebc-5b8917113f68")
        };

        //act
        var response = await appService.Handle(request);

        //assert
        Assert.False(response.Success);
        Assert.Contains(response.Notifications, notification => notification.Key == nameof(AtualizarTarefaRequest.IdStatus));
    }
}
