namespace Biblioteca.Domain.Entities;
public class Editora : BaseEntity
{
    public string RazaoSocial { get; set; }
    public string Email { get; set; }
    public string Telefone { get; set; }

    public List<Livro> Livros { get; set; }
}
