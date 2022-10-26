using Biblioteca.Application.Results;
using Biblioteca.Application.UseCases.Commands;
using Biblioteca.Application.UseCases.Tools;
using Biblioteca.Domain.Interfaces;

namespace Biblioteca.Application.UseCases.Handlers.Editora;
public class ObterPorIdEditoraHandler : IHandler<GetByIdCommand>
{
    private readonly IEditoraRepository _editoraRepository;

    public ObterPorIdEditoraHandler(IEditoraRepository editoraRepository)
    {
        _editoraRepository = editoraRepository;
    }

    public async Task<RequestResult> Handle(GetByIdCommand command)
    {
        var editora = await _editoraRepository.GetByIdAsync(command.Id);

        if (editora is null)
            return new RequestResult().NotFound();

        return new RequestResult().Ok(EntityMapper.ParseEditoraDTO(editora));
    }
}
