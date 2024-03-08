using EclipseWorks.AdminTarefas.Application.Services.Tarefa.AdicionarComentarioTarefa;
using EclipseWorks.AdminTarefas.Application.Services.Tarefa.AtualizarTarefa;
using EclipseWorks.AdminTarefas.Application.Services.Tarefa.CriarTarefa;
using EclipseWorks.AdminTarefas.Application.Services.Tarefa.MediaTarefasConcluidasPorUsuarios;
using EclipseWorks.AdminTarefas.Application.Services.Tarefa.RemoverTarefaProjeto;
using EclipseWorks.AdminTarefas.Application.Services.Tarefa.TarefasPorProjeto;
using Microsoft.AspNetCore.Mvc;

namespace EclipseWorks.AdminTarefas.Api.Controllers;

[ApiController]
[Route("tarefas")]
public class TarefaController : ControllerBase
{
    [HttpPost("adicionar-comentario")]
    public async Task<IActionResult> AdicionarComentarioTarefa(
        [FromBody] AdicionarComentarioTarefaRequest request,
        AdicionarComentarioTarefaAppService appService)
    {
        var response = await appService.Handle(request);

        return Ok(response);
    }


    [HttpPut("{idTarefa}")]
    public async Task<IActionResult> AtualizarTarefa(
        Guid idTarefa,
        [FromBody] AtualizarTarefaRequest request,
        AtualizarTarefaAppService appService)
    {
        request.IdTarefa = idTarefa;
        var response = await appService.Handle(request);

        return Ok(response);
    }


    [HttpPost]
    public async Task<IActionResult> CriarTarefa(
        [FromBody] CriarTarefaRequest request, 
        CriarTarefaAppService appService)
    {
        var response = await appService.Handle(request);

        return Ok(response);
    }


    [HttpGet("relatorio/media-diaria-conclusao/{idUsuario}")]
    public async Task<IActionResult> MediaTarefasConcluidasPorUsuarios(
        Guid idUsuario,
        MediaTarefasConcluidasPorUsuariosAppService appService)
    {
        var response = await appService.Handle(idUsuario);

        return Ok(response);
    }


    [HttpDelete("{idTarefa}")]
    public async Task<IActionResult> RemoverTarefaProjeto(
        Guid idTarefa,
        RemoverTarefaProjetoAppService appService)
    {
        var response = await appService.Handle(new RemoverTarefaProjetoRequest
        {
            IdTarefa = idTarefa,
            IdUsuario = null
        });

        return Ok(response);
    }


    [HttpGet("{idProjeto}")]
    public async Task<IActionResult> TarefasPorProjeto(
        Guid idProjeto,
        TarefasPorProjetoAppService appService)
    {
        var response = await appService.Handle(new TarefasPorProjetoRequest
        { 
            IdProjeto = idProjeto,
            IdUsuario = null
        });

        return Ok(response);
    }
}
