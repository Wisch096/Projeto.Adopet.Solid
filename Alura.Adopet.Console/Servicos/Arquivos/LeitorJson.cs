using System.Text.Json;

namespace Alura.Adopet.Console.Servicos.Arquivos;

public abstract class LeitorJson<T> : ILeitorDeArquivo<T>
{
    private readonly string caminhoArquivo;

    protected LeitorJson(string caminhoArquivo) => this.caminhoArquivo = caminhoArquivo;

    public IEnumerable<T>? RealizaLeitura()
    {
        using var stream = new FileStream(caminhoArquivo, FileMode.Open, FileAccess.Read);

        return JsonSerializer.Deserialize<IEnumerable<T>>(stream);
    }
}
