using Alura.Adopet.Console;

namespace Alura.Adopet.Testes;

using Alura.Adopet.Console.Comandos;
using Alura.Adopet.Testes.Builder;
using Alura.Adopet.Console.Modelos;
using FluentResults;
using Xunit;
using Alura.Adopet.Console.Util;

public class ImportClientesTest
{
    [Fact]
    public async Task Test01()
    {
        // arrange
        List<Cliente> listaDeClientes = new();
        var cliente = new Cliente(
            id: new Guid("456b24f4-19e2-4423-845d-4a80e8854a99"),
            nome: "Fulano de Tal", 
            email: "fulano@example.org",
            cpf: "12301831903810" );

        listaDeClientes.Add(cliente);

        var leitorDeArquivo = LeitorDeArquivosMockBuilder.GetMock(listaDeClientes);

        var httpClientPet = ApiServiceMockBuilder.GetMock<Cliente>();

        var comando = new ImportClientes(httpClientPet.Object, leitorDeArquivo.Object);

        // act
        Result resultado = await comando.ExecutarAsync();

        // assert
        Assert.True(resultado.IsSuccess);
        var sucesso = (SuccessWithData<Cliente>)resultado.Successes[0];
        Assert.Equal("Fulano de Tal", sucesso.Data.First().Nome);
    }
}
