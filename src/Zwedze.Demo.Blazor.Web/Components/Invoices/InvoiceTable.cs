using System.Collections.Concurrent;
using Microsoft.AspNetCore.Components;
using Zwedze.Demo.Blazor.Contracts;
using Zwedze.Demo.Blazor.Web.Providers;

namespace Zwedze.Demo.Blazor.Web.Components.Invoices;

public partial class InvoiceTable
{
    [Inject] public IClientApiProvider ClientApiProvider { get; set; } = default!; //Using [Inject] we expect a non-null return

    [Parameter] [EditorRequired] public Invoice[] Invoices { get; set; } = Array.Empty<Invoice>();

    private InvoiceTableRecord[] _invoiceTableModels { get; set; } = Array.Empty<InvoiceTableRecord>();

    protected override async Task OnParametersSetAsync()
    {
        var invoiceRecords = new ConcurrentBag<InvoiceTableRecord>();

        await Parallel.ForEachAsync(Invoices, async (invoice, _) =>
        {
            var client = await ClientApiProvider.GetById(invoice.ClientId);
            if (client == null) throw new ApplicationException($"Invoice #{invoice.InvoiceId.Id:D} has no client!");
            invoiceRecords.Add(new InvoiceTableRecord(invoice.InvoiceId, client, invoice.TotalAmount, invoice.Rows,
                invoice.IssueDate, invoice.DueDate));
        });

        _invoiceTableModels = invoiceRecords.ToArray();
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
}