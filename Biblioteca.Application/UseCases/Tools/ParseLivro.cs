using Biblioteca.Application.DTOs;
using Biblioteca.Application.UseCases.Commands.Livro;
using Biblioteca.Domain.Entities;

namespace Biblioteca.Application.UseCases.Tools;
public partial class EntityMapper
{
    public static Livro ParseLivro(AdicionarLivroCommand livroCommand)
    {
        return
            new Livro
            (
                titulo: livroCommand.Titulo,
                anoLancamento: livroCommand.AnoLancamento,
                qtdPaginas: livroCommand.QtdPaginas,
                autorId: livroCommand.AutorId,
                editoraId: livroCommand.EditoraId
            );
    }
    public static LivroDTO ParseLivroDTO(Livro livroEntity)
    {
        if (livroEntity.Autor is null && livroEntity.Editora is null)
            return new LivroDTO
            {
                Id = livroEntity.Id,
                Titulo = livroEntity.Titulo,
                QtdPaginas = livroEntity.QtdPaginas,
                AnoLancamento = livroEntity.AnoLancamento
            };

        if (livroEntity.Autor is null && livroEntity.Editora is not null)
            return new LivroDTO
            {
                Id = livroEntity.Id,
                Titulo = livroEntity.Titulo,
                QtdPaginas = livroEntity.QtdPaginas,
                AnoLancamento = livroEntity.AnoLancamento,
                Editora = ParseEditoraDTO(livroEntity.Editora)
            };

        if (livroEntity.Autor is not null && livroEntity.Editora is null)
            return new LivroDTO
            {
                Id = livroEntity.Id,
                Titulo = livroEntity.Titulo,
                QtdPaginas = livroEntity.QtdPaginas,
                AnoLancamento = livroEntity.AnoLancamento,
                Autor = ParseAutorDTO(livroEntity.Autor)
            };

            return new LivroDTO
            {
                Id = livroEntity.Id,
                Titulo = livroEntity.Titulo,
                QtdPaginas = livroEntity.QtdPaginas,
                AnoLancamento = livroEntity.AnoLancamento,
                Autor = ParseAutorDTO(livroEntity.Autor),
                Editora = ParseEditoraDTO(livroEntity.Editora)
            };
    }
}
