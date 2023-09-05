using Alura.Adopet.Console.Modelos;
using Alura.Adopet.Console.Servicos.Abstracoes;

namespace Alura.Adopet.Console.Servicos.Arquivos;

public static class LeitorDeArquivoFactory
{
    public static ILeitorDeArquivo<Cliente> CreateLeitorClienteFrom(string caminhoArquivo)
    {
        var extensao = Path.GetExtension(caminhoArquivo);
        switch (extensao)
        {
            case ".csv":
                return new ClientesDoCsv(caminhoArquivo);
            case ".json":
                return new LeitorDeArquivoJson<Cliente>(caminhoArquivo);
            default: return null;
        }
    }

    public static ILeitorDeArquivo<Pet>? CreateLeitorPetFrom(string caminhoArquivo)
    {
        var extensao = Path.GetExtension(caminhoArquivo);
        switch (extensao)
        {
            case ".csv": 
                return new PetsDoCsv(caminhoArquivo);
            case ".json":
                return new LeitorDeArquivoJson<Pet>(caminhoArquivo);
            default: return null;
        }
    }
}