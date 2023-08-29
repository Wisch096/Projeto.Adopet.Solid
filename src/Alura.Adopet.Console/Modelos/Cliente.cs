namespace Alura.Adopet.Console.Modelos;

public class Cliente
{
    public Cliente(Guid id, string nome, string email)
    {
        Id = id;
        Nome = nome;
        Email = email;
    }

    public Guid Id { get;}
    public string Nome { get;}
    public string Email { get; }
    public string? CPF { get; set; }

    public override string? ToString()
    {
        return $"{Id} - {Nome} - {Email}";
    }
}
