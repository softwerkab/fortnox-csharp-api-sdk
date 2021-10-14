using System;
using System.Threading.Tasks;
using Fortnox.SDK.Entities;
using Fortnox.SDK.Search;

// ReSharper disable UnusedMember.Global
namespace Fortnox.SDK.Interfaces
{
    /// <remarks/>
    public interface ISupplierInvoiceAccrualConnector : IEntityConnector
    {
        [Obsolete(APIConstants.ObsoleteSyncMethodWarning)]
        SupplierInvoiceAccrual Update(SupplierInvoiceAccrual supplierInvoiceAccrual);
        [Obsolete(APIConstants.ObsoleteSyncMethodWarning)]
        SupplierInvoiceAccrual Create(SupplierInvoiceAccrual supplierInvoiceAccrual);
        [Obsolete(APIConstants.ObsoleteSyncMethodWarning)]
        SupplierInvoiceAccrual Get(long? id);
        [Obsolete(APIConstants.ObsoleteSyncMethodWarning)]
        void Delete(long? id);
        [Obsolete(APIConstants.ObsoleteSyncMethodWarning)]
        EntityCollection<SupplierInvoiceAccrualSubset> Find(SupplierInvoiceAccrualSearch searchSettings);

        Task<SupplierInvoiceAccrual> UpdateAsync(SupplierInvoiceAccrual supplierInvoiceAccrual);
        Task<SupplierInvoiceAccrual> CreateAsync(SupplierInvoiceAccrual supplierInvoiceAccrual);
        Task<SupplierInvoiceAccrual> GetAsync(long? id);
        Task DeleteAsync(long? id);
        Task<EntityCollection<SupplierInvoiceAccrualSubset>> FindAsync(SupplierInvoiceAccrualSearch searchSettings);
    }
}
