using System.Net.Http.Json;
using Zwedze.Demo.Blazor.Contracts;

namespace Zwedze.Demo.Blazor.Web.Providers;

public interface IInvoiceApiProvider
{
    Task<Invoice?> GetById(InvoiceId invoiceId);
    Task<Invoice[]> GetClientInvoiceList(ClientId clientId, int? page = 0, int? pageSize = 20);
    Task<Invoice[]> GetList(int? page = 0, int? pageSize = 20);
}

internal class InvoiceApiProvider : IInvoiceApiProvider
{
    private readonly HttpClient _httpClient;

    public InvoiceApiProvider(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public Task<Invoice?> GetById(InvoiceId invoiceId)
    {
        return _httpClient.GetFromJsonAsync<Invoice>($"api/invoice/{invoiceId.Id}");
    }

    public async Task<Invoice[]> GetClientInvoiceList(ClientId clientId, int? page = 0, int? pageSize = 20)
    {
        var list = await _httpClient.GetFromJsonAsync<Invoice[]>($"api/invoice/list/{clientId.Id}?page={page}&pageSize={pageSize}");
        return list ?? Array.Empty<Invoice>();
    }

    public async Task<Invoice[]> GetList(int? page = 0, int? pageSize = 20)
    {
        var list = await _httpClient.GetFromJsonAsync<Invoice[]>($"api/invoice/list?page={page}&pageSize={pageSize}");
        return list ?? Array.Empty<Invoice>();
    }
}