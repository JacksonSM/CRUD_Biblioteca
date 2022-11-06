using Biblioteca.Application.Results;
using Biblioteca.Application.UseCases.Commands.Livro;
using Biblioteca.Application.UseCases.Tools;
using Biblioteca.Domain.Interfaces;

namespace Biblioteca.Application.UseCases.Handlers.Livro;
public class AdicionarLivroHandler : IHandler<AdicionarLivroCommand>
{
    private readonly ILivroRepository _livroRepository;
    private readonly IAutorRepository _autorRepository;
    private readonly IEditoraRepository _editoraRepository;
    private readonly IUnitOfWork _uow;

    public AdicionarLivroHandler(
        ILivroRepository livroRepository, 
        IAutorRepository autorRepository,
        IEditoraRepository editoraRepository,
        IUnitOfWork uow)
    {
        _livroRepository = livroRepository;
        _autorRepository = autorRepository;
        _editoraRepository = editoraRepository;
        _uow = uow;
    }

    public async Task<RequestResult> Handle(AdicionarLivroCommand command)
    {
        bool existeAutor = await _autorRepository.ExistsByIdAsync(command.AutorId);
        bool existeEditora = await _editoraRepository.ExistsByIdAsync(command.EditoraId);

        if(!(existeAutor && existeEditora))
            return new RequestResult().BadRequest("Autor ou editora não existe em nossa base de dados.", command);

        var livroEntity = EntityMapper.ParseLivro(command);

        if (!livroEntity.IsValid)
            return new RequestResult().BadRequest("Verifique os campos e tente novamente.", command);

        _uow.BeginTransaction();

        await _livroRepository.AddAsync(livroEntity);

        _uow.Commit();

        return new RequestResult().Created(EntityMapper.ParseLivroDTO(livroEntity));
    }

}
