using System.Collections.Concurrent;
using Zwedze.Demo.Blazor.Contracts;

namespace Zwedze.Demo.Blazor.Web.Pages;

public partial class ListInvoices
{
    private InvoiceTableRecord[] _invoiceModels = Array.Empty<InvoiceTableRecord>();

    protected override async Task OnInitializedAsync()
    {
        var invoices = await InvoiceApiProvider.GetList();
        var invoiceRecords = new ConcurrentBag<InvoiceTableRecord>();

        await Parallel.ForEachAsync(invoices, async (invoice, _) =>
        {
            var client = await ClientApiProvider.GetById(invoice.ClientId);
            if (client == null) throw new ApplicationException($"Invoice #{invoice.InvoiceId.Id:D} has no client!");
            invoiceRecords.Add(new InvoiceTableRecord(invoice.InvoiceId, client, invoice.TotalAmount, invoice.Rows,
                invoice.IssueDate, invoice.DueDate));
        });

        _invoiceModels = invoiceRecords.ToArray();
    }
}

internal record InvoiceTableRecord
{
    public InvoiceTableRecord(InvoiceId invoiceId, Client client, double totalAmount, InvoiceRow[] rows,
        DateTimeOffset issueDate, DateTimeOffset dueDate)
    {
        InvoiceId = invoiceId;
        Client = client;
        TotalAmount = totalAmount;
        Rows = rows;
        IssueDate = issueDate;
        DueDate = dueDate;
    }

    public InvoiceId InvoiceId { get; }
    public Client Client { get; }
    public double TotalAmount { get; }
    public InvoiceRow[] Rows { get; }
    public DateTimeOffset IssueDate { get; }
    public DateTimeOffset DueDate { get; }
}