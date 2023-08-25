using Alura.Adopet.Console.Util;

namespace Alura.Adopet.Testes;

public class LeitorDeArquivoFactoryTest
{
    [Fact]
    public void QuandoExtensaoCsvDeveRetornarLeitorDeArquivoCSV()
    {
        // arrange
        string nomeArquivo = "lista.csv";

        // act
        ILeitorDeArquivo? leitor = LeitorDeArquivoFactory.CreateLeitor(nomeArquivo);

        // assert
        Assert.NotNull(leitor);
        Assert.IsType<LeitorDeArquivoCsv>(leitor);
    }

    [Fact]
    public void QuandoExtensaoJsonDeveRetornarLeitorDeArquivoJson()
    {
        // arrange
        string nomeArquivo = "lista.json";

        // act
        ILeitorDeArquivo? leitor = LeitorDeArquivoFactory.CreateLeitor(nomeArquivo);

        // assert
        Assert.NotNull(leitor);
        Assert.IsType<LeitorDeArquivoJson>(leitor);
    }

    [Fact]
    public void QuandoExtensaoNaoSuportadaDeveRetornarNulo()
    {
        // arrange
        string nomeArquivo = "lista.xls";

        // act
        ILeitorDeArquivo? leitor = LeitorDeArquivoFactory.CreateLeitor(nomeArquivo);

        // assert
        Assert.Null(leitor);
    }
}
