using Alura.Adopet.Console.Modelos;

namespace Alura.Adopet.Console.Servicos.Abstracoes;

public interface ILeitorDeArquivo
{
    IEnumerable<Pet> RealizaLeitura();
}
