using Biblioteca.Application.UseCases.Handlers.Autor;
using Biblioteca.Application.UseCases.Handlers.Editora;
using Biblioteca.Application.UseCases.Handlers.Livro;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Biblioteca.Application;
public static class Bootstrapper
{
    public static void AddApplication(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<AdicionarEditoraHandler>()
                .AddScoped<ObterTodosEditoraHandler>()
                .AddScoped<ObterPorIdEditoraHandler>()
                .AddScoped<AtualizarEditoraHandler>();

        services.AddScoped<AdicionarAutorHandler>()
                .AddScoped<ObterTodosAutoresHandler>()
                .AddScoped<ObterAutorPorIdHandler>()
                .AddScoped<AtualizarAutorHandler>();

        services.AddScoped<AdicionarLivroHandler>()
                .AddScoped<ObterTodosLivrosHandler>()
                .AddScoped<ObterLivroPorIdHandler>();
    }
}
