namespace Alura.Adopet.Console.Comandos;

public interface IComandoFactory<TComando> where TComando : IComando
{
    bool ConsegueCriarOTipo(Type? tipoComando)
    {
        return tipoComando?.IsAssignableTo(typeof(TComando)) ?? false;
    }
    IComando? CriarComando(string[] argumentos);
}
