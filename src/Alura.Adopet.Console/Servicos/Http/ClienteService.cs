using Alura.Adopet.Console.Modelos;
using Alura.Adopet.Console.Servicos.Abstracoes;
using System.Net.Http.Json;

namespace Alura.Adopet.Console.Servicos.Http;

public class ClienteService : IApiService<Cliente>
{
    private readonly HttpClient httpClient;

    public ClienteService(HttpClient httpClient)
    {
        this.httpClient = httpClient;
    }

    public Task CreateAsync(Cliente obj)
    {
        return httpClient.PostAsJsonAsync("clientes/add", obj);
    }

    public async Task<IEnumerable<Cliente>?> ListAsync()
    {
        HttpResponseMessage response = await httpClient.GetAsync("clientes/list");
        return await response.Content.ReadFromJsonAsync<IEnumerable<Cliente>?>();
    }
}