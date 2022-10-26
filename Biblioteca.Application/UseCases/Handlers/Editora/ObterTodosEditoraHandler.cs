using Biblioteca.Application.DTOs;
using Biblioteca.Application.Results;
using Biblioteca.Application.UseCases.Commands;
using Biblioteca.Application.UseCases.Tools;
using Biblioteca.Domain.Interfaces;

namespace Biblioteca.Application.UseCases.Handlers.Editora;
public class ObterTodosEditoraHandler : IHandler<NoParametersCommand>
{
    private readonly IEditoraRepository _editoraRepository;

    public ObterTodosEditoraHandler(
        IEditoraRepository editoraRepository)
    {
        _editoraRepository = editoraRepository;
    }

    public async Task<RequestResult> Handle(NoParametersCommand command)
    {
        var editoras = await _editoraRepository.GetAllAsync();
        List<EditoraDTO> editoraDTOs = new();

        foreach (var editora in editoras)
        {
            editoraDTOs.Add(EntityMapper.ParseEditoraDTO(editora));
        }

        if(editoraDTOs.Count() == 0)
            return new RequestResult().NoContext();

        return new RequestResult().Ok(editoraDTOs);
    }
}
