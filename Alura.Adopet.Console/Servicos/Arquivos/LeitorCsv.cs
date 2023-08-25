namespace Alura.Adopet.Console.Servicos.Arquivos;

public abstract class LeitorCsv<T> : ILeitorDeArquivo<T>
{
    private readonly string caminhoArquivo;

    protected LeitorCsv(string caminhoArquivo) => this.caminhoArquivo = caminhoArquivo;

    protected abstract T? CreateFromCsv(string? csv);

    public IEnumerable<T>? RealizaLeitura()
    {
        if (string.IsNullOrEmpty(caminhoArquivo))
        {
            return null;
        }

        List<T> lista = new();
        using StreamReader sr = new(caminhoArquivo);
        while (!sr.EndOfStream)
        {
            T objeto = CreateFromCsv(sr.ReadLine());
            //string[]? propriedades = sr.ReadLine().Split(';');
            //Pet pet = new Pet(Guid.Parse(propriedades[0]),
            //propriedades[1],
            //int.Parse(propriedades[2]) == 1 ? TipoPet.Gato : TipoPet.Cachorro
            //);
            lista.Add(objeto);
        }
        return lista;
    }
}
