using Microsoft.AspNetCore.Components;
using Zwedze.Demo.Blazor.Contracts;

namespace Zwedze.Demo.Blazor.Web.Pages;

public partial class ViewClient
{
    private Client? _client;
    private Invoice[] _invoices;

    [Parameter] public long Id { get; set; }

    protected override async Task OnInitializedAsync()
    {
        var clientId = new ClientId {Id = Id};

        var getClientInfoTask = ClientApiProvider.GetById(clientId);
        var getClientInvoicesTask = InvoiceApiProvider.GetClientInvoiceList(clientId);
        await Task.WhenAll(getClientInfoTask, getClientInvoicesTask);

        _client = getClientInfoTask.Result;
        _invoices = getClientInvoicesTask.Result;
    }
}