using System.Net.Http.Json;
using Zwedze.Demo.Blazor.Contracts;

namespace Zwedze.Demo.Blazor.Web.Providers;

public interface IInvoiceApiProvider
{
    Task<Invoice?> GetById(InvoiceId invoiceId);
    Task<Invoice[]> GetList();
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

    public async Task<Invoice[]> GetList()
    {
        var list = await _httpClient.GetFromJsonAsync<Invoice[]>("api/invoice/list");
        return list ?? Array.Empty<Invoice>();
    }
}