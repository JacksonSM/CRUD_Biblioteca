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
            VALUES
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

        await _session.Connection.ExecuteAsync(query, parameters,_session.Transaction);
        
        return editora;
    }
    
    public async Task<IEnumerable<Editora>> GetAllAsync()
    {
        var query = "SELECT * FROM [Biblioteca].[dbo].[Editoras]";

        return await _session.Connection.QueryAsync<Editora>(query);
    }
}
