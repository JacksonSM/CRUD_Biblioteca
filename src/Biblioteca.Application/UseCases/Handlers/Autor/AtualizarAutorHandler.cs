using Biblioteca.Application.Results;
using Biblioteca.Application.UseCases.Commands.Autor;
using Biblioteca.Application.UseCases.Tools;
using Biblioteca.Domain.Interfaces;

namespace Biblioteca.Application.UseCases.Handlers.Autor;
public class AtualizarAutorHandler : IHandler<AtualizarAutorCommand>
{
    private readonly IAutorRepository _autorRepository;
    private readonly IUnitOfWork _uow;

    public AtualizarAutorHandler(
        IAutorRepository autorRepository,
       IUnitOfWork uow)
    {
        _autorRepository = autorRepository;
        _uow = uow;
    }

    public async Task<RequestResult> Handle(AtualizarAutorCommand command)
    {
        var autorEntity = EntityMapper.ParseAutor(command);

        if (!autorEntity.IsValid)
            return new RequestResult().BadRequest("Verifique os campos e tente novamente.", command);

        var autor = await _autorRepository.GetByIdAsync(command.Id);

        if (autor is null)
            return new RequestResult().NotFound();

        _uow.BeginTransaction();
        await _autorRepository.UpdateAsync(command.Id, autorEntity);
        _uow.Commit();

        autorEntity.Id = command.Id;

        return new RequestResult().Ok(EntityMapper.ParseAutorDTO(autorEntity));
    }
}
