using Biblioteca.Domain.Entities;

namespace Biblioteca.Domain.Interfaces;
public interface IAutorRepository
{
    Task<Autor> AddAsync(Autor editora);
}
