﻿namespace Biblioteca.Application.UseCases.Commands;
public class GetByIdCommand : ICommand 
{
    public int Id { get; set; }
}
