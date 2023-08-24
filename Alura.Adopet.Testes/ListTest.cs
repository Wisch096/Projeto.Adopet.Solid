using Alura.Adopet.Console.Modelos;
using Alura.Adopet.Console.Util;
using Alura.Adopet.Testes.Builder;

namespace Alura.Adopet.Testes
{
    public class ListTest
    {
        [Fact]
        public async Task QuandoExecutarComandoListDeveRetornarListaDePets()
        {
            //Arrange
            List<Pet>? listaDePet = new();
            var pet = new Pet(new Guid("456b24f4-19e2-4423-845d-4a80e8854a99"),
                              "Lima", TipoPet.Cachorro);
            listaDePet.Add(pet);

            var httpClientPet = ApiServiceMockBuilder.GetMock<Pet>(listaDePet);

            //Act
            var retorno = await new Alura.Adopet.Console.Comandos.List(httpClientPet.Object)
                .ExecutarAsync();

            //Assert
            var resultado = (SuccessWithData<Pet>) retorno.Successes[0];
            Assert.Single(resultado.Data);
        }


    }
}
