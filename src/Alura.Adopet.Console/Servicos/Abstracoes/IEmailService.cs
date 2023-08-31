namespace Alura.Adopet.Console.Servicos.Abstracoes;

public interface IEmailService
{
    Task SendMessageAsync(string destinatario, string titulo, string corpo, string remetente);
}
