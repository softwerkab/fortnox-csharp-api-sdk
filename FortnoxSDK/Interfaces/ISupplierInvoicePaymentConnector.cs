using System.Threading.Tasks;
using Fortnox.SDK.Entities;
using Fortnox.SDK.Search;

// ReSharper disable UnusedMember.Global
namespace Fortnox.SDK.Interfaces;

/// <remarks/>
public interface ISupplierInvoicePaymentConnector : IEntityConnector
{
    Task<SupplierInvoicePayment> UpdateAsync(SupplierInvoicePayment supplierInvoicePayment);
    Task<SupplierInvoicePayment> CreateAsync(SupplierInvoicePayment supplierInvoicePayment);
    Task<SupplierInvoicePayment> GetAsync(long? id);
    Task DeleteAsync(long? id);
    Task<EntityCollection<SupplierInvoicePaymentSubset>> FindAsync(SupplierInvoicePaymentSearch searchSettings);
    public Task BookkeepAsync(long? id);
}