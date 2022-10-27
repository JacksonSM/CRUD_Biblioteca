using Biblioteca.Domain.Interfaces;
using Biblioteca.Infrastructure.Database;
using Biblioteca.Infrastructure.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Biblioteca.Infrastructure;
public static class Bootstrapper
{
    public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IEditoraRepository, EditoraRepository>()
                .AddScoped<IAutorRepository, AutorRepository>();

        services.AddScoped<DbSession>();
        services.AddTransient<IUnitOfWork, UnitOfWork>();
    }
}
