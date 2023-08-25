using Alura.Adopet.Console.Modelos;
using Alura.Adopet.Console.Servicos.Arquivos;

namespace Alura.Adopet.Console.Util;

public class PetsDoJson : LeitorJson<Pet>
{
    public PetsDoJson(string caminhoArquivo) : base(caminhoArquivo) { }
}