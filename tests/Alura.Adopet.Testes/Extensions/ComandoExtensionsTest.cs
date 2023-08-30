using Alura.Adopet.Console.Comandos;
using Alura.Adopet.Console.Extensions;
using System.Reflection;

namespace Alura.Adopet.Testes.Extensions;

public class ComandoExtensionsTest
{
    [Theory]
    [InlineData("import", "Import")]
    [InlineData("import-clientes", "ImportClientes")]
    [InlineData("show", "Show")]
    [InlineData("list", "List")]
    [InlineData("help", "Help")]
    public void QuandoInstrucaoForSuportadaDeveRetornarTipoDeComando(string instrucao, string nomeClasse)
    {
        // arrange
        Assembly assemblyASerVerificada = Assembly.GetAssembly(typeof(Import))!;

        // act
        Type? tipoRetornado = assemblyASerVerificada.GetTipoDoComando(instrucao);


        // assert
        Assert.NotNull(tipoRetornado);
        Assert.Equal(nomeClasse, tipoRetornado.Name);
    }

    [Fact]
    public void QuandoInstrucaoNaoSuportadaDeveRetornarNulo()
    {
        // arrange
        Assembly assemblyASerVerificada = Assembly.GetAssembly(typeof(Import))!;

        // act
        Type? tipoRetornado = assemblyASerVerificada.GetTipoDoComando("qualquer coisa");


        // assert
        Assert.Null(tipoRetornado);
    }

}
