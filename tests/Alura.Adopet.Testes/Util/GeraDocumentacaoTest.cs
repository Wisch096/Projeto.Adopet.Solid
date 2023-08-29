using Alura.Adopet.Console.Atributos;
using Alura.Adopet.Console.Util;
using System.Reflection;

namespace Alura.Adopet.Testes.Util;

public class GeraDocumentacaoTest
{
    [Fact]
    public void QuandoExistemComandosDeveRetornarDicionarioNaoVazio()
    {
        //Arrange
        Assembly assemblyComOTipoDocComando = Assembly.GetAssembly(typeof(DocComandoAttribute))!;

        //Act
        Dictionary<string, DocComandoAttribute> dicionario =
              DocumentacaoDoSistema.ToDictionary(assemblyComOTipoDocComando);

        //Assert            
        Assert.NotNull(dicionario);
        Assert.NotEmpty(dicionario);
        Assert.Equal(5, dicionario.Count);
    }

    [Theory]
    [InlineData("help", true)]
    [InlineData("show", true)]
    [InlineData("list", true)]
    [InlineData("import", true)]
    [InlineData("import-clientes", false)]
    [InlineData("lixo", false)]
    [InlineData("", false)]
    [InlineData("   ", false)]
    public void DadaInstrucaoValidaDeveExistirNoDicionario(string instrucao, bool valido)
    {
        //Arrange
        Assembly assemblyComOTipoDocComando = Assembly.GetAssembly(typeof(DocComandoAttribute))!;

        //Act
        Dictionary<string, DocComandoAttribute> dicionario =
              DocumentacaoDoSistema.ToDictionary(assemblyComOTipoDocComando);

        //Assert            
        Assert.NotNull(dicionario);
        Assert.NotEmpty(dicionario);
        Assert.Equal(valido, dicionario.ContainsKey(instrucao));
    }
}
