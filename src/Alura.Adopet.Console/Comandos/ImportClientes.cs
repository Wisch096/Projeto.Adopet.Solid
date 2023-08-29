using Alura.Adopet.Console.Atributos;
using FluentResults;

namespace Alura.Adopet.Console.Comandos;

[DocComando(instrucao: "import-clientes", documentacao: "teste")]
public class ImportClientes : IComando
{
    public Task<Result> ExecutarAsync()
    {
        return Task.FromResult(Result.Ok());
    }
}