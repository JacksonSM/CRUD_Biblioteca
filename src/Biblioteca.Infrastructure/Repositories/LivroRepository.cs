using Biblioteca.Domain.Entities;
using Biblioteca.Domain.Helpers;
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

    public async Task<IEnumerable<Livro>> GetAllAsync(GetAllQuery queryRequest)
    {
        var query = @"SELECT * FROM [Biblioteca].[dbo].[Livros] AS Livro 
                      JOIN [Autores] AS Autor ON Autor.Id = Livro.AutorId
                      JOIN [Editoras] AS Editora ON Editora.Id = Livro.EditoraId ORDER BY Livro.Titulo
                      OFFSET (@paginaAtual) ROWS FETCH NEXT (@registrosPorPagina) ROWS ONLY ";

        var parameters = new
        {
            paginaAtual = queryRequest.PaginaAtual,
            registrosPorPagina = queryRequest.RegistrosPorPagina
        };

        var livros = await _session.Connection.QueryAsync<Livro, Autor, Editora, Livro>(query, (livro, autor, editora) =>
        {
            livro.Autor = autor;
            livro.Editora = editora;
            return livro;
        },parameters);


        return livros;
    }

    public async Task<Livro> GetByIdAsync(int id)
    {
        var query = @"SELECT * FROM [Biblioteca].[dbo].[Livros] AS Livro
                      JOIN [Autores] AS Autor ON Autor.Id = Livro.AutorId
                      JOIN [Editoras] AS Editora ON Editora.Id = Livro.EditoraId
                      WHERE Livro.Id = @Id";

        var livros = await _session.Connection.QueryAsync<Livro, Autor, Editora, Livro>(query, (livro, autor, editora) =>
        {
            livro.Autor = autor;
            livro.Editora = editora;
            return livro;
        }, new { Id = id });

        if (livros.Count() > 0)
            return livros.ToList()[0];

        return null;
    }

    public async Task UpdateAsync(int id, Livro livro)
    {

        var query =
        @"UPDATE [Biblioteca].[dbo].[Livros]
          SET [Titulo] = @titulo, [AnoLancamento] = @anoLancamento, [QtdPaginas] = @qtdPaginas
          WHERE Id = @id";

        var parameters = new
        {
            Id = id,
            titulo = livro.Titulo,
            anoLancamento = livro.AnoLancamento,
            qtdPaginas = livro.QtdPaginas
        };

        await _session.Connection.ExecuteAsync(query, parameters, _session.Transaction);
    }
}
