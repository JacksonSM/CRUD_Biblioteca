using Biblioteca.Domain.Entities.Validators;

namespace Biblioteca.Domain.Entities;
public class Editora : BaseEntity
{
    public string RazaoSocial { get; private set; }
    public string Email { get; private set; }
    public string Telefone { get; private set; }
    public bool IsValid => Validate();

    public List<Livro> Livros { get; private set; }

    public Editora(){}

    public Editora(string razaoSocial, string email, string telefone)
    {
        RazaoSocial = razaoSocial;
        Email = email;
        Telefone = telefone;
    }

    private bool Validate()
    {
        return !string.IsNullOrEmpty(RazaoSocial)
                    && FieldValidator.IsValidEmail(Email)
                    && FieldValidator.IsValidTelefone(Telefone);
    }


}
