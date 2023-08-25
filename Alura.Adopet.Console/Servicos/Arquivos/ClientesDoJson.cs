using Alura.Adopet.Console.Modelos;

namespace Alura.Adopet.Console.Servicos.Arquivos;

public class ClientesDoJson : LeitorJson<Cliente>
{
    public ClientesDoJson(string caminhoArquivo) : base(caminhoArquivo)
    {
    }
}
