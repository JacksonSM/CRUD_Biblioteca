using Biblioteca.Domain.Entities;

namespace Biblioteca.Domain.Interfaces;
public interface IAutorRepository
{
    Task<Autor> AddAsync(Autor editora);
    Task<IEnumerable<Autor>> GetAllAsync();
    Task<Autor> GetByIdAsync(int id);
}
