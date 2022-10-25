using Biblioteca.Application.UseCases.Commands.Editora;
using Biblioteca.Domain.Entities;

namespace Endereco.Application.UseCases.Tools
{
    public partial class EntityMapper
    {
        public static Editora ParseEndereco(AdicionarEditoraCommand editoraCommand)
        {
            return 
                new Editora
                (
                    razaoSocial: editoraCommand.RazaoSocial,
                    email: editoraCommand.Email,
                    telefone: editoraCommand.Telefone
                );
        }
    }
}