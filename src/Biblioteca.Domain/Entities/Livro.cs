namespace Biblioteca.Domain.Entities;

public class Livro : BaseEntity
{
    public string Titulo { get; private set; }
    public int AnoLancamento { get; private set; }
    public int QtdPaginas { get; private set; }

    public int AutorId { get; private set; }
    public Autor Autor { get; private set; }

    public int EditoraId { get; private set; }
    public Editora Editora { get; private set; }

    public bool IsValid => Validate();

    public Livro(){}

    public Livro(string titulo, int anoLancamento,
        int qtdPaginas, int autorId, int editoraId)
    {
        Titulo = titulo;
        AnoLancamento = anoLancamento;
        QtdPaginas = qtdPaginas;
        AutorId = autorId;
        EditoraId = editoraId;
    }

    private bool Validate()
    {
        return QtdPaginas > 0
            && !string.IsNullOrEmpty(Titulo) 
            && Titulo.Length <= 200;
    }
}
