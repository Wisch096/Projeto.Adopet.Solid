using Alura.Adopet.Console.Results;
using Alura.Adopet.Console.Servicos.Abstracoes;
using Alura.Adopet.Console.Servicos.Arquivos;
using Alura.Adopet.Console.Servicos.Email;
using Alura.Adopet.Console.Servicos.Http;
using Alura.Adopet.Console.Settings;
using FluentResults;
using Microsoft.Extensions.Configuration;
using System.Net;
using System.Net.Mail;

namespace Alura.Adopet.Console.Comandos;

public class ImportFactory : IComandoFactory
{
    private IConfiguration _config;

    private IEmailService CriarEmailService()
    {
        AppSettings emailOptions = Configurations.GetSettings();
        var smtpClient = new SmtpClient()
        {
            Host = emailOptions.Servidor,
            Port = emailOptions.Porta,
            EnableSsl = true,
            UseDefaultCredentials = false,
            Credentials = new NetworkCredential(emailOptions.Usuario, emailOptions.Senha)
        };
        return new SmtpClientEmailService(smtpClient);
    }

    private void EnviaEmailAposImportacao(Result resultado)
    {
        ISuccess? success = resultado.Successes.FirstOrDefault();
        if (success is null) return;

        if (success is SuccessWithPets sucesso)
        {
            AppSettings emailOptions = Configurations.GetSettings();

            var emailService = CriarEmailService();
            emailService.SendMessageAsync(
                remetente: emailOptions.EmailAdmin,
                titulo: $"[Adopet] {sucesso.Message}",
                corpo: $"Foram importados {sucesso.Data.Count()} pets.",
                destinatario: emailOptions.Usuario
            );
        }
    }

    public bool ConsegueCriarOTipo(Type? tipoComando)
    {
        return tipoComando?.IsAssignableTo(typeof(Import)) ?? false;
    }

    public IComando? CriarComando(string[] argumentos)
    {
        
        var httpClientPet = new HttpClientPet(new AdopetAPIClientFactory().CreateClient("adopet"));
        var leitorDeArquivos = LeitorDeArquivoFactory.CreateLeitorDePets(argumentos[1]);
        if (leitorDeArquivos is null) return null;
        var comando = new Import(httpClientPet, leitorDeArquivos);
        comando.DepoisDaExecucao += EnviaEmailAposImportacao;
        return comando;
    }
}
