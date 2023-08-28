namespace Alura.Adopet.Console.Servicos; 

public interface ILeitorDeArquivo
{
    IEnumerable<Modelos.Pet> RealizaLeitura();
}
