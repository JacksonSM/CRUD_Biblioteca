using Biblioteca.Application.Results;
using Biblioteca.Application.UseCases.Commands;
using Biblioteca.Application.UseCases.Tools;
using Biblioteca.Domain.Interfaces;

namespace Biblioteca.Application.UseCases.Handlers.Autor;
public class ObterAutorPorIdHandler : IHandler<GetByIdCommand>
{
    private readonly IAutorRepository _autorRepository;

    public ObterAutorPorIdHandler(IAutorRepository autorRepository)
    {
        _autorRepository = autorRepository;
    }

    public async Task<RequestResult> Handle(GetByIdCommand command)
    {
        var autor = await _autorRepository.GetByIdAsync(command.Id);

        if (autor is null)
            return new RequestResult().NotFound();

        return new RequestResult().Ok(EntityMapper.ParseAutorDTO(autor));
    }
}
