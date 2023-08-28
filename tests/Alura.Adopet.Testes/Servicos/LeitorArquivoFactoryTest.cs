using Alura.Adopet.Console.Servicos.Abstracoes;
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
        ILeitorDeArquivo? leitor = LeitorDeArquivoFactory.CreateLeitor(caminhoDoArquivo);

        // assert
        Assert.NotNull(leitor);
        Assert.IsType<LeitorDeArquivoCsv>(leitor);
    }

    [Fact]
    public void QuandoExtensaoJsonDeveRetornarTipoAdequado()
    {
        // arrange
        string caminhoDoArquivo = "qualquernome.json";

        // act
        ILeitorDeArquivo? leitor = LeitorDeArquivoFactory.CreateLeitor(caminhoDoArquivo);

        // assert
        Assert.NotNull(leitor);
        Assert.IsType<LeitorDeArquivoJson>(leitor);
    }
}
