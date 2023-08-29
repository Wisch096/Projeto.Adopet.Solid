using Alura.Adopet.Console.Modelos;

namespace Alura.Adopet.Console.Servicos.Arquivos;

public class ClientesDoCsv : LeitorArquivoCsv<Cliente>
{
    public ClientesDoCsv(string caminhoArquivo) : base(caminhoArquivo)
    {
    }

    protected override Cliente CreateObject(string linha)
    {
        string[]? propriedades = linha?.Split(';') ?? throw new ArgumentNullException("Texto não pode ser nulo!");

        if (string.IsNullOrEmpty(linha)) throw new ArgumentException("Texto não pode ser vazio");

        bool guidValido = Guid.TryParse(propriedades[0], out Guid guid);
        if (!guidValido) throw new ArgumentException("Identificador inválido!");

        var obj = new Cliente(
            id: guid, 
            nome: propriedades[1], 
            email: propriedades[2]);

        if (propriedades.Length > 3)
        {
            obj.CPF = propriedades[3];
        }

        return obj;
    }
}