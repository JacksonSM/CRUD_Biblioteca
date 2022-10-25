using Biblioteca.Application.Results;
using Biblioteca.Application.UseCases.Commands;

namespace Biblioteca.Application.UseCases.Handlers;
public interface IHandler<T>
where T : ICommand
{
    Task<RequestResult> Handle(T command);
}
