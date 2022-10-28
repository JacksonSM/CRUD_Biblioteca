using Biblioteca.Domain.Entities;
using Biblioteca.Domain.Helpers;

namespace Biblioteca.Domain.Interfaces;
public interface ILivroRepository
{
    Task<Livro> AddAsync(Livro livro);
    Task<IEnumerable<Livro>> GetAllAsync(GetAllQuery query);
    Task<Livro> GetByIdAsync(int id);
    Task UpdateAsync(int id, Livro autor);
}
