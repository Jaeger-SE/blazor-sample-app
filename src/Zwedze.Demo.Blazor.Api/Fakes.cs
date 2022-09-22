using Zwedze.Demo.Blazor.Contracts;

namespace Zwedze.Demo.Blazor.Api;

internal static class Fakes
{
    private static long _clientId = 1;
    
    public static readonly Client[] Clients =
    {
        new()
        {
            ClientId = new ClientId
            {
                Id = _clientId++
            },
            Name = "Pika Corp.",
            Phone = "+30 444 333 22 11",
            Address = new Address
            {
                City = "Athens",
                Country = "Greece",
                PostCode = "106 75",
                Street = "Aristodimou",
                StreetNumber = "5"
            }
        },
        new()
        {
            ClientId = new ClientId
            {
                Id = _clientId++
            },
            Name = "Games Workshop",
            Phone = "+02 612 11 85 07",
            Address = new Address
            {
                City = "Nottingham",
                Country = "United Kingdom",
                PostCode = "NG7 2WS",
                Street = "Willow Road",
                StreetNumber = "1"
            }
        },
        new()
        {
            ClientId = new ClientId
            {
                Id = _clientId++
            },
            Name = "Makisu",
            Phone = "+32 554 17 82 47",
            Address = new Address
            {
                City = "Brussels",
                Country = "Belgium",
                PostCode = "1000",
                Street = "Rue de Flandre",
                StreetNumber = "6"
            }
        }
    };

    private static long _invoiceId = 1;
    private static long _ticketId = 1;
    
    public static readonly Invoice[] Invoices =
    {
        new()
        {
            IssueDate = DateTimeOffset.UtcNow,
            ClientId = Clients[0].ClientId,
            DueDate = DateTimeOffset.UtcNow.AddMonths(1),
            InvoiceId = new InvoiceId
            {
                Id = _invoiceId++
            },
            Rows = new[]
            {
                new InvoiceRow
                {
                    Amount = 900,
                    Description = "Plane ticket :: Brussels-Athens",
                    TicketIds = new[] {new TicketId {Id = _ticketId++}}
                },
                new InvoiceRow
                {
                    Amount = 17.7,
                    Description = "Taxi to Brussels Airport - 2022-10-17",
                    TicketIds = new[] {new TicketId {Id = _ticketId++}}
                },
                new InvoiceRow
                {
                    Amount = 450,
                    Description = "Hotel room :: 2022-10-17 -> 2022-10-19",
                    TicketIds = new[] {new TicketId {Id = _ticketId++}}
                },
                new InvoiceRow
                {
                    Amount = 40.7,
                    Description = "Restaurant - 2022-10-17",
                    TicketIds = new[] {new TicketId {Id = _ticketId++}}
                },
                new InvoiceRow
                {
                    Amount = 21.3,
                    Description = "Restaurant - 2022-10-18",
                    TicketIds = new[] {new TicketId {Id = _ticketId++}}
                },
                new InvoiceRow
                {
                    Amount = 417.2,
                    Description = "Restaurant - 2022-10-19",
                    TicketIds = new[] {new TicketId {Id = _ticketId++}}
                },
                new InvoiceRow
                {
                    Amount = 17.4,
                    Description = "Taxi to Athens Airport - 2022-10-19",
                    TicketIds = new[] {new TicketId {Id = _ticketId++}}
                },
                new InvoiceRow
                {
                    Amount = 24.5,
                    Description = "Taxi from Brussels Airport - 2022-10-20",
                    TicketIds = new[] {new TicketId {Id = _ticketId++}}
                },
            },
            TotalAmount = 1858.8
        }
    };

}