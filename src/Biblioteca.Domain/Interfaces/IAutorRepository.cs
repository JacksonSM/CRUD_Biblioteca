using Biblioteca.Domain.Entities;

namespace Biblioteca.Domain.Interfaces;
public interface IAutorRepository
{
    Task<Autor> AddAsync(Autor editora);
    Task<IEnumerable<Autor>> GetAllAsync();
}
