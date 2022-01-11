using System.Threading.Tasks;
using Fortnox.SDK.Entities;
using Fortnox.SDK.Search;

// ReSharper disable UnusedMember.Global
namespace Fortnox.SDK.Interfaces;

/// <remarks/>
public interface ISupplierInvoiceAccrualConnector : IEntityConnector
{
    Task<SupplierInvoiceAccrual> UpdateAsync(SupplierInvoiceAccrual supplierInvoiceAccrual);
    Task<SupplierInvoiceAccrual> CreateAsync(SupplierInvoiceAccrual supplierInvoiceAccrual);
    Task<SupplierInvoiceAccrual> GetAsync(long? id);
    Task DeleteAsync(long? id);
    Task<EntityCollection<SupplierInvoiceAccrualSubset>> FindAsync(SupplierInvoiceAccrualSearch searchSettings);
}