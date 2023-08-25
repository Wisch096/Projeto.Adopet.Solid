namespace Alura.Adopet.Console.Util;

public interface ILeitorDeArquivo<T>
{
    IEnumerable<T>? RealizaLeitura();
}
