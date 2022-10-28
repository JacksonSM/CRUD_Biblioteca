using Biblioteca.Domain.Entities;
using Biblioteca.Domain.Interfaces;
using Biblioteca.Infrastructure.Database;
using Dapper;

namespace Biblioteca.Infrastructure.Repositories;
public class LivroRepository : ILivroRepository
{
    private readonly DbSession _session;

    public LivroRepository(DbSession session)
    {
        _session = session;
    }

    public async Task<Livro> AddAsync(Livro livro)
    {
        var query =
            @"INSERT INTO [Biblioteca].[dbo].[Livros]
            output inserted.Id VALUES
            (
                @Titulo,
                @AnoLancamento,
                @QtdPaginas,
                @AutorId,
                @EditoraId
            )";
        var parameters = new
        {
            Titulo = livro.Titulo,
            AnoLancamento = livro.AnoLancamento,
            QtdPaginas = livro.QtdPaginas,
            AutorId = livro.AutorId,
            EditoraId = livro.EditoraId
        };

        livro.Id = await _session.Connection.QuerySingleAsync<int>(query, parameters, _session.Transaction);

        return livro;
    }

}
