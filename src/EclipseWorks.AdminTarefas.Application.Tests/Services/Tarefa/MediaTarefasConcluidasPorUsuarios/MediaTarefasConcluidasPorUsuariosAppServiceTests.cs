using EclipseWorks.AdminTarefas.Application.Services.Tarefa.MediaTarefasConcluidasPorUsuarios;
using EclipseWorks.AdminTarefas.Base.Helpers;
using EclipseWorks.AdminTarefas.Domain.Constants.PrioridadeTarefa;
using EclipseWorks.AdminTarefas.Domain.Constants.StatusTarefa;
using EclipseWorks.AdminTarefas.Domain.Constants.TipoUsuario;
using EclipseWorks.AdminTarefas.Domain.DomainServices.ValidarUsuarioPorPerfil;
using EclipseWorks.AdminTarefas.Tests.Mocks.DataAccess.Repositories;

namespace EclipseWorks.AdminTarefas.Application.Tests.Services.Tarefa.MediaTarefasConcluidasPorUsuarios;

public sealed class MediaTarefasConcluidasPorUsuariosAppServiceTests
{
    [Fact(DisplayName = "Sucesso")]
    [Trait("Application", nameof(MediaTarefasConcluidasPorUsuariosAppService))]
    public async Task Sucesso()
    {
        //arrange
        #region Mocks

        var usuario = new Domain.Entities.Usuario(
            nome: "Andrey Mariano",
            idTipoUsuario: (int)TipoUsuarioConstants.Gerente);

        var usuarioRepository = new UsuarioRepositoryMock();
        await usuarioRepository.CadastrarAsync(usuario);


        var projeto = new Domain.Entities.Projeto(
            nome: "Força de Vendas",
            idUsuario: usuario.Id);
        projeto.AdicionarUsuario(usuario);
        var tarefa = new Domain.Entities.Tarefa(
            idProjeto: projeto.Id,
            titulo: "Cadastrar Usuários",
            descricao: null,
            dataVencimento: DateOnly.FromDateTime(DateTime.UtcNow.UtcToBrasilia().AddDays(-2)),
            idStatus: (int)StatusTarefaConstants.Pendente,
            idPrioridadeTarefa: (int)PrioridadeTarefaConstants.Media);
        tarefa.AdicionarProjeto(projeto);

        var tarefaRepository = new TarefaRepositoryMock();
        await tarefaRepository.CadastrarAsync(tarefa); 

        #endregion

        var validarUsuarioPorPerfilDomainService = new ValidarUsuarioPorPerfilDomainService(
            usuarioRepository: usuarioRepository);

        var appService = new MediaTarefasConcluidasPorUsuariosAppService(
            tarefaRepository: tarefaRepository,
            validarUsuarioPorPerfilDomainService: validarUsuarioPorPerfilDomainService);

        //act
        var response = await appService.Handle(usuario.Id);

        //assert
        Assert.True(response.Success);
        Assert.Single(response.Data);
    }
}
