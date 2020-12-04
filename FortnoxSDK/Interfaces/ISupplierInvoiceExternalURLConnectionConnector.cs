using System.Threading.Tasks;
using Fortnox.SDK.Entities;
using Fortnox.SDK.Search;

// ReSharper disable UnusedMember.Global
namespace Fortnox.SDK.Interfaces
{
    /// <remarks/>
    public interface ISupplierInvoiceExternalURLConnectionConnector : IEntityConnector
	{


		SupplierInvoiceExternalURLConnection Update(SupplierInvoiceExternalURLConnection supplierInvoiceExternalURLConnection);
		SupplierInvoiceExternalURLConnection Create(SupplierInvoiceExternalURLConnection supplierInvoiceExternalURLConnection);
		SupplierInvoiceExternalURLConnection Get(long? id);
		void Delete(long? id);
		EntityCollection<SupplierInvoiceExternalURLConnection> Find(SupplierInvoiceExternalURLConnectionSearch searchSettings);

		Task<SupplierInvoiceExternalURLConnection> UpdateAsync(SupplierInvoiceExternalURLConnection supplierInvoiceExternalURLConnection);
		Task<SupplierInvoiceExternalURLConnection> CreateAsync(SupplierInvoiceExternalURLConnection supplierInvoiceExternalURLConnection);
		Task<SupplierInvoiceExternalURLConnection> GetAsync(long? id);
		Task DeleteAsync(long? id);
		Task<EntityCollection<SupplierInvoiceExternalURLConnection>> FindAsync(SupplierInvoiceExternalURLConnectionSearch searchSettings);
	}
}
