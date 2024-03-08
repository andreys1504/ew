using EclipseWorks.AdminTarefas.Application.Services.Projeto.CriarProjeto;
using EclipseWorks.AdminTarefas.Tests.Mocks.DataAccess;
using EclipseWorks.AdminTarefas.Tests.Mocks.DataAccess.Repositories;

namespace EclipseWorks.AdminTarefas.Application.Tests.Services.Projeto.CriarProjeto;

public sealed class CriarProjetoAppServiceTests
{
    [Fact(DisplayName = "Sucesso")]
    [Trait("Application", nameof(CriarProjetoAppService))]
    public async Task Sucesso()
    {
        //arrange
        var appService = new CriarProjetoAppService(projetoRepository: new ProjetoRepositoryMock(), transaction: new TransactionMock());
        var request = new CriarProjetoRequest
        {
            NomeProjeto = "Força de Vendas",
            IdUsuario = new Guid("8dccad04-fa86-4347-aebc-5b8917113f68"),
        };

        //act
        var response = await appService.Handle(request);

        //assert
        Assert.True(response.Success);
    }


    [Fact(DisplayName = "Campos Obrigatórios - NomeProjeto Não Informado")]
    [Trait("Application", nameof(CriarProjetoAppService))]
    public async Task CamposObrigatorios_NomeProjetoNaoInformado()
    {
        //arrange
        var appService = new CriarProjetoAppService(projetoRepository: null, transaction: null);
        var request = new CriarProjetoRequest
        {
            NomeProjeto = " ",
            IdUsuario = new Guid("8dccad04-fa86-4347-aebc-5b8917113f68")
        };

        //act
        var response = await appService.Handle(request);

        //assert
        Assert.False(response.Success);
        Assert.Contains(response.Notifications, notification => notification.Key == nameof(CriarProjetoRequest.NomeProjeto));
    }


    [Fact(DisplayName = "Campos Obrigatórios - IdUsuario Não Informado")]
    [Trait("Application", nameof(CriarProjetoAppService))]
    public void CamposObrigatorios_IdUsuarioNaoInformado()
    {
        //arrange
        var appService = new CriarProjetoAppService(projetoRepository: null, transaction: null);
        var request = new CriarProjetoRequest
        {
            NomeProjeto = "Força de Vendas",
            IdUsuario = null,
        };

        //act e assert
        _ = Assert.Throws<ArgumentException>(() => appService.Handle(request).GetAwaiter().GetResult());
    }
}
