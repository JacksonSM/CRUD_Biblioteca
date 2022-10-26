using Biblioteca.API.Tools;
using Biblioteca.Application.UseCases.Commands.Editora;
using Biblioteca.Application.UseCases.Handlers.Editora;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Biblioteca.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EditoraController : ControllerBase
{
    [HttpPost]
    public async Task<ActionResult> Add(
        [FromBody]AdicionarEditoraCommand addCommand,
        [FromServices] AdicionarEditoraHandler handler)
    {
        return new ParseRequestResult().ParseToActionResult(await handler.Handle(addCommand));
    }
}
