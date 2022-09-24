using Microsoft.AspNetCore.Components;
using Zwedze.Demo.Blazor.Contracts;
using Zwedze.Demo.Blazor.Web.Providers;

namespace Zwedze.Demo.Blazor.Web.Pages;

public partial class ListInvoices
{
    private Invoice[] _invoices = Array.Empty<Invoice>();
    [Inject] public IInvoiceApiProvider InvoiceApiProvider { get; set; } = default!; //Using [Inject] we expect a non-null return

    protected override async Task OnInitializedAsync()
    {
        _invoices = await InvoiceApiProvider.GetList();
    }
}