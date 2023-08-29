using Alura.Adopet.Console.Modelos;
using Alura.Adopet.Console.Servicos.Abstracoes;

namespace Alura.Adopet.Console.Servicos.Arquivos;

public static class LeitorDeArquivoFactory
{
    public static ILeitorDeArquivo<Cliente>? CreateLeitorDeClientes(string caminhoArquivo)
    {
        return Path.GetExtension(caminhoArquivo) switch
        {
            ".csv" => new ClientesDoCsv(caminhoArquivo),
            ".json" => new ClientesDoJson(caminhoArquivo),
            _ => null
        };
    }

    public static ILeitorDeArquivo<Pet>? CreateLeitorDePets(string caminhoArquivo)
    {
        return Path.GetExtension(caminhoArquivo) switch
        {
            ".csv" => new PetsDoCsv(caminhoArquivo),
            ".json" => new PetsDoJson(caminhoArquivo),
            _ => null
        };
    }
}