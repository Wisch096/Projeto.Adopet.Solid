using Alura.Adopet.Console.Modelos;
using Alura.Adopet.Console.Servicos.Arquivos;

namespace Alura.Adopet.Console.Util;

public class PetsDoCsv : LeitorCsv<Pet>
{
    public PetsDoCsv(string caminhoDoArquivoASerLido) : base(caminhoDoArquivoASerLido)
    { }

    protected override Pet? CreateFromCsv(string? csv)
    {
        if (csv is null) return null;
        string[]? propriedades = csv.Split(';');
        return new Pet(
            Guid.Parse(propriedades[0]),
            propriedades[1],
            int.Parse(propriedades[2]) == 1 ? TipoPet.Gato : TipoPet.Cachorro
        );
    }
}
