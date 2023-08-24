using FluentResults;

namespace Alura.Adopet.Console.Comandos;

public class ImportClientes : IComando
{
    public Task<Result> ExecutarAsync() 
    {
        return Task.FromResult(Result.Ok());
    }

}