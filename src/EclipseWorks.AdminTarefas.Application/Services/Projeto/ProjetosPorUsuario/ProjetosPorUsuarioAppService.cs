using EclipseWorks.AdminTarefas.Base.ApplicationLayer.ApplicationsServices;
using EclipseWorks.AdminTarefas.Domain.Repositories;

namespace EclipseWorks.AdminTarefas.Application.Services.Projeto.ProjetosPorUsuario;

public sealed class ProjetosPorUsuarioAppService
{
    private readonly IProjetoRepository _projetoRepository;

    public ProjetosPorUsuarioAppService(IProjetoRepository projetoRepository)
    {
        _projetoRepository = projetoRepository;
    }

    public async Task<AppResponse<IList<ProjetosPorUsuarioResponse>>> Handle(ProjetosPorUsuarioRequest request)
    {
        if (request.Validate() == false)
            return new AppResponse<IList<ProjetosPorUsuarioResponse>>(request.Notifications);


        var projetosUsuario = await _projetoRepository.BuscarAsync(
            where: projeto => projeto.IdUsuario == request.IdUsuario.Value,
            select: projeto => new ProjetosPorUsuarioResponse
            {
                IdProjeto = projeto.Id,
                NomeProjeto = projeto.Nome,
            });

        return new AppResponse<IList<ProjetosPorUsuarioResponse>>(data: projetosUsuario);
    }
}
