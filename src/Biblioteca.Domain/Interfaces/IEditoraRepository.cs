using Biblioteca.Domain.Entities;

namespace Biblioteca.Domain.Interfaces;
public interface IEditoraRepository
{
    Task<Editora> AddAsync(Editora editora);
    Task<IEnumerable<Editora>> GetAllAsync();
}
