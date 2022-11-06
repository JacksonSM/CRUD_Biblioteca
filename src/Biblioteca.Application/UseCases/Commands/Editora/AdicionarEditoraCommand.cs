namespace Biblioteca.Application.UseCases.Commands.Editora;
public class AdicionarEditoraCommand : ICommand
{
    public string RazaoSocial { get; set; }
    public string Email { get; set; }
    public string Telefone { get; set; }
}
