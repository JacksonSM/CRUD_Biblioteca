using System.Text.RegularExpressions;

namespace Biblioteca.Domain.Entities.Validators;
public static class FieldValidator
{
    public static bool IsValidEmail(string email)
    {
        try
        {
            var addr = new System.Net.Mail.MailAddress(email);
            return addr.Address == email;
        }
        catch
        {
            return false;
        }
    }
    public static bool IsValidTelefone(string telefone)
    {
        string padraoTelefone = "[0-9]{2} [1-9]{1} [0-9]{4}-[0-9]{4}";
        return Regex.IsMatch(telefone, padraoTelefone);
    }
}
