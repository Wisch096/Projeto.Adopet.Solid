using Alura.Adopet.Console.Servicos.Abstracoes;
using System.Net.Mail;

namespace Alura.Adopet.Console.Servicos.Email;

public class SmtpClientEmailService : IEmailService
{
    private readonly SmtpClient smtpClient;

    public SmtpClientEmailService(SmtpClient smtpClient)
    {
        this.smtpClient = smtpClient;
    }

    public Task SendMessageAsync(
        string destinatario, 
        string titulo, 
        string corpo, 
        string remetente)
    {
        var message = new MailMessage
        {
            From = new MailAddress(destinatario),
            Subject = titulo,
            Body = corpo
        };
        
        message.To.Add(new MailAddress(remetente));

        return smtpClient.SendMailAsync(message);
    }
}
