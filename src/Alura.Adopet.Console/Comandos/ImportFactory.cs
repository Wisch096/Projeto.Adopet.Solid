using Alura.Adopet.Console.Servicos.Arquivos;
using Alura.Adopet.Console.Servicos.Http;

namespace Alura.Adopet.Console.Comandos;

public class ImportFactory : IComandoFactory<Import>
{
    public IComando? CriarComando(string[] argumentos)
    {
        var httpClientPet = new HttpClientPet(new AdopetAPIClientFactory().CreateClient("adopet"));
        var leitorDeArquivos = LeitorDeArquivoFactory.CreateLeitorDePets(argumentos[1]);
        if (leitorDeArquivos is null) return null;
        return new Import(httpClientPet, leitorDeArquivos);
    }
}
