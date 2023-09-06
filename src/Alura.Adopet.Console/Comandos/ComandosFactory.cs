using Alura.Adopet.Console.Servicos.Http;
using Alura.Adopet.Console.Servicos.Arquivos;

namespace Alura.Adopet.Console.Comandos;

public static class ComandosFactory
{
    public static IComando? CriarComando(string[] argumentos)
    {
        if ((argumentos is null) || (argumentos.Length == 0))
        {
            return null;
        }
        var comando = argumentos[0];
        switch (comando)
        {
            case "import":
                return new ImportFactory().CriarComando(argumentos);

            case "list":
                return new ListFactory().CriarComando(argumentos);

            case "show":
                return new ShowFactory().CriarComando(argumentos);

            case "help":
                return new HelpFactory().CriarComando(argumentos);

            case "import-clientes":
                return new ImportClientesFactory().CriarComando(argumentos);

            default: return null;
        }           
    }
}
