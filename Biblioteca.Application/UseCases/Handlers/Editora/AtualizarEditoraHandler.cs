using Biblioteca.Application.Results;
using Biblioteca.Application.UseCases.Commands.Editora;
using Biblioteca.Application.UseCases.Tools;
using Biblioteca.Domain.Interfaces;

namespace Biblioteca.Application.UseCases.Handlers.Editora;
public class AtualizarEditoraHandler : IHandler<AtualizarEditoraCommand>
{
    private readonly IEditoraRepository _editoraRepository;
    private readonly IUnitOfWork _uow;

    public AtualizarEditoraHandler(IEditoraRepository editoraRepository, IUnitOfWork uow)
    {
        _editoraRepository = editoraRepository;
        _uow = uow;
    }

    public async Task<RequestResult> Handle(AtualizarEditoraCommand command)
    {
        var editoraEntity = EntityMapper.ParseEditora(command);

        if(!editoraEntity.IsValid)
            return new RequestResult().BadRequest("Verifique os campos e tente novamente.", command);

        var editora = await _editoraRepository.GetByIdAsync(command.Id);

        if (editora is null)
            return new RequestResult().BadRequest("Verifique os campos e tente novamente.", command);

        _uow.BeginTransaction();
        await _editoraRepository.UpdateAsync(command.Id, editoraEntity);
        _uow.Commit();

        return new RequestResult().Ok(EntityMapper.ParseEditoraDTO(editoraEntity));
    }
}
