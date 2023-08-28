namespace Alura.Adopet.Console.Servicos.Abstracoes;

public interface ILeitorDeArquivo
{
    IEnumerable<Modelos.Pet> RealizaLeitura();
}
