using Biblioteca.Domain.Entities;
using Biblioteca.Domain.Interfaces;
using Biblioteca.Infrastructure.Database;
using Dapper;

namespace Biblioteca.Infrastructure.Repositories;
public class EditoraRepository : IEditoraRepository
{
    private readonly DbSession _session;

    public EditoraRepository(DbSession session)
    {
        _session = session;
    }

    public async Task<Editora> AddAsync(Editora editora)
    {
        var query =
            @"INSERT INTO [Biblioteca].[dbo].[Editoras]
            output inserted.Id VALUES
            (
                @RazaoSocial,
                @Email,
                @Telefone
            )";
        var parameters = new
        {
            RazaoSocial = editora.RazaoSocial,
            Email = editora.Email,
            Telefone = editora.Telefone
        };

        editora.Id = await _session.Connection.QuerySingleAsync<int>(query, parameters, _session.Transaction);

        return editora;
    }

    public async Task<Editora> GetByIdAsync(int id)
    {
        var query = "SELECT * FROM [Biblioteca].[dbo].[Editoras] WHERE Id = @Id";

        var parameters = new { Id = id };

        return await _session.Connection.QueryFirstOrDefaultAsync<Editora>(query, parameters);
    }

    public async Task<IEnumerable<Editora>> GetAllAsync()
    {
        var query = "SELECT * FROM [Biblioteca].[dbo].[Editoras]";

        return await _session.Connection.QueryAsync<Editora>(query);
    }

    public async Task UpdateAsync(int id, Editora editora)
    {
        var query =
        @"UPDATE [Biblioteca].[dbo].[Editoras]
          SET [RazaoSocial] = @razaoSocial, [Email] = @email, [Telefone] = @telefone
          WHERE Id = @id";

        var parameters = new
        {
            Id = id,
            RazaoSocial = editora.RazaoSocial,
            Email = editora.Email,
            Telefone = editora.Telefone
        };
        await _session.Connection.ExecuteAsync(query, parameters, _session.Transaction);
    }

    public async Task<bool> ExistsByIdAsync(int id)
    {
        var query = @"SELECT COUNT(*) FROM [Biblioteca].[dbo].[Editoras] WHERE Id = @Id;";
        var result = await _session.Connection.QueryFirstAsync<int>(query, new { Id = id });

        return result > 0 ? true : false;
    }
}
