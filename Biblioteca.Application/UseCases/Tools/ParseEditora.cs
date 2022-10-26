using Biblioteca.Application.DTOs;
using Biblioteca.Application.UseCases.Commands.Editora;
using Biblioteca.Domain.Entities;

namespace Biblioteca.Application.UseCases.Tools
{
    public partial class EntityMapper
    {
        public static Editora ParseEditora(AdicionarEditoraCommand editoraCommand)
        {
            return 
                new Editora
                (
                    razaoSocial: editoraCommand.RazaoSocial,
                    email: editoraCommand.Email,
                    telefone: editoraCommand.Telefone
                );
        }
        public static EditoraDTO ParseEditoraDTO(Editora editora)
        {
            return
                new EditoraDTO
                {
                    Id = editora.Id,
                    RazaoSocial = editora.RazaoSocial,
                    Email = editora.Email,
                    Telefone = editora.Telefone
                };
        }
    }
}