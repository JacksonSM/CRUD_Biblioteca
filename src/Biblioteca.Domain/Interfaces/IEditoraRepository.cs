using Biblioteca.Domain.Entities;

namespace Biblioteca.Domain.Interfaces;
public interface IEditoraRepository
{
    Task<Editora> AddAsync(Editora editora);
    Task<IEnumerable<Editora>> GetAllAsync();
    Task<Editora> GetByIdAsync(int id);
}
