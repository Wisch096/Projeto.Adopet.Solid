using Alura.Adopet.Console.Servicos.Arquivos;

namespace Alura.Adopet.Testes.Servicos;

public class LeitorArquivoFactoryTest
{
    [Fact]
    public void QuandoExtensaoCsvDeveRetornarTipoAdequado()
    {
        // arrange
        string caminhoDoArquivo = "lista.csv";

        // act
        var leitor = LeitorDeArquivoFactory.CreateLeitorDePets(caminhoDoArquivo);

        // assert
        Assert.NotNull(leitor);
        Assert.IsType<PetsDoCsv>(leitor);
    }

    [Fact]
    public void QuandoExtensaoJsonDeveRetornarTipoAdequado()
    {
        // arrange
        string caminhoDoArquivo = "qualquernome.json";

        // act
        var leitor = LeitorDeArquivoFactory.CreateLeitorDePets(caminhoDoArquivo);

        // assert
        Assert.NotNull(leitor);
        Assert.IsType<PetsDoJson>(leitor);
    }
}
