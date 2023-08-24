namespace Alura.Adopet.Console.Servicos;

public interface IApiService<T>
{
    Task CreateAsync(T obj);
    Task<IEnumerable<T>?> ListAsync();
}
