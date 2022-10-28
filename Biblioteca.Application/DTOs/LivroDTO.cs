namespace Biblioteca.Application.DTOs;
public class LivroDTO
{
    public int Id { get; set; }
    public string Titulo { get; set; }
    public int AnoLancamento { get; set; }
    public int QtdPaginas { get; set; }

    public AutorDTO Autor { get; set; }
    public EditoraDTO Editora { get; set; }
}
