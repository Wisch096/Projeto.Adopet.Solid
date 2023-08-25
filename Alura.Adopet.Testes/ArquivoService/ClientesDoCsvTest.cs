using Alura.Adopet.Console;
using Alura.Adopet.Console.Modelos;
using Alura.Adopet.Console.Util;
using System.Text;

namespace Alura.Adopet.Testes;

public class ClientesDoCsvTest : IDisposable
{
    private readonly string caminhoArquivo;

    public ClientesDoCsvTest()
    {
        //Setup
        var conteudo = new StringBuilder()
            .Append("456b24f4-19e2-4423-845d-4a80e8854a41;André;andre@email.com;1121215")
            .Append("456b24f4-19e2-9821-845d-4a80e8854a41;Daniel;daniel@email.com;1121411")
            .Append("456b24f4-19e2-0192-845d-4a80e8854a41;Mariana;mari@email.com;1121221")
            .ToString();

        File.WriteAllText("lista.csv", conteudo);
        caminhoArquivo = Path.GetFullPath("lista.csv");
    }

    [Fact]
    public void QuandoConteudoValidoDeveRetornarLista()
    {
        // arrange
        ILeitorDeArquivo<Cliente> leitor = new ClientesDoCsv(caminhoArquivo);
        
        // act
        IEnumerable<Cliente> lista = leitor.RealizaLeitura();

        // assert
        Assert.NotNull(lista);
        Assert.Equal(3, lista.Count());
    }

    public void Dispose()
    {
        File.Delete(caminhoArquivo);
    }
}
