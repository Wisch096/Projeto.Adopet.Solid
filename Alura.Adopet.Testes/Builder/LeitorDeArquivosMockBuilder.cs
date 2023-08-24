using Alura.Adopet.Console.Modelos;
using Alura.Adopet.Console.Util;
using Moq;

namespace Alura.Adopet.Testes.Builder
{
    internal static class LeitorDeArquivosMockBuilder
    {
        public static Mock<ILeitorDeArquivo<Pet>> GetMock(List<Pet> listaDePet)
        {
            var leitorDeArquivo = new Mock<ILeitorDeArquivo<Pet>>(MockBehavior.Default);

            leitorDeArquivo.Setup(_ => _.RealizaLeitura()).Returns(listaDePet);

            return leitorDeArquivo;
        }

        public static Mock<ILeitorDeArquivo<Cliente>> GetMock(List<Cliente> listaDeClientes)
        {
            var leitorDeArquivo = new Mock<ILeitorDeArquivo<Cliente>>(MockBehavior.Default);

            leitorDeArquivo.Setup(_ => _.RealizaLeitura()).Returns(listaDeClientes);

            return leitorDeArquivo;
        }
    }
}
