using Alura.Adopet.Console.Modelos;

namespace Alura.Adopet.Console.Util;

public abstract class LeitorDeArquivoCsv<T> : ILeitorDeArquivo<T>
{
    private string caminhoDoArquivoASerLido;

    public LeitorDeArquivoCsv(string caminhoDoArquivoASerLido)
    {
        this.caminhoDoArquivoASerLido = caminhoDoArquivoASerLido;
    }

    protected abstract T? CreateFromCSV(string? csv);

    public IEnumerable<T> RealizaLeitura()
    {
        if (string.IsNullOrEmpty(this.caminhoDoArquivoASerLido))
        {
            return null;
        }
        List<T> lista = new();
        using StreamReader sr = new(caminhoDoArquivoASerLido);               
        while (!sr.EndOfStream)
        {
            T? objeto = CreateFromCSV(sr.ReadLine());
            if (objeto is not null) lista.Add(objeto);
        }
        return lista;
    }
}

public class LeitorDePetsDoCsv : LeitorDeArquivoCsv<Pet>
{
    public LeitorDePetsDoCsv(string caminhoDoArquivoASerLido) : base(caminhoDoArquivoASerLido)
    {
    }

    protected override Pet? CreateFromCSV(string? csv)
    {
        if (csv is null) return null;
        string[] propriedades = csv.Split(';');
        return new Pet(
            id: Guid.Parse(propriedades[0]),
            nome: propriedades[1],
            tipo: int.Parse(propriedades[2]) == 1 ? TipoPet.Gato : TipoPet.Cachorro
        );
    }
}

public class LeitorDeClientesDoCsv : LeitorDeArquivoCsv<Cliente>
{
    public LeitorDeClientesDoCsv(string caminhoDoArquivoASerLido) : base(caminhoDoArquivoASerLido)
    {
    }

    protected override Cliente? CreateFromCSV(string? csv) 
    {
        if (csv is null) return null;
        string[] propriedades = csv.Split(';');
        return new Cliente(
            id: Guid.Parse(propriedades[0]),
            nome: propriedades[1],
            email: propriedades[2],
            cpf: propriedades[3]
        );
    }
}


/*
* 
*/