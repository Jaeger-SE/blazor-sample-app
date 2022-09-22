namespace Zwedze.Demo.Blazor.Contracts;

/// <summary>
///     An invoice for a specific client.
/// </summary>
public record Invoice
{
    public InvoiceId InvoiceId { get; init; }
    public ClientId ClientId { get; init; }
    public double TotalAmount { get; init; }
    public InvoiceRow[] Rows { get; init; } = Array.Empty<InvoiceRow>();
    public DateTimeOffset IssueDate { get; init; }
    public DateTimeOffset DueDate { get; init; }
}