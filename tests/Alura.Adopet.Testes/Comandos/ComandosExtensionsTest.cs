using Alura.Adopet.Console.Comandos;
using Alura.Adopet.Console.Extensions;
using System.Reflection;

namespace Alura.Adopet.Testes.Comandos;

public class ComandosExtensionsTest
{
    [Theory]
    [InlineData("import", "Import")]
    [InlineData("import-clientes", "ImportClientes")]
    [InlineData("show", "Show")]
    [InlineData("list", "List")]
    [InlineData("help", "Help")]
    public void QuandoInstrucaoValidaDeveRetornarUmTipoComando(string instrucao, string tipoEsperado)
    {
        // arrange
        Assembly assembly = Assembly.GetAssembly(typeof(Import))!;

        // act
        Type? tipoRetornado = assembly.GetTipoDoComando(instrucao);

        // assert
        Assert.NotNull(tipoRetornado);
        Assert.Equal(tipoRetornado.Name, tipoEsperado);
    }
}
