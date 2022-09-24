using System.Diagnostics;
using Zwedze.Demo.Blazor.Contracts;

namespace Zwedze.Demo.Blazor.Web.Pages;

public partial class ListClients
{
    private Client[] _clients = Array.Empty<Client>();

    protected override async Task OnInitializedAsync()
    {
        _clients = await ClientApiProvider.GetList();
    }

    public Task CreateNewClient(Client newClient)
    {
        Debugger.Log(1, "debugger info", $"New Client request: {newClient}");
        return Task.CompletedTask;
    }

    public Task ViewClient(ClientId clientId)
    {
        NavigationManager.NavigateTo($"/clients/{clientId.Id}");
        return Task.CompletedTask;
    }
}