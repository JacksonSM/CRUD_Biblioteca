namespace Biblioteca.Application.UseCases.Commands.Autor;
public class AtulizarAutorCommand : ICommand
{
    public string Nome { get; set; }
    public string Email { get; set; }
}
