using Biblioteca.Domain.Entities;
using Biblioteca.Domain.Interfaces;
using Biblioteca.Infrastructure.Database;
using Dapper;

namespace Biblioteca.Infrastructure.Repositories;
public class AutorRepository : IAutorRepository
{
    private readonly DbSession _session;

    public AutorRepository(DbSession session)
    {
        _session = session;
    }

    public async Task<Autor> AddAsync(Autor autor)
    {
        var query =
            @"INSERT INTO [Biblioteca].[dbo].[Autores]
            output inserted.Id VALUES
            (
                @Nome,
                @Email
            )";
        var parameters = new
        {
            Nome = autor.Nome,
            Email = autor.Email,
        };

        autor.Id = await _session.Connection.QuerySingleAsync<int>(query, parameters,_session.Transaction);

        return autor;
    }
}
