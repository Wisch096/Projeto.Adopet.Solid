using Alura.Adopet.Console.Servicos;
using Moq;

namespace Alura.Adopet.Testes.Builder
{
    internal static class ApiServiceMockBuilder
    {
        public static Mock<IApiService<T>> GetMock<T>()
        {
            return new Mock<IApiService<T>>(MockBehavior.Default);
        }

        public static Mock<IApiService<T>> GetMockList<T>(List<T> lista)
        {
            var mock = new Mock<IApiService<T>>(MockBehavior.Default);
            mock.Setup(_ => _.ListAsync()).ReturnsAsync(lista);
            return mock;
        }

    }
}
