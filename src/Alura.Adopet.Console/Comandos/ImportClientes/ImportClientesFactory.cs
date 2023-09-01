using Alura.Adopet.Console.Servicos.Arquivos;
using Alura.Adopet.Console.Servicos.Http;
using Alura.Adopet.Console.Settings;

namespace Alura.Adopet.Console.Comandos;

public class ImportClientesFactory : IComandoFactory
{
    public bool ConsegueCriarOTipo(Type? tipoComando)
    {
        return tipoComando?.IsAssignableTo(typeof(ImportClientes)) ?? false;
    }

    public IComando? CriarComando(string[] argumentos)
    {
        var uri = Configurations.ApiSettings.Uri;
        var serviceClientes = new ClienteService(new AdopetAPIClientFactory(uri).CreateClient("adopet"));
        var leitorArquivoClientes = LeitorDeArquivoFactory.CreateLeitorDeClientes(argumentos[1]);
        if (leitorArquivoClientes is null) return null;
        return new ImportClientes(serviceClientes, leitorArquivoClientes);
    }
}
