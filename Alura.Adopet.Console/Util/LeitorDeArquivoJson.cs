using Alura.Adopet.Console.Modelos;
using System.Text.Json;

namespace Alura.Adopet.Console.Util;

public class LeitorDeArquivoJson : ILeitorDeArquivo<Pet>
{
    private readonly string caminhoArquivo;

    public LeitorDeArquivoJson(string caminhoArquivo) => this.caminhoArquivo = caminhoArquivo;

    public IEnumerable<Pet> RealizaLeitura()
    {
        using var stream = new FileStream(caminhoArquivo, FileMode.Open, FileAccess.Read);

        return JsonSerializer.Deserialize<IEnumerable<Pet>>(stream);

    }
}