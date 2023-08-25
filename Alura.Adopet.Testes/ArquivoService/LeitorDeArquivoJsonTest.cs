using Alura.Adopet.Console.Util;
using Alura.Adopet.Console.Modelos;

namespace Alura.Adopet.Testes;

public class LeitorDeArquivoJsonTest : IDisposable
{
    private readonly string caminhoArquivo;

    public LeitorDeArquivoJsonTest()
    {
        //Setup

        string conteudo = @"
            [
              {
                ""id"": ""68286fbf-f6f4-4924-adab-0637511813e0"",
                ""nome"": ""Mancha"",
                ""tipo"": 0
              },
              {
                ""id"": ""68286fbf-f6f4-4924-adab-0637511672e0"",
                ""nome"": ""Alvo"",
                ""tipo"": 0
              },
              {
                ""id"": ""68286fbf-f6f4-1234-adab-0637511672e0"",
                ""nome"": ""Pinta"",
                ""tipo"": 0
              }
            ]
        ";
        
        File.WriteAllText("lista.json", conteudo);
        caminhoArquivo = Path.GetFullPath("lista.json");
    }

    [Fact]
    public void QuandoJsonValidoDeveRetornarListaDePetsNaoVazia()
    {
        // arrange
        LeitorDeArquivoJson leitor = new(caminhoArquivo);

        // act
        IEnumerable<Pet> listaDePets = leitor.RealizaLeitura();

        // assert
        Assert.NotNull(listaDePets);
        Assert.NotEmpty(listaDePets);
        Assert.Equal(3, listaDePets.Count());
    }

    public void Dispose()
    {
        //ClearDown
        File.Delete(caminhoArquivo);
    }
}
