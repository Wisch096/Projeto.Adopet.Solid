using Alura.Adopet.Console.Modelos;
using Alura.Adopet.Console.Servicos.Abstracoes;
using Moq;

namespace Alura.Adopet.Testes.Builder;

internal static class LeitorDeArquivosMockBuilder
{
    public static Mock<ILeitorDeArquivo<Pet>> GetMock(List<Pet> listaDePet)
    {
        var leitorDeArquivo = new Mock<ILeitorDeArquivo<Pet>>(MockBehavior.Default);

        leitorDeArquivo.Setup(_ => _.RealizaLeitura()).Returns(listaDePet);

        return leitorDeArquivo;
    }
}
