using Biblioteca.Domain.Entities;

namespace Biblioteca.Domain.Interfaces;
public interface ILivroRepository
{
    Task<Livro> AddAsync(Livro livro);
    Task<IEnumerable<Livro>> GetAllAsync();
    Task<Livro> GetByIdAsync(int id);
}
