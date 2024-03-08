using EclipseWorks.AdminTarefas.Application.Services.Projeto.ProjetosPorUsuario;
using EclipseWorks.AdminTarefas.Tests.Mocks.DataAccess.Repositories;

namespace EclipseWorks.AdminTarefas.Application.Tests.Services.Projeto.ProjetosPorUsuario;

public sealed class ProjetosPorUsuarioAppServiceTests
{
    [Fact(DisplayName = "Sucesso")]
    [Trait("Application", nameof(ProjetosPorUsuarioAppService))]
    public async Task Sucesso()
    {
        //arrange
        var projetoRepository = new ProjetoRepositoryMock();
        var projeto = new Domain.Entities.Projeto(
            nome: "Força de Vendas",
            idUsuario: new Guid("8dccad04-fa86-4347-aebc-5b8917113f68")
        );
        await projetoRepository.CadastrarAsync(projeto);

        var appService = new ProjetosPorUsuarioAppService(projetoRepository: projetoRepository);
        var request = new ProjetosPorUsuarioRequest
        {
            IdUsuario = projeto.IdUsuario,
        };

        //act
        var response = await appService.Handle(request);

        //assert
        Assert.True(response.Success);
        Assert.Single(response.Data);
        Assert.Equal(projeto.Id, response.Data.First().IdProjeto);
    }
}
