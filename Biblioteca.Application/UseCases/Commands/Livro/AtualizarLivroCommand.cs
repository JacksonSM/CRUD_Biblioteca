namespace Biblioteca.Application.UseCases.Commands.Livro;
public class AtualizarLivroCommand : ICommand
{
    public int Id { get; private set; }
    public string Titulo { get; set; }
    public int AnoLancamento { get; set; }
    public int QtdPaginas { get; set; }

    public void SetId(int id) => Id = id;
}
