using Biblioteca.Application.Results;
using Biblioteca.Application.UseCases.Commands.Editora;
using Biblioteca.Domain.Interfaces;
using Endereco.Application.UseCases.Tools;

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
        var editora = EntityMapper.ParseEndereco(command);

        if (!editora.IsValid)
            return new RequestResult().BadRequest("Verifique os campos e tente novamente.",editora);

        await _editoraRepository.AddAsync(editora);
        await _uow.Commit();
        return new RequestResult().Ok(editora);
    }


}
