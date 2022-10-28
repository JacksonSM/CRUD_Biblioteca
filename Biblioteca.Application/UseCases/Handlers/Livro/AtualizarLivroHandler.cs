using Biblioteca.Application.Results;
using Biblioteca.Application.UseCases.Commands.Livro;
using Biblioteca.Application.UseCases.Tools;
using Biblioteca.Domain.Interfaces;

namespace Biblioteca.Application.UseCases.Handlers.Livro;
public class AtualizarLivroHandler : IHandler<AtualizarLivroCommand>
{
    private readonly ILivroRepository _livroRepository;
    private readonly IUnitOfWork _uow;

    public AtualizarLivroHandler(ILivroRepository livroRepository, IUnitOfWork uow)
    {
        _livroRepository = livroRepository;
        _uow = uow;
    }

    public async Task<RequestResult> Handle(AtualizarLivroCommand command)
    {
        var LivroEntity = EntityMapper.ParseLivro(command);

        if (!LivroEntity.IsValid)
            return new RequestResult().BadRequest("Verifique os campos e tente novamente.", command);

        var Livro = await _livroRepository.GetByIdAsync(command.Id);

        if (Livro is null)
            return new RequestResult().NotFound();

        _uow.BeginTransaction();

        await _livroRepository.UpdateAsync(command.Id, LivroEntity);

        _uow.Commit();

        return new RequestResult().NoContext();
    }
}
