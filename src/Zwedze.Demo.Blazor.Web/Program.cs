using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Zwedze.Demo.Blazor.Web.Services;

// Creating the builder and configure the runtime
var builder = WebAssemblyHostBuilder
    .CreateDefault(args)
    .ConfigureBlazorApp();

// Build then run the host
await builder.Build().RunAsync();