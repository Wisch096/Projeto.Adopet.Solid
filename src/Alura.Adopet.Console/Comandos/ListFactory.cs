using Alura.Adopet.Console.Servicos.Http;

namespace Alura.Adopet.Console.Comandos;

public class ListFactory : IComandoFactory
{
    public IComando? CriarComando(string[] argumentos)
    {
        var httpClientPetList = new HttpClientPet(new AdopetAPIClientFactory().CreateClient("adopet"));
        return new List(httpClientPetList);
    }
}
