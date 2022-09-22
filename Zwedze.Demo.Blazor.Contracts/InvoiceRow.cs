namespace Zwedze.Demo.Blazor.Contracts;

/// <summary>
///     An invoice row containing all info related to a set of Ticket.
/// </summary>
public record InvoiceRow
{
    public string Description { get; init; }
    public double Amount { get; set; }
    public TicketId[] TicketIds { get; init; } = Array.Empty<TicketId>();
}