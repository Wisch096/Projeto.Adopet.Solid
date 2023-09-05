using Alura.Adopet.Console.Modelos;
using Alura.Adopet.Console.Servicos.Arquivos;

namespace Alura.Adopet.Testes.Servicos;

public class LeitorDeArquivoFactoryTest
{
    [Fact]
    public void QuantoExtensaoForCsvDeveRetornarTipoLeitorDeArquivoCsv()
    {
        // arrange
        string caminhoArquivo = "pets.csv";

        // act
        var leitor = LeitorDeArquivoFactory.CreateLeitorPetFrom(caminhoArquivo);

        // assert
        Assert.IsType<PetsDoCsv>(leitor);
    }

    [Fact]
    public void QuantoExtensaoForJsonDeveRetornarTipoLeitorDeArquivoJson()
    {
        // arrange
        string caminhoArquivo = "pets.json";

        // act
        var leitor = LeitorDeArquivoFactory.CreateLeitorPetFrom(caminhoArquivo);

        // assert
        Assert.IsType<LeitorDeArquivoJson<Pet>>(leitor);
    }

    [Fact]
    public void QuantoNomeForClientesCsvDeveRetornarTipoClientesDoCsv()
    {
        // arrange
        string caminhoArquivo = "clientes.csv";

        // act
        var leitor = LeitorDeArquivoFactory.CreateLeitorClienteFrom(caminhoArquivo);

        // assert
        Assert.IsType<ClientesDoCsv>(leitor);
    }

    [Fact]
    public void QuantoExtensaoNaoSuportadaDeveRetornarNulo()
    {
        // arrange
        string caminhoArquivo = "pets.xsl";

        // act
        var leitor = LeitorDeArquivoFactory.CreateLeitorPetFrom(caminhoArquivo);

        // assert
        Assert.Null(leitor);
    }
}
