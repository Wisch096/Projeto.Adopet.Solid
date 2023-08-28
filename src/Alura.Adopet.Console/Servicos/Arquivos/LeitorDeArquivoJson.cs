using Alura.Adopet.Console.Modelos;
using System.Text.Json;

namespace Alura.Adopet.Console.Servicos.Arquivos;

public class LeitorDeArquivoJson : ILeitorDeArquivo
{
    private string caminhoArquivo;

    public LeitorDeArquivoJson(string caminhoArquivo)
    {
        this.caminhoArquivo = caminhoArquivo;
    }

    public IEnumerable<Pet> RealizaLeitura()
    {
        using Stream stream = new FileStream(caminhoArquivo, FileMode.Open, FileAccess.Read);
        return JsonSerializer.Deserialize<IEnumerable<Pet>>(stream) ?? Enumerable.Empty<Pet>();
    }
}