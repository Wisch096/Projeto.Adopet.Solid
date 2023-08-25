namespace Alura.Adopet.Console.Util;

public class LeitorDeArquivoFactory
{
    public static ILeitorDeArquivo? CreateLeitor(string nomeArquivo) => Path.GetExtension(nomeArquivo) switch
    {
        ".csv" => new LeitorDeArquivoCsv(nomeArquivo),
        ".json" => new LeitorDeArquivoJson(nomeArquivo),
        _ => null
    };
}
