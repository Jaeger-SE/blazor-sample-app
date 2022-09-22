using Zwedze.Demo.Blazor.Api;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddCors();
var app = builder.Build();

app.UseCors(x => x.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());

app.MapGet("/api/invoice/list", () =>
    Results.Ok(Fakes.Invoices)
);
app.MapGet("/api/invoice/{id:long}", (long id) =>
{
    var i = Fakes.Invoices.SingleOrDefault(x => x.InvoiceId.Id == id);
    return i != default ? Results.Ok(i) : Results.NotFound();
});
app.MapGet("/api/client/list", () =>
    Results.Ok(Fakes.Clients)
);
app.MapGet("/api/client/{id:long}", (long id) =>
{
    var c = Fakes.Clients.SingleOrDefault(x => x.ClientId.Id == id);
    return c != default ? Results.Ok(c) : Results.NotFound();
});

app.Run();