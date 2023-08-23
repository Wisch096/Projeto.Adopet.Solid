namespace Alura.Adopet.Console.Util;

public interface ILeitorDeArquivo
{
    IEnumerable<Modelos.Pet>? RealizaLeitura();
}
