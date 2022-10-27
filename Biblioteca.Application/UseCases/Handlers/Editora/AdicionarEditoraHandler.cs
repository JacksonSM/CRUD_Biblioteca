using Biblioteca.Application.Results;
using Biblioteca.Application.UseCases.Commands.Editora;
using Biblioteca.Application.UseCases.Tools;
using Biblioteca.Domain.Interfaces;

namespace Biblioteca.Application.UseCases.Handlers.Editora;
public class AdicionarEditoraHandler : IHandler<AdicionarEditoraCommand>
{
    private readonly IEditoraRepository _editoraRepository;
    private readonly IUnitOfWork _uow;

    public AdicionarEditoraHandler(
        IEditoraRepository editoraRepository,
       IUnitOfWork uow)
    {
        _editoraRepository = editoraRepository;
        _uow = uow;
    }

    public async Task<RequestResult> Handle(AdicionarEditoraCommand command)
    {
        var editora = EntityMapper.ParseEditora(command);

        if (!editora.IsValid)
            return new RequestResult().BadRequest("Verifique os campos e tente novamente.", command);

        _uow.BeginTransaction();

        await _editoraRepository.AddAsync(editora);

        _uow.Commit();

        return new RequestResult().Created(EntityMapper.ParseEditoraDTO(editora));
    }


}
