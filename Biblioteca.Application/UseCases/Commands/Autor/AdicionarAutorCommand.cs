namespace Biblioteca.Application.UseCases.Commands.Autor;
public class AdicionarAutorCommand : ICommand
{
    public string Nome { get; set; }
    public string Email { get; set; }
}
