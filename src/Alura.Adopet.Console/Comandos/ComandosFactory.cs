using Alura.Adopet.Console.Servicos.Http;
using Alura.Adopet.Console.Servicos.Arquivos;

namespace Alura.Adopet.Console.Comandos;

public static class ComandosFactory
{
    public static IComando? CriarComando(string[] argumentos)
    {
        if ((argumentos is null) || (argumentos.Length == 0))
        {
            return null;
        }
        var comando = argumentos[0];
        switch (comando)
        {
            case "import":
                return new ImportFactory().CriarComando(argumentos);
                                

            case "list":
                var httpClientPetList = new HttpClientPet(new AdopetAPIClientFactory().CreateClient("adopet"));
                return new List(httpClientPetList);               
            case "show":
                var leitorDeArquivosShow = LeitorDeArquivoFactory.CreateLeitorPetFrom(argumentos[1]);
                if (leitorDeArquivosShow is null) return null;
                return new Show(leitorDeArquivosShow);
            case "help":
                var comandoASerExibido = argumentos.Length==2? argumentos[1] : null;
                return new Help(comandoASerExibido);

            case "import-clientes":
                var clienteService = new ClienteService(new AdopetAPIClientFactory().CreateClient("adopet"));
                var leitorClientes = LeitorDeArquivoFactory.CreateLeitorClienteFrom(argumentos[1]);
                if (leitorClientes is null) return null;
                return new ImportClientes(clienteService, leitorClientes);

            default: return null;
        }           
    }
}
