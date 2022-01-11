using System.Threading.Tasks;
using Fortnox.SDK.Entities;
using Fortnox.SDK.Search;

// ReSharper disable UnusedMember.Global
namespace Fortnox.SDK.Interfaces;

/// <remarks/>
public interface ISupplierInvoiceConnector : IEntityConnector
{
    Task<SupplierInvoice> UpdateAsync(SupplierInvoice supplierInvoice);
    Task<SupplierInvoice> CreateAsync(SupplierInvoice supplierInvoice);
    Task<SupplierInvoice> GetAsync(long? id);
    Task<EntityCollection<SupplierInvoiceSubset>> FindAsync(SupplierInvoiceSearch searchSettings);
    Task<SupplierInvoice> BookkeepAsync(long? id);
    Task<SupplierInvoice> CancelAsync(long? id);
    Task<SupplierInvoice> CreditAsync(long? id);
    Task<SupplierInvoice> ApprovalPaymentAsync(long? id);
    Task<SupplierInvoice> ApprovalBookkeepAsync(long? id);
}