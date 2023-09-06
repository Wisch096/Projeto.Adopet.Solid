using Alura.Adopet.Console.Comandos;
using Alura.Adopet.Console.Servicos.Arquivos;

namespace Alura.Adopet.Console.Comandos;

public class ShowFactory : IComandoFactory
{
    public IComando? CriarComando(string[] argumentos)
    {
        var leitorDeArquivosShow = LeitorDeArquivoFactory.CreateLeitorPetFrom(argumentos[1]);
        if (leitorDeArquivosShow is null) return null;
        return new Show(leitorDeArquivosShow);
    }
}