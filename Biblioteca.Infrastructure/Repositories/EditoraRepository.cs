using Biblioteca.Domain.Entities;
using Biblioteca.Domain.Interfaces;
using Biblioteca.Infrastructure.Database;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

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
}
