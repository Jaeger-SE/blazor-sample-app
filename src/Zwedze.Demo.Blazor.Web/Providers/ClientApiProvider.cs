using System.Diagnostics;
using System.Net.Http.Json;
using Zwedze.Demo.Blazor.Contracts;

namespace Zwedze.Demo.Blazor.Web.Providers;

public interface IClientApiProvider
{
    Task<Client?> GetById(ClientId clientId);
    Task<Client[]> GetList();
}

internal class ClientApiProvider : IClientApiProvider
{
    private readonly HttpClient _httpClient;

    public ClientApiProvider(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public Task<Client?> GetById(ClientId clientId)
    {
        return _httpClient.GetFromJsonAsync<Client>($"api/client/{clientId.Id}");
    }

    public async Task<Client[]> GetList()
    {
        var list = await _httpClient.GetFromJsonAsync<Client[]>("api/client/list");
        return list ?? Array.Empty<Client>();
    }
}