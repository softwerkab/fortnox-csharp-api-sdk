using System.Threading.Tasks;
using Fortnox.SDK.Entities;
using Fortnox.SDK.Search;

// ReSharper disable UnusedMember.Global
namespace Fortnox.SDK.Interfaces;

/// <remarks/>
public interface ISupplierInvoiceFileConnectionConnector : IEntityConnector
{
    Task<SupplierInvoiceFileConnection> CreateAsync(SupplierInvoiceFileConnection supplierInvoiceFileConnection);
    Task<SupplierInvoiceFileConnection> GetAsync(string id);
    Task DeleteAsync(string id);
    Task<EntityCollection<SupplierInvoiceFileConnection>> FindAsync(SupplierInvoiceFileConnectionSearch searchSettings);
}