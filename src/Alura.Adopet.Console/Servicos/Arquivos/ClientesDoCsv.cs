using Alura.Adopet.Console.Modelos;
using Alura.Adopet.Console.Servicos.Abstracoes;

namespace Alura.Adopet.Console.Servicos.Arquivos;

public class ClientesDoCsv : LeitorDeArquivoCsv<Cliente>
{
    public ClientesDoCsv(string caminhoArquivo) : base(caminhoArquivo)
    {    
    }

    public override Cliente CriarDaLinhaCsv(string linha)
    {
        string[] propriedades = linha.Split(';');

        return new Cliente(
            id: Guid.Parse(propriedades[0]),
            nome: propriedades[1],
            email: propriedades[2]
        );
    }
}