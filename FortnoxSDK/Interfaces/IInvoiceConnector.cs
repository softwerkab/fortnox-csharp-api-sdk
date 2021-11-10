using System;
using System.Threading.Tasks;
using Fortnox.SDK.Entities;
using Fortnox.SDK.Search;

// ReSharper disable UnusedMember.Global
namespace Fortnox.SDK.Interfaces;

/// <remarks/>
public interface IInvoiceConnector : IEntityConnector
{
    [Obsolete(ApiConstants.ObsoleteSyncMethodWarning)]
    Invoice Update(Invoice invoice);
    [Obsolete(ApiConstants.ObsoleteSyncMethodWarning)]
    Invoice Create(Invoice invoice);
    [Obsolete(ApiConstants.ObsoleteSyncMethodWarning)]
    Invoice Get(long? id);
    [Obsolete(ApiConstants.ObsoleteSyncMethodWarning)]
    EntityCollection<InvoiceSubset> Find(InvoiceSearch searchSettings);
    [Obsolete(ApiConstants.ObsoleteSyncMethodWarning)]
    Invoice Bookkeep(long? id);
    [Obsolete(ApiConstants.ObsoleteSyncMethodWarning)]
    Invoice Cancel(long? id);
    [Obsolete(ApiConstants.ObsoleteSyncMethodWarning)]
    Invoice CreditInvoice(long? id);
    [Obsolete(ApiConstants.ObsoleteSyncMethodWarning)]
    Invoice Email(long? id);
    [Obsolete(ApiConstants.ObsoleteSyncMethodWarning)]
    Invoice EInvoice(long? id);
    [Obsolete(ApiConstants.ObsoleteSyncMethodWarning)]
    byte[] Print(long? id);
    [Obsolete(ApiConstants.ObsoleteSyncMethodWarning)]
    byte[] PrintReminder(long? id);
    [Obsolete(ApiConstants.ObsoleteSyncMethodWarning)]
    Invoice ExternalPrint(long? id);
    [Obsolete(ApiConstants.ObsoleteSyncMethodWarning)]
    byte[] Preview(long? id);

    Task<Invoice> UpdateAsync(Invoice invoice);
    Task<Invoice> CreateAsync(Invoice invoice);
    Task<Invoice> GetAsync(long? id);
    Task<EntityCollection<InvoiceSubset>> FindAsync(InvoiceSearch searchSettings);

    Task<Invoice> BookkeepAsync(long? id);
    Task<Invoice> CancelAsync(long? id);
    Task<Invoice> CreditInvoiceAsync(long? id);
    Task<Invoice> EmailAsync(long? id);
    Task<Invoice> EInvoiceAsync(long? id);
    Task<byte[]> PrintAsync(long? id);
    Task<byte[]> PrintReminderAsync(long? id);
    Task<Invoice> ExternalPrintAsync(long? id);
    Task<byte[]> PreviewAsync(long? id);
}