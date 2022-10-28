namespace Biblioteca.Application.UseCases.Commands.Livro;
public class ObterLivrosCommand : ICommand
{
    public int? PaginaAtual { get; set; }
    public int? RegistrosPorPagina { get; set; }

    public bool IsValid()
    {
        return (PaginaAtual.HasValue && RegistrosPorPagina.HasValue) ||
                (PaginaAtual.HasValue == false && RegistrosPorPagina.HasValue == false);
    }
}
