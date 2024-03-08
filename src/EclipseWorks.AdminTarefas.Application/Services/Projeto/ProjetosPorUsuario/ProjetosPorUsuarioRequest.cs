using EclipseWorks.AdminTarefas.Base.ApplicationLayer.Request;

namespace EclipseWorks.AdminTarefas.Application.Services.Projeto.ProjetosPorUsuario;

public sealed class ProjetosPorUsuarioRequest : AppRequest
{
    public override bool Validate()
    {
        ValidateBase();

        return IsValid;
    }
}
