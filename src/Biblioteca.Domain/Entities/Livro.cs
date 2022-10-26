namespace Biblioteca.Domain.Entities;
public class Livro
{
    public string Titulo { get; set; }
    public DateOnly AnoLancamento { get; set; }
    public int QtdPaginas { get; set; }

    public int AutorId { get; set; }
    public Autor Autor { get; set; }

    public int EditoraId { get; set; }
    public Editora Editora { get; set; }

}
