using Biblioteca.API.Tools;
using Biblioteca.Application.UseCases.Commands;
using Biblioteca.Application.UseCases.Commands.Editora;
using Biblioteca.Application.UseCases.Handlers.Editora;
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

    [HttpGet]
    public async Task<ActionResult> GetAll(
    [FromServices] ObterTodosEditoraHandler handler)
    {
        return new ParseRequestResult().ParseToActionResult(await handler.Handle(new NoParametersCommand()));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult> GetById(int id,
        [FromServices] ObterPorIdEditoraHandler handler)
    {
        var command = new GetByIdCommand { Id = id };
        return new ParseRequestResult().ParseToActionResult(await handler.Handle(command));
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(
    int id,
    [FromBody] AtualizarEditoraCommand command,
    [FromServices] AtualizarEditoraHandler handler)
    {
        command.SetId(id);
        return new ParseRequestResult().ParseToActionResult(await handler.Handle(command));
    }
}
