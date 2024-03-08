using EclipseWorks.AdminTarefas.Base.ApplicationLayer.ApplicationsServices;
using EclipseWorks.AdminTarefas.Domain.Constants.TipoUsuario;
using EclipseWorks.AdminTarefas.Domain.Repositories;

namespace EclipseWorks.AdminTarefas.Domain.DomainServices.ValidarUsuarioPorPerfil;

public sealed class ValidarUsuarioPorPerfilDomainService
{
    private readonly IUsuarioRepository _usuarioRepository;

    public ValidarUsuarioPorPerfilDomainService(IUsuarioRepository usuarioRepository)
    {
        _usuarioRepository = usuarioRepository;
    }

    public async Task<AppResponse<bool>> Handle(Guid idUsuario, TipoUsuarioConstants tipoUsuario)
    {
        var idTipoUsuario = (int)tipoUsuario;
        bool existe = await _usuarioRepository.ExistenteAsync(where: usuario => usuario.Id == idUsuario && usuario.IdTipoUsuario == idTipoUsuario);

        return new AppResponse<bool>(existe);
    }
}
