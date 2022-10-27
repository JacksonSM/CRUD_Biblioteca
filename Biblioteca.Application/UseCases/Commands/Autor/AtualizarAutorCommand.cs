namespace Biblioteca.Application.UseCases.Commands.Autor;
public class AtualizarAutorCommand : ICommand
{
    public int Id { get; private set; }
    public string Nome { get; set; }
    public string Email { get; set; }

    public void SetId(int id) => Id = id;
}
