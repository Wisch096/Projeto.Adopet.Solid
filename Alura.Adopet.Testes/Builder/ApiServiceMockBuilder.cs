using Alura.Adopet.Console.Modelos;
using Alura.Adopet.Console.Servicos;
using Alura.Adopet.Console.Util;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alura.Adopet.Testes.Builder
{
    internal static class ApiServiceMockBuilder
    {
        public static Mock<IApiService<T>> GetMock<T>(List<T>? lista = null)
        {
            var mock = new Mock<IApiService<T>>(MockBehavior.Default);
            if (lista is not null)
                mock.Setup(_ => _.ListAsync()).ReturnsAsync(lista);
            return mock;
        }

    }
}
