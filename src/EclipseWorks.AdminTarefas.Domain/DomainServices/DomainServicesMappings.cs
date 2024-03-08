using EclipseWorks.AdminTarefas.Domain.DomainServices.ValidarUsuarioPorPerfil;
using Microsoft.Extensions.DependencyInjection;

namespace EclipseWorks.AdminTarefas.Domain.DomainServices;

public static class DomainServicesMappings
{
    public static void Register(IServiceCollection services)
    {
        services.AddTransient<ValidarUsuarioPorPerfilDomainService, ValidarUsuarioPorPerfilDomainService>();
    }
}
