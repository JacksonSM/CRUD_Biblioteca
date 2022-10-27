using Biblioteca.Application.DTOs;
using Biblioteca.Application.UseCases.Commands.Autor;
using Biblioteca.Domain.Entities;

namespace Biblioteca.Application.UseCases.Tools;
public partial class EntityMapper
{
    public static Autor ParseAutor(AdicionarAutorCommand autorCommand)
    {
        return
            new Autor
            (
                nome: autorCommand.Nome,
                email: autorCommand.Email
            );
    }
    public static AutorDTO ParseAutorDTO(Autor autorEntity)
    {
        return
            new AutorDTO 
            { 
                Id = autorEntity.Id,
                Nome = autorEntity.Nome,
                Email = autorEntity.Email
            };
    }
}
