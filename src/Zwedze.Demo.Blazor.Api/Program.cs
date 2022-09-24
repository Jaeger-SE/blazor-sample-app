using Zwedze.Demo.Blazor.Api;
using Zwedze.Demo.Blazor.Contracts;

// Setup for a local mock provider
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddCors();

var app = builder.Build();
app.UseCors(x => x.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());

// Index
app
    .MapGet("/", () => Results.Text("Api is running."))
    .Produces<string>();

// Invoices
app
    .MapGet("/api/invoice/list/{clientId:long}", (long clientId, int? page, int? pageSize) =>
        {
            var invoices = Fakes.Invoices.Where(i => i.ClientId.Id == clientId)
                .Skip(page ?? 0 * pageSize ?? 20).Take(pageSize ?? 20)
                .ToArray();
            return Results.Ok(invoices);
        }
    )
    .Produces<Invoice[]>();
app
    .MapGet("/api/invoice/list", (int? page, int? pageSize) =>
    {
        var invoices = Fakes.Invoices.Skip(page ?? 0 * pageSize ?? 20).Take(pageSize ?? 20);
        return Results.Ok(invoices);
    })
    .Produces<Invoice[]>();
app
    .MapGet("/api/invoice/{id:long}", (long id) =>
    {
        var i = Fakes.Invoices.SingleOrDefault(x => x.InvoiceId.Id == id);
        return i != default ? Results.Ok(i) : Results.NotFound();
    })
    .Produces<Invoice>()
    .ProducesProblem(StatusCodes.Status404NotFound);

// Clients
app
    .MapGet("/api/client/list", () =>
        Results.Ok(Fakes.Clients)
    )
    .Produces<Client>();
app
    .MapGet("/api/client/{id:long}", (long id) =>
    {
        var c = Fakes.Clients.SingleOrDefault(x => x.ClientId.Id == id);
        return c != default ? Results.Ok(c) : Results.NotFound();
    })
    .Produces<Client>()
    .ProducesProblem(StatusCodes.Status404NotFound);

// Run the whole thing
app.Run();