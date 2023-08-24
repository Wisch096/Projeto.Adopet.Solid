using Alura.Adopet.Console.Modelos;
using Alura.Adopet.Console.Servicos;
using Alura.Adopet.Console.Util;
using FluentResults;

namespace Alura.Adopet.Console.Comandos;

public class ImportClientes : IComando
{
    private readonly IApiService<Cliente> apiService;
    private readonly ILeitorDeArquivo<Cliente> leitor;

    public ImportClientes(IApiService<Cliente> apiService, ILeitorDeArquivo<Cliente> leitor)
    {
        this.apiService = apiService;
        this.leitor = leitor;
    }

    public Task<Result> ExecutarAsync() 
    {
        return Task.FromResult(Result.Ok());
    }

}