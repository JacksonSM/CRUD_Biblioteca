using Biblioteca.Application.Results;
using Biblioteca.Application.UseCases.Commands.Autor;
using Biblioteca.Application.UseCases.Tools;
using Biblioteca.Domain.Interfaces;

namespace Biblioteca.Application.UseCases.Handlers.Autor;
public class AdicionarAutorHandler : IHandler<AdicionarAutorCommand>
{
    private readonly IAutorRepository _autorRepository;
    private readonly IUnitOfWork _uow;

    public AdicionarAutorHandler(
        IAutorRepository autorRepository,
       IUnitOfWork uow)
    {
        _autorRepository = autorRepository;
        _uow = uow;
    }

    public async Task<RequestResult> Handle(AdicionarAutorCommand command)
    {
        var autorEntity = EntityMapper.ParseAutor(command);

        if (!autorEntity.IsValid)
            return new RequestResult().BadRequest("Verifique os campos e tente novamente.", command);

        _uow.BeginTransaction();

        await _autorRepository.AddAsync(autorEntity);

        _uow.Commit();

        return new RequestResult().Created(EntityMapper.ParseAutorDTO(autorEntity));
    }
}
