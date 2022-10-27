using Biblioteca.API.Tools;
using Biblioteca.Application.DTOs;
using Biblioteca.Application.UseCases.Commands;
using Biblioteca.Application.UseCases.Commands.Autor;
using Biblioteca.Application.UseCases.Handlers.Autor;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Biblioteca.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AutorController : ControllerBase
{

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(AutorDTO))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> Add(
        [FromBody] AdicionarAutorCommand command,
        [FromServices] AdicionarAutorHandler handler)
    {
        return new ParseRequestResult().ParseToActionResult(await handler.Handle(command));
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AutorDTO))]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<ActionResult> GetAll(
        [FromServices] ObterTodosAutoresHandler handler)
    {
        return new ParseRequestResult().ParseToActionResult(await handler.Handle(new NoParametersCommand()));
    }
}
