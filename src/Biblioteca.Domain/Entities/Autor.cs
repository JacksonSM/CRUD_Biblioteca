using Biblioteca.Domain.Entities.Validators;

namespace Biblioteca.Domain.Entities;
public class Autor : BaseEntity
{
    public string Nome { get; set; }
    public string Email { get; set; }
    public List<Livro> Livros { get; set; }

    public bool IsValid => Validate();

    public Autor(){}

    public Autor(string nome, string email)
    {
        Nome = nome;
        Email = email;
    }

    private bool Validate()
    {
        return !string.IsNullOrEmpty(Email) &&
            FieldValidator.IsValidEmail(Email);
    }
}
