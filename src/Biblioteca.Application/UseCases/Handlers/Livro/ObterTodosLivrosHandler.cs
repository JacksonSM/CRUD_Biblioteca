using Biblioteca.Application.DTOs;
using Biblioteca.Application.Results;
using Biblioteca.Application.UseCases.Commands;
using Biblioteca.Application.UseCases.Commands.Livro;
using Biblioteca.Application.UseCases.Tools;
using Biblioteca.Domain.Helpers;
using Biblioteca.Domain.Interfaces;

namespace Biblioteca.Application.UseCases.Handlers.Livro;
public class ObterTodosLivrosHandler : IHandler<ObterLivrosCommand>
{
    private readonly ILivroRepository _livroRepository;

    public ObterTodosLivrosHandler(ILivroRepository livroRepository)
    {
        _livroRepository = livroRepository;
    }

    public async Task<RequestResult> Handle(ObterLivrosCommand command)
    {
        if(!command.IsValid())
            return new RequestResult().BadRequest("Requisição inválida. tente novamente.", command);

        var query = new GetAllQuery 
        { 
            PaginaAtual = command.PaginaAtual, 
            RegistrosPorPagina = command.RegistrosPorPagina
        };


        var livrosEntity = await _livroRepository.GetAllAsync(query);
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
