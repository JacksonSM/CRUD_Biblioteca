using Biblioteca.Domain.Entities;

namespace Biblioteca.Domain.Interfaces;
public interface IAutorRepository
{
    Task<Autor> AddAsync(Autor autor);
    Task<IEnumerable<Autor>> GetAllAsync();
    Task<Autor> GetByIdAsync(int id);
    Task UpdateAsync(int id, Autor autor);
}
