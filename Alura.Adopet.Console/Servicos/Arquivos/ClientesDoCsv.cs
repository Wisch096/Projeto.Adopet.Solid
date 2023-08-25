using Alura.Adopet.Console.Modelos;
using Alura.Adopet.Console.Servicos.Arquivos;

namespace Alura.Adopet.Console;
public class ClientesDoCsv : LeitorCsv<Cliente>
{
    public ClientesDoCsv(string caminhoArquivo) : base(caminhoArquivo) { }

    protected override Cliente? CreateFromCsv(string? csv)
    {
        if (csv is null) return null;
        string[] propriedades = csv.Split(',');
        return new Cliente(
            id: Guid.Parse(propriedades[0]),
            nome: propriedades[1],
            email: propriedades[2],
            cpf: propriedades[3]
        );
    }
}