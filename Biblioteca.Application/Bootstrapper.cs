using Biblioteca.Application.UseCases.Handlers.Editora;
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
    }
}
