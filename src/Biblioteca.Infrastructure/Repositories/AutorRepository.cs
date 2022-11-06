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

    public async Task<IEnumerable<Autor>> GetAllAsync()
    {
        var query = "SELECT * FROM [Biblioteca].[dbo].[Autores]";

        return await _session.Connection.QueryAsync<Autor>(query);
    }

    public async Task<Autor> GetByIdAsync(int id)
    {
        var query = "SELECT * FROM [Biblioteca].[dbo].[Autores] WHERE Id = @Id";

        var parameters = new { Id = id };

        return await _session.Connection.QueryFirstOrDefaultAsync<Autor>(query, parameters);
    }

    public async Task UpdateAsync(int id, Autor autor)
    {
        var query =
        @"UPDATE [Biblioteca].[dbo].[Autores]
          SET [Nome] = @nome, [Email] = @email
          WHERE Id = @id";

        var parameters = new
        {
            Id = id,
            Nome = autor.Nome,
            Email = autor.Email
        };
        await _session.Connection.ExecuteAsync(query, parameters, _session.Transaction);
    }

    public async Task<bool> ExistsByIdAsync(int id)
    {
        var query = @"SELECT COUNT(*) FROM [Biblioteca].[dbo].[Autores] WHERE Id = @Id;";
        var result = await _session.Connection.QueryFirstAsync<int>(query, new { Id = id });

        return result > 0 ? true : false;
    }
}
