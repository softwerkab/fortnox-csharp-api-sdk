using System;
using System.Threading.Tasks;
using Fortnox.SDK.Entities;
using Fortnox.SDK.Search;

// ReSharper disable UnusedMember.Global
namespace Fortnox.SDK.Interfaces
{
    /// <remarks/>
    public interface ISupplierInvoiceConnector : IEntityConnector
    {
        [Obsolete(APIConstants.ObsoleteSyncMethodWarning)]
        SupplierInvoice Update(SupplierInvoice supplierInvoice);
        [Obsolete(APIConstants.ObsoleteSyncMethodWarning)]
        SupplierInvoice Create(SupplierInvoice supplierInvoice);
        [Obsolete(APIConstants.ObsoleteSyncMethodWarning)]
        SupplierInvoice Get(long? id);
        [Obsolete(APIConstants.ObsoleteSyncMethodWarning)]
        EntityCollection<SupplierInvoiceSubset> Find(SupplierInvoiceSearch searchSettings);
        [Obsolete(APIConstants.ObsoleteSyncMethodWarning)]
        SupplierInvoice Bookkeep(long? id);
        [Obsolete(APIConstants.ObsoleteSyncMethodWarning)]
        SupplierInvoice Cancel(long? id);
        [Obsolete(APIConstants.ObsoleteSyncMethodWarning)]
        SupplierInvoice Credit(long? id);
        [Obsolete(APIConstants.ObsoleteSyncMethodWarning)]
        SupplierInvoice ApprovalPayment(long? id);
        [Obsolete(APIConstants.ObsoleteSyncMethodWarning)]
        SupplierInvoice ApprovalBookkeep(long? id);

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
}
