using Alura.Adopet.Console.Modelos;
using Alura.Adopet.Console.Servicos;
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
        ILeitorDeArquivo<Pet>? leitor = LeitorDeArquivoFactory.CreateLeitorDePet(nomeArquivo);

        // assert
        Assert.NotNull(leitor);
        Assert.IsType<PetsDoCsv>(leitor);
    }

    [Fact]
    public void QuandoExtensaoJsonDeveRetornarLeitorDeArquivoJson()
    {
        // arrange
        string nomeArquivo = "lista.json";

        // act
        ILeitorDeArquivo<Pet>? leitor = LeitorDeArquivoFactory.CreateLeitorDePet(nomeArquivo);

        // assert
        Assert.NotNull(leitor);
        Assert.IsType<PetsDoJson>(leitor);
    }

    [Fact]
    public void QuandoExtensaoNaoSuportadaDeveRetornarNulo()
    {
        // arrange
        string nomeArquivo = "lista.xls";

        // act
        ILeitorDeArquivo<Pet>? leitor = LeitorDeArquivoFactory.CreateLeitorDePet(nomeArquivo);

        // assert
        Assert.Null(leitor);
    }
}
