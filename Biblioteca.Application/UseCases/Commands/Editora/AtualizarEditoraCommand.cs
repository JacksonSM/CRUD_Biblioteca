namespace Biblioteca.Application.UseCases.Commands.Editora;
public class AtualizarEditoraCommand : ICommand
{
    public int Id { get; private set; }
    public string RazaoSocial { get; set; }
    public string Email { get; set; }
    public string Telefone { get; set; }

    public void SetId(int id)
    {
        Id = id;
    }
}
