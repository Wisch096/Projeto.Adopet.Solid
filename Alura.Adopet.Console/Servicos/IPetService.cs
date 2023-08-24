using Alura.Adopet.Console.Modelos;

namespace Alura.Adopet.Console.Servicos;

public interface IPetService
{
    Task CreatePetAsync(Pet pet);
    Task<IEnumerable<Pet>?> ListPetsAsync();
}
