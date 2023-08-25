namespace Alura.Adopet.Console.Servicos;

public interface ILeitorDeArquivo<T>
{
    IEnumerable<T>? RealizaLeitura();
}
