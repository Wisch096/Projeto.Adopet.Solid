using Alura.Adopet.Console.Servicos.Http;
using Alura.Adopet.Console.Servicos.Arquivos;
using System.Reflection;
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

        Type? tipoQueAtendeOComando = Assembly
            .GetExecutingAssembly()
            .GetTipoDoComando(comando);

        if (tipoQueAtendeOComando is null) return null;

        IEnumerable<IComandoFactory?> fabricasDeComandos = Assembly
            .GetExecutingAssembly()
            .GetTypes()
            // filtre os tipos concretos que implementam IComandoFactory
            .Where(t => !t.IsInterface && t.IsAssignableTo(typeof(IComandoFactory)))
            // criar instâncias de cada fábrica (não é o ideal)
            .Select(f => Activator.CreateInstance(f) as IComandoFactory);

        IComandoFactory? fabrica = fabricasDeComandos
            .FirstOrDefault(f => f!.ConsegueCriarOTipo(tipoQueAtendeOComando));

        if (fabrica is null) return null;

        return fabrica.CriarComando(argumentos);
    }
}
