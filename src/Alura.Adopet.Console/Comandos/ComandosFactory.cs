using Alura.Adopet.Console.Servicos.Http;
using Alura.Adopet.Console.Servicos.Arquivos;
using Alura.Adopet.Console.Servicos.Abstracoes;
using System.Reflection;
using Alura.Adopet.Console.Atributos;
using Alura.Adopet.Console.Extensions;

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

        Type? tipoQueAtendeAInstrucao = Assembly
            .GetExecutingAssembly()
            .GetTipoDoComando(comando);

        if (tipoQueAtendeAInstrucao is null) return null;
        
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
