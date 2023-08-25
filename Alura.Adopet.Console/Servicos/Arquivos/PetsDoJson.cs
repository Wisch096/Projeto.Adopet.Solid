using Alura.Adopet.Console.Modelos;
using Alura.Adopet.Console.Servicos;
using System.Text.Json;

namespace Alura.Adopet.Console.Util;

public class PetsDoJson : ILeitorDeArquivo<Pet>
{
    private readonly string caminhoArquivo;

    public PetsDoJson(string caminhoArquivo) => this.caminhoArquivo = caminhoArquivo;

    public IEnumerable<Pet> RealizaLeitura()
    {
        using var stream = new FileStream(caminhoArquivo, FileMode.Open, FileAccess.Read);

        return JsonSerializer.Deserialize<IEnumerable<Pet>>(stream);

    }
}