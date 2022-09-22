using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Zwedze.Demo.Blazor.Web.Providers;

namespace Zwedze.Demo.Blazor.Web.Services;

internal static class BlazorWebService
{
    public static WebAssemblyHostBuilder ConfigureBlazorApp(this WebAssemblyHostBuilder builder)
    {
        builder.RootComponents.Add<App>("#app");
        builder.RootComponents.Add<HeadOutlet>("head::after");

        builder.Services.AddHttpClient("BackendApi", client =>
        {
            var config = builder.Configuration.GetSection("HttpClients:BackendApi:BaseAddress").Value;
            client.BaseAddress = new Uri(config);
        })
            .AddTypedClient<IClientApiProvider, ClientApiProvider>()
            .AddTypedClient<IInvoiceApiProvider, InvoiceApiProvider>();

        return builder;
    }
}