using System.Threading.Tasks;
using Fortnox.SDK.Entities;
using Fortnox.SDK.Search;

// ReSharper disable UnusedMember.Global
namespace Fortnox.SDK.Interfaces;

/// <remarks/>
public interface IInvoiceConnector : IEntityConnector
{
    Task<Invoice> UpdateAsync(Invoice invoice);
    Task<Invoice> CreateAsync(Invoice invoice);
    Task<Invoice> GetAsync(long? id);
    Task<EntityCollection<InvoiceSubset>> FindAsync(InvoiceSearch searchSettings);

    Task<Invoice> BookkeepAsync(long? id);
    Task<Invoice> CancelAsync(long? id);
    Task<Invoice> CreditInvoiceAsync(long? id);
    Task<Invoice> EmailAsync(long? id);
    Task<Invoice> EInvoiceAsync(long? id);
    Task<Invoice> EPrintAsync(long? id);
    Task<byte[]> PrintAsync(long? id);
    Task<byte[]> PrintReminderAsync(long? id);
    Task<Invoice> ExternalPrintAsync(long? id);
    Task<byte[]> PreviewAsync(long? id);
    Task<Invoice> WarehouseReady(long? id);
}