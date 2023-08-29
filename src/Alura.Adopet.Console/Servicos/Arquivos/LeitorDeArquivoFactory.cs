using Alura.Adopet.Console.Modelos;
using Alura.Adopet.Console.Servicos.Abstracoes;

namespace Alura.Adopet.Console.Servicos.Arquivos;

public static class LeitorDeArquivoFactory
{
    public static ILeitorDeArquivo<Pet>? CreateLeitorDePets(string caminhoArquivo)
    {
        return Path.GetExtension(caminhoArquivo) switch
        {
            ".csv" => new LeitorDeArquivoCsv(caminhoArquivo),
            ".json" => new LeitorDeArquivoJson(caminhoArquivo),
            _ => null
        };
    }
}