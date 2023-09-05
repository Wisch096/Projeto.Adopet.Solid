using Alura.Adopet.Console.Modelos;
using Alura.Adopet.Console.Servicos.Abstracoes;
using System.Net.Http.Json;

namespace Alura.Adopet.Console.Servicos.Http;

public class ClienteService : IApiService<Cliente>
{
    private readonly HttpClient client;

    public ClienteService(HttpClient client)
    {
        this.client = client;
    }

    public Task CreateAsync(Cliente cliente)
    {
        return client.PostAsJsonAsync("clientes/add", cliente);
    }

    public async Task<IEnumerable<Cliente>?> ListAsync()
    {
        HttpResponseMessage response = await client.GetAsync("clientes/list");
        return await response.Content.ReadFromJsonAsync<IEnumerable<Cliente>>();
    }
}