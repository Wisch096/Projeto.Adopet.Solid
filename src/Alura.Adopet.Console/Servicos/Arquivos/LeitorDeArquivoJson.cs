using Alura.Adopet.Console.Modelos;
using Alura.Adopet.Console.Servicos.Abstracoes;
using System.Text.Json;

namespace Alura.Adopet.Console.Servicos.Arquivos;

public class LeitorDeArquivoJson : ILeitorDeArquivo
{
    private readonly string caminhoArquivoASerLido;

    public LeitorDeArquivoJson(string caminhoArquivoASerLido)
    {
        this.caminhoArquivoASerLido = caminhoArquivoASerLido;
    }

    public IEnumerable<Pet> RealizaLeitura()
    {
        using var stream = new FileStream(caminhoArquivoASerLido, FileMode.Open, FileAccess.Read);
        return JsonSerializer.Deserialize<IEnumerable<Pet>>(stream);
    }
}
