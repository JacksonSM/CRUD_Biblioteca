using Biblioteca.Domain.Entities;

namespace Biblioteca.Domain.Interfaces;
public interface ILivroRepository
{
    Task<Livro> AddAsync(Livro livro);
}
