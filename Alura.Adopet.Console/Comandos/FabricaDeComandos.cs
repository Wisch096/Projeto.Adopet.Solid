using Alura.Adopet.Console.Servicos;
using Alura.Adopet.Console.Servicos.Http;
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
                    var httpClientPet = new HttpClientPet(new AdopetAPIClientFactory().CreateClient("adopet"));
                    var leitorDeArquivoImport = LeitorDeArquivoFactory.CreateLeitorDePet(argumentos[1]);
                    if (leitorDeArquivoImport == null) return null;
                    return new Import(httpClientPet, leitorDeArquivoImport);

                case "list":
                    var httpClientPetList = new HttpClientPet(new AdopetAPIClientFactory().CreateClient("adopet"));
                    return new List(httpClientPetList);               

                case "show":
                    var leitorDeArquivoShow = LeitorDeArquivoFactory.CreateLeitorDePet(argumentos[1]);
                    if (leitorDeArquivoShow == null) return null;
                    return new Show(leitorDeArquivoShow);

                case "help":
                    var comandoASerExibido = argumentos.Length==2? argumentos[1] : null;
                    return new Help(comandoASerExibido);

                default: return null;
            }           
        }
    }
}
