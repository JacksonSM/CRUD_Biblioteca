using Biblioteca.Application.DTOs;
using Biblioteca.Application.Results;
using Biblioteca.Application.UseCases.Commands;
using Biblioteca.Application.UseCases.Tools;
using Biblioteca.Domain.Interfaces;

namespace Biblioteca.Application.UseCases.Handlers.Autor;
public class ObterTodosAutoresHandler : IHandler<NoParametersCommand>
{
    private readonly IAutorRepository _autorRepository;

    public ObterTodosAutoresHandler(
        IAutorRepository autorRepository)
    {
        _autorRepository = autorRepository;
    }

    public async Task<RequestResult> Handle(NoParametersCommand command)
    {
        var autoresEntity = await _autorRepository.GetAllAsync();
        List<AutorDTO> autoresDTOs = new();

        foreach (var autor in autoresEntity)
        {
            autoresDTOs.Add(EntityMapper.ParseAutorDTO(autor));
        }

        if (autoresDTOs.Count == 0)
            return new RequestResult().NoContext();

        return new RequestResult().Ok(autoresDTOs);
    }
}
