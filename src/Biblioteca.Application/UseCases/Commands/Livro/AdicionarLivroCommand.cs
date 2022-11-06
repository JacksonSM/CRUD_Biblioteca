namespace Biblioteca.Application.UseCases.Commands.Livro;
public class AdicionarLivroCommand : ICommand
{
    public string Titulo { get; set; }
    public int AnoLancamento { get; set; }
    public int QtdPaginas { get; set; }
    public int AutorId { get; set; }
    public int EditoraId { get; set; }
}
