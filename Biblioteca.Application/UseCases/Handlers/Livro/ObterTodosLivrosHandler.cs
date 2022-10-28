using Biblioteca.Application.DTOs;
using Biblioteca.Application.Results;
using Biblioteca.Application.UseCases.Commands;
using Biblioteca.Application.UseCases.Tools;
using Biblioteca.Domain.Interfaces;

namespace Biblioteca.Application.UseCases.Handlers.Livro;
public class ObterTodosLivrosHandler : IHandler<NoParametersCommand>
{
    private readonly ILivroRepository _livroRepository;

    public ObterTodosLivrosHandler(ILivroRepository livroRepository)
    {
        _livroRepository = livroRepository;
    }

    public async Task<RequestResult> Handle(NoParametersCommand command)
    {
        var livrosEntity = await _livroRepository.GetAllAsync();
        List<LivroDTO> livrosDTOs = new();

        foreach (var livro in livrosEntity)
        {
            livrosDTOs.Add(EntityMapper.ParseLivroDTO(livro));
        }

        if (livrosDTOs.Count == 0)
            return new RequestResult().NoContext();

        return new RequestResult().Ok(livrosDTOs);
    }
}
