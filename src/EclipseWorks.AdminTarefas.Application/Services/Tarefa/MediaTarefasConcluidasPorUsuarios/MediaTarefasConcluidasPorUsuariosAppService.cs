using EclipseWorks.AdminTarefas.Base.ApplicationLayer.ApplicationsServices;
using EclipseWorks.AdminTarefas.Domain.Constants.TipoUsuario;
using EclipseWorks.AdminTarefas.Domain.DomainServices.ValidarUsuarioPorPerfil;
using EclipseWorks.AdminTarefas.Domain.Repositories;
using EclipseWorks.AdminTarefas.Domain.Repositories.TarefaRepository.MediaDiariaTarefasConcluidasPorUsuario;

namespace EclipseWorks.AdminTarefas.Application.Services.Tarefa.MediaTarefasConcluidasPorUsuarios;

public sealed class MediaTarefasConcluidasPorUsuariosAppService
{
    private readonly ITarefaRepository _tarefaRepository;
    private readonly ValidarUsuarioPorPerfilDomainService _validarUsuarioPorPerfilDomainService;

    public MediaTarefasConcluidasPorUsuariosAppService(
        ITarefaRepository tarefaRepository,
        ValidarUsuarioPorPerfilDomainService validarUsuarioPorPerfilDomainService)
    {
        _tarefaRepository = tarefaRepository;
        _validarUsuarioPorPerfilDomainService = validarUsuarioPorPerfilDomainService;
    }

    public async Task<AppResponse<IEnumerable<MediaDiariaTarefasConcluidasPorUsuarioModel>>> Handle(Guid idUsuario)
    {
        if ((await _validarUsuarioPorPerfilDomainService.Handle(idUsuario, TipoUsuarioConstants.Gerente)).Data == false)
            return new AppResponse<IEnumerable<MediaDiariaTarefasConcluidasPorUsuarioModel>>(data: []);


        var dataHoraAtual = DateTime.UtcNow.UtcToBrasilia();

        var response = await _tarefaRepository.MediaDiariaTarefasConcluidasPorUsuarioAsync(
            intervaloDias: 30,
            dataReferencia: dataHoraAtual);

        return new AppResponse<IEnumerable<MediaDiariaTarefasConcluidasPorUsuarioModel>>(response);
    }
}
