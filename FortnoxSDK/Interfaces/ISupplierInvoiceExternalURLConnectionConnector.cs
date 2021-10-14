using System;
using System.Threading.Tasks;
using Fortnox.SDK.Entities;
using Fortnox.SDK.Search;

// ReSharper disable UnusedMember.Global
namespace Fortnox.SDK.Interfaces
{
    /// <remarks/>
    public interface ISupplierInvoiceExternalURLConnectionConnector : IEntityConnector
	{
        [Obsolete(ApiConstants.ObsoleteSyncMethodWarning)]
		SupplierInvoiceExternalURLConnection Update(SupplierInvoiceExternalURLConnection supplierInvoiceExternalURLConnection);
        [Obsolete(ApiConstants.ObsoleteSyncMethodWarning)]
		SupplierInvoiceExternalURLConnection Create(SupplierInvoiceExternalURLConnection supplierInvoiceExternalURLConnection);
        [Obsolete(ApiConstants.ObsoleteSyncMethodWarning)]
		SupplierInvoiceExternalURLConnection Get(long? id);
        [Obsolete(ApiConstants.ObsoleteSyncMethodWarning)]
		void Delete(long? id);
        [Obsolete(ApiConstants.ObsoleteSyncMethodWarning)]
		EntityCollection<SupplierInvoiceExternalURLConnection> Find(SupplierInvoiceExternalURLConnectionSearch searchSettings);

		Task<SupplierInvoiceExternalURLConnection> UpdateAsync(SupplierInvoiceExternalURLConnection supplierInvoiceExternalURLConnection);
		Task<SupplierInvoiceExternalURLConnection> CreateAsync(SupplierInvoiceExternalURLConnection supplierInvoiceExternalURLConnection);
		Task<SupplierInvoiceExternalURLConnection> GetAsync(long? id);
		Task DeleteAsync(long? id);
		Task<EntityCollection<SupplierInvoiceExternalURLConnection>> FindAsync(SupplierInvoiceExternalURLConnectionSearch searchSettings);
	}
}
