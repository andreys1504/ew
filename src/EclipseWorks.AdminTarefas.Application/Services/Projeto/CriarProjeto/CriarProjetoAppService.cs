using EclipseWorks.AdminTarefas.Base.ApplicationLayer.ApplicationsServices;
using EclipseWorks.AdminTarefas.Base.DataAccessLayer;
using EclipseWorks.AdminTarefas.Domain.Repositories;

namespace EclipseWorks.AdminTarefas.Application.Services.Projeto.CriarProjeto;

public sealed class CriarProjetoAppService
{
    private readonly IProjetoRepository _projetoRepository;
    private readonly ITransaction _transaction;

    public CriarProjetoAppService(
        IProjetoRepository projetoRepository,
        ITransaction transaction)
    {
        _projetoRepository = projetoRepository;
        _transaction = transaction;
    }

    public async Task<AppResponse<CriarProjetoResponse>> Handle(CriarProjetoRequest request)
    {
        if (request.Validate() == false)
            return new AppResponse<CriarProjetoResponse>(request.Notifications);


        var projeto = new Domain.Entities.Projeto(
            nome: request.NomeProjeto,
            idUsuario: request.IdUsuario.Value);
        await _projetoRepository.CadastrarAsync(projeto);
        await _transaction.CommitAsync();

        var response = new CriarProjetoResponse
        {
            IdProjeto = projeto.Id,
            NomeProjeto = projeto.Nome
        };

        return new AppResponse<CriarProjetoResponse>(response);
    }
}
