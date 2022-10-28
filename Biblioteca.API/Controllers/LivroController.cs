using Biblioteca.API.Tools;
using Biblioteca.Application.DTOs;
using Biblioteca.Application.UseCases.Commands;
using Biblioteca.Application.UseCases.Commands.Livro;
using Biblioteca.Application.UseCases.Handlers.Livro;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Biblioteca.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class LivroController : ControllerBase
{
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(LivroDTO))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> Add(
    [FromBody] AdicionarLivroCommand command,
    [FromServices] AdicionarLivroHandler handler)
    {
        return new ParseRequestResult().ParseToActionResult(await handler.Handle(command));
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(LivroDTO))]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<ActionResult> GetAll(
    [FromServices] ObterTodosLivrosHandler handler)
    {
        return new ParseRequestResult().ParseToActionResult(await handler.Handle(new NoParametersCommand()));
    }
}
