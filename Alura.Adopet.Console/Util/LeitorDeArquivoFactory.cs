using Alura.Adopet.Console.Modelos;

namespace Alura.Adopet.Console.Util;

public class LeitorDeArquivoFactory
{
    public static ILeitorDeArquivo<Pet>? CreateLeitorDePet(string nomeArquivo) => Path.GetExtension(nomeArquivo) switch
    {
        ".csv" => new PetsDoCsv(nomeArquivo),
        ".json" => new PetsDoJson(nomeArquivo),
        _ => null
    };
}
