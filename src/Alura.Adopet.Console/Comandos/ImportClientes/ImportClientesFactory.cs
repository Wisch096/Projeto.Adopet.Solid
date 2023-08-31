using Alura.Adopet.Console.Servicos.Arquivos;
using Alura.Adopet.Console.Servicos.Http;

namespace Alura.Adopet.Console.Comandos;

public class ImportClientesFactory : IComandoFactory
{
    public bool ConsegueCriarOTipo(Type? tipoComando)
    {
        return tipoComando?.IsAssignableTo(typeof(ImportClientes)) ?? false;
    }

    public IComando? CriarComando(string[] argumentos)
    {
        var serviceClientes = new ClienteService(new AdopetAPIClientFactory().CreateClient("adopet"));
        var leitorArquivoClientes = LeitorDeArquivoFactory.CreateLeitorDeClientes(argumentos[1]);
        if (leitorArquivoClientes is null) return null;
        return new ImportClientes(serviceClientes, leitorArquivoClientes);
    }
}
