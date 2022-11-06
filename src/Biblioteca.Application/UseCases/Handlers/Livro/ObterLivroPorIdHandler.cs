using Biblioteca.Application.Results;
using Biblioteca.Application.UseCases.Commands;
using Biblioteca.Application.UseCases.Tools;
using Biblioteca.Domain.Interfaces;

namespace Biblioteca.Application.UseCases.Handlers.Livro;
public class ObterLivroPorIdHandler : IHandler<GetByIdCommand>
{
    private readonly ILivroRepository _LivroRepository;

    public ObterLivroPorIdHandler(ILivroRepository LivroRepository)
    {
        _LivroRepository = LivroRepository;
    }

    public async Task<RequestResult> Handle(GetByIdCommand command)
    {
        var Livro = await _LivroRepository.GetByIdAsync(command.Id);

        if (Livro is null)
            return new RequestResult().NotFound();

        return new RequestResult().Ok(EntityMapper.ParseLivroDTO(Livro));
    }
}
