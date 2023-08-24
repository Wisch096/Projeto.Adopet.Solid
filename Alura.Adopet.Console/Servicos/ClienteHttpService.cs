using Alura.Adopet.Console.Modelos;
using System.Net.Http.Json;

namespace Alura.Adopet.Console.Servicos;

public class ClienteHttpService : IApiService<Cliente>
{
    private readonly HttpClient httpClient;

    public ClienteHttpService(HttpClient httpClient) => this.httpClient = httpClient;

    public Task CreateAsync(Cliente obj) => httpClient.PostAsJsonAsync("clientes/add", obj);
    public async Task<IEnumerable<Cliente>?> ListAsync()
    {
        {
            HttpResponseMessage response = await httpClient.GetAsync("clientes/list");
            return await response.Content.ReadFromJsonAsync<IEnumerable<Cliente>>();
        }
    }
}
