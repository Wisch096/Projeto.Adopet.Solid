using Alura.Adopet.Console.Atributos;
using Alura.Adopet.Console.Modelos;
using Alura.Adopet.Console.Servicos.Abstracoes;
using FluentResults;

namespace Alura.Adopet.Console.Comandos;

[DocComando(instrucao: "import-clientes", documentacao: "teste")]
public class ImportClientes : IComando
{
    private readonly IApiService<Cliente> service;
    private readonly ILeitorDeArquivo<Cliente> leitor;

    public ImportClientes(IApiService<Cliente> service, ILeitorDeArquivo<Cliente> leitor)
    {
        this.service = service;
        this.leitor = leitor;
    }

    public Task<Result> ExecutarAsync()
    {
        return Task.FromResult(Result.Ok());
    }
}