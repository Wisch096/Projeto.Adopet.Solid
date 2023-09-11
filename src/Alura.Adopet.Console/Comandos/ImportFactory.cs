using Alura.Adopet.Console.Servicos.Abstracoes;
using Alura.Adopet.Console.Servicos.Arquivos;
using Alura.Adopet.Console.Servicos.Http;
using Alura.Adopet.Console.Servicos.Mail;
using Alura.Adopet.Console.Settings;
using System.Net;
using System.Net.Mail;

namespace Alura.Adopet.Console.Comandos;

public class ImportFactory : IComandoFactory
{
    public bool ConsegueCriarOTipo(Type tipoComando)
    {
        return tipoComando?.IsAssignableTo(typeof(Import)) ?? false;
    }

    public IComando? CriarComando(string[] argumentos)
    {
        var httpClientPet = new HttpClientPet(new AdopetAPIClientFactory().CreateClient("adopet"));
        var leitorDeArquivos = LeitorDeArquivoFactory.CreateLeitorPetFrom(argumentos[1]);
        if (leitorDeArquivos is null) return null;
        var import = new Import(httpClientPet, leitorDeArquivos);
        import.DepoisDaExecucao += EnvioDeEmail.Disparar;
        return import;
    }
}
