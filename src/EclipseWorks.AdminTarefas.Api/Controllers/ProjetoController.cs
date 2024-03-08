using EclipseWorks.AdminTarefas.Application.Services.Projeto.CriarProjeto;
using EclipseWorks.AdminTarefas.Application.Services.Projeto.ProjetosPorUsuario;
using Microsoft.AspNetCore.Mvc;

namespace EclipseWorks.AdminTarefas.Api.Controllers;

[ApiController]
[Route("projetos")]
public class ProjetoController : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CriarProjeto(
        [FromBody] CriarProjetoRequest request,
        CriarProjetoAppService appService)
    {
        var response = await appService.Handle(request);

        return Ok(response);
    }


    [HttpGet("{idUsuario}")]
    public async Task<IActionResult> ProjetosPorUsuario(
        Guid idUsuario, 
        ProjetosPorUsuarioAppService appService)
    {
        var response = await appService.Handle(new ProjetosPorUsuarioRequest
        {
            IdUsuario = idUsuario
        });

        return Ok(response);
    }
}
