using EclipseWorks.AdminTarefas.Application.Services.Tarefa.CriarTarefa;
using EclipseWorks.AdminTarefas.Domain.Constants.PrioridadeTarefa;
using EclipseWorks.AdminTarefas.Domain.Constants.StatusTarefa;
using EclipseWorks.AdminTarefas.Tests.Mocks.DataAccess;
using EclipseWorks.AdminTarefas.Tests.Mocks.DataAccess.Repositories;

namespace EclipseWorks.AdminTarefas.Application.Tests.Services.Tarefa.CriarTarefa;

public sealed class CriarTarefaAppServiceTests
{
    [Fact(DisplayName = "Sucesso")]
    [Trait("Application", nameof(CriarTarefaAppService))]
    public async Task Sucesso()
    {
        //arrange
        var appService = new CriarTarefaAppService(tarefaRepository: new TarefaRepositoryMock(), transaction: new TransactionMock());
        var request = new CriarTarefaRequest
        {
            IdProjeto = new Guid("94f880a8-f34a-4437-9813-fb00362ad5e8"),
            Titulo = "Reunião Equipe",
            Descricao = null,
            DataVencimento = DateOnly.FromDateTime(DateTime.Now.AddDays(2)),
            IdStatus = (int)StatusTarefaConstants.Pendente,
            IdPrioridadeTarefa = (int)PrioridadeTarefaConstants.Baixa,
            IdUsuario = new Guid("8dccad04-fa86-4347-aebc-5b8917113f68"),
        };

        //act
        var response = await appService.Handle(request);

        //assert
        Assert.True(response.Success);
    }


    [Fact(DisplayName = "Campos Obrigatórios - IdProjeto Não Informado")]
    [Trait("Application", nameof(CriarTarefaAppService))]
    public async Task CamposObrigatorios_IdProjetoNaoInformado()
    {
        //arrange
        var appService = new CriarTarefaAppService(tarefaRepository: null, transaction: null);
        var request = new CriarTarefaRequest
        {
            IdProjeto = Guid.Empty,
            Titulo = "Reunião Equipe",
            Descricao = null,
            DataVencimento = DateOnly.FromDateTime(DateTime.Now.AddDays(2)),
            IdStatus = (int)StatusTarefaConstants.Pendente,
            IdPrioridadeTarefa = (int)PrioridadeTarefaConstants.Baixa,
            IdUsuario = new Guid("8dccad04-fa86-4347-aebc-5b8917113f68"),
        };

        //act
        var response = await appService.Handle(request);

        //assert
        Assert.False(response.Success);
        Assert.Contains(response.Notifications, notification => notification.Key == nameof(CriarTarefaRequest.IdProjeto));
    }


    [Fact(DisplayName = "Campos Obrigatórios - Titulo Não Informado")]
    [Trait("Application", nameof(CriarTarefaAppService))]
    public async Task CamposObrigatorios_TituloNaoInformado()
    {
        //arrange
        var appService = new CriarTarefaAppService(tarefaRepository: null, transaction: null);
        var request = new CriarTarefaRequest
        {
            IdProjeto = new Guid("94f880a8-f34a-4437-9813-fb00362ad5e8"),
            Titulo = null,
            Descricao = null,
            DataVencimento = DateOnly.FromDateTime(DateTime.Now.AddDays(2)),
            IdStatus = (int)StatusTarefaConstants.Pendente,
            IdPrioridadeTarefa = (int)PrioridadeTarefaConstants.Baixa,
            IdUsuario = new Guid("8dccad04-fa86-4347-aebc-5b8917113f68"),
        };

        //act
        var response = await appService.Handle(request);

        //assert
        Assert.False(response.Success);
        Assert.Contains(response.Notifications, notification => notification.Key == nameof(CriarTarefaRequest.Titulo));
    }


    [Fact(DisplayName = "Campos Obrigatórios - DataVencimento Não Informada")]
    [Trait("Application", nameof(CriarTarefaAppService))]
    public async Task CamposObrigatorios_DataVencimentoNaoInformada()
    {
        //arrange
        var appService = new CriarTarefaAppService(tarefaRepository: null, transaction: null);
        var request = new CriarTarefaRequest
        {
            IdProjeto = new Guid("94f880a8-f34a-4437-9813-fb00362ad5e8"),
            Titulo = "Reunião Equipe",
            Descricao = null,
            DataVencimento = DateOnly.MinValue,
            IdStatus = (int)StatusTarefaConstants.Pendente,
            IdPrioridadeTarefa = (int)PrioridadeTarefaConstants.Baixa,
            IdUsuario = new Guid("8dccad04-fa86-4347-aebc-5b8917113f68"),
        };

        //act
        var response = await appService.Handle(request);

        //assert
        Assert.False(response.Success);
        Assert.Contains(response.Notifications, notification => notification.Key == nameof(CriarTarefaRequest.DataVencimento));
    }


    [Fact(DisplayName = "Campos Obrigatórios - IdStatus Não Informado")]
    [Trait("Application", nameof(CriarTarefaAppService))]
    public async Task CamposObrigatorios_IdStatusNaoInformado()
    {
        //arrange
        var appService = new CriarTarefaAppService(tarefaRepository: null, transaction: null);
        var request = new CriarTarefaRequest
        {
            IdProjeto = new Guid("94f880a8-f34a-4437-9813-fb00362ad5e8"),
            Titulo = "Reunião Equipe",
            Descricao = null,
            DataVencimento = DateOnly.FromDateTime(DateTime.Now.AddDays(2)),
            IdStatus = 0,
            IdPrioridadeTarefa = (int)PrioridadeTarefaConstants.Baixa,
            IdUsuario = new Guid("8dccad04-fa86-4347-aebc-5b8917113f68"),
        };

        //act
        var response = await appService.Handle(request);

        //assert
        Assert.False(response.Success);
        Assert.Contains(response.Notifications, notification => notification.Key == nameof(CriarTarefaRequest.IdStatus));
    }


    [Fact(DisplayName = "Campos Obrigatórios - IdPrioridadeTarefa Não Informado")]
    [Trait("Application", nameof(CriarTarefaAppService))]
    public async Task CamposObrigatorios_IdPrioridadeTarefaNaoInformado()
    {
        //arrange
        var appService = new CriarTarefaAppService(tarefaRepository: null, transaction: null);
        var request = new CriarTarefaRequest
        {
            IdProjeto = new Guid("94f880a8-f34a-4437-9813-fb00362ad5e8"),
            Titulo = "Reunião Equipe",
            Descricao = null,
            DataVencimento = DateOnly.FromDateTime(DateTime.Now.AddDays(2)),
            IdStatus = (int)StatusTarefaConstants.Pendente,
            IdPrioridadeTarefa = 0,
            IdUsuario = new Guid("8dccad04-fa86-4347-aebc-5b8917113f68"),
        };

        //act
        var response = await appService.Handle(request);

        //assert
        Assert.False(response.Success);
        Assert.Contains(response.Notifications, notification => notification.Key == nameof(CriarTarefaRequest.IdPrioridadeTarefa));
    }
}
