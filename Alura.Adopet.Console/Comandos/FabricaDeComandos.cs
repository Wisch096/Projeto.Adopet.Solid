using Alura.Adopet.Console.Modelos;
using Alura.Adopet.Console.Servicos;
using Alura.Adopet.Console.Util;

namespace Alura.Adopet.Console.Comandos
{
    public static class FabricaDeComandos
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
                    var importApiService = new HttpClientPet(new AdopetAPIClientFactory().CreateClient("adopet"));
                    var leitorDeArquivos = new LeitorDePetsDoCsv(argumentos[1]);
                    return new Import(importApiService, leitorDeArquivos);

                case "list":
                    var listApiService = new HttpClientPet(new AdopetAPIClientFactory().CreateClient("adopet"));
                    return new List(listApiService);

                case "show":
                    var leitorDeArquivosShow = new LeitorDePetsDoCsv(argumentos[1]);
                    return new Show(leitorDeArquivosShow);

                case "help":
                    var comandoASerExibido = argumentos.Length==2? argumentos[1] : null;
                    return new Help(comandoASerExibido);

                case "import-clientes":
                    IApiService<Cliente> apiService = new ClienteHttpService(new AdopetAPIClientFactory().CreateClient("adopet"));

                    var leitorClientes = new LeitorDeClientesDoCsv(argumentos[1]);
                    return new ImportClientes(apiService, leitorClientes);
                default: return null;
            }           
        }
    }
}
