using Alura.Adopet.Console.Servicos.Arquivos;
using Alura.Adopet.Console.Servicos.Http;

namespace Alura.Adopet.Console.Comandos;

public class ImportClientesFactory : IComandoFactory
{
    public IComando? CriarComando(string[] argumentos)
    {
        var clienteService = new ClienteService(new AdopetAPIClientFactory().CreateClient("adopet"));
        var leitorClientes = LeitorDeArquivoFactory.CreateLeitorClienteFrom(argumentos[1]);
        if (leitorClientes is null) return null;
        return new ImportClientes(clienteService, leitorClientes);
    }
}