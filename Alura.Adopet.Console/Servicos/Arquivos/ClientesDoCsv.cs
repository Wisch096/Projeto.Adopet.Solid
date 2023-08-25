using Alura.Adopet.Console.Modelos;
using Alura.Adopet.Console.Servicos;

namespace Alura.Adopet.Console;
public class ClientesDoCsv : ILeitorDeArquivo<Cliente>
{
    private readonly string caminhoArquivo;

    public ClientesDoCsv(string caminhoArquivo) => this.caminhoArquivo = caminhoArquivo;

    public IEnumerable<Cliente>? RealizaLeitura()
    {
        return Enumerable.Empty<Cliente>();
    }
}