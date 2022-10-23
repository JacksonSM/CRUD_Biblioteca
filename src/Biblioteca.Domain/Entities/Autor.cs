namespace Biblioteca.Domain.Entities;
public class Autor : BaseEntity
{
    public string Nome { get; set; }
    public string Email { get; set; }

    public List<Livro> Livros { get; set; }
}
