using Zwedze.Demo.Blazor.Contracts;

namespace Zwedze.Demo.Blazor.Web.Pages;

public partial class ListClients
{
    private Client[] _clients = Array.Empty<Client>();

    protected override async Task OnInitializedAsync()
    {
        _clients = await ClientApiProvider.GetList();
    }
}