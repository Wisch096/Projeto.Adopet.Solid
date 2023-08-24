namespace Alura.Adopet.Console.Modelos;

public class Cliente
{
    public Cliente(Guid id, string nome, string email, string cpf)
    {
        Id = id;
        Nome = nome;
        Email = email;
        Cpf = cpf;
    }

    public Guid Id { get; }
    public string Nome { get; }
    public string Email { get; }
    public string Cpf { get; }

    public override string ToString()
    {
        return $"{Id} - {Nome} - {Cpf} - {Email}";
    }
}