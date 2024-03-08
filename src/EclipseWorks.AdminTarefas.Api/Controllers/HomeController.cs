using Microsoft.AspNetCore.Mvc;

namespace EclipseWorks.AdminTarefas.Api.Controllers;

[ApiController]
[Route("home")]
public class HomeController : ControllerBase
{
    [HttpGet]
    public IActionResult TarefasPorProjeto()
    {
        return Ok();
    }
}
