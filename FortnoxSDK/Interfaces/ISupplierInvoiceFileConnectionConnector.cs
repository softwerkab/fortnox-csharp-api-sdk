using System.Threading.Tasks;
using Fortnox.SDK.Entities;
using Fortnox.SDK.Search;

// ReSharper disable UnusedMember.Global
namespace Fortnox.SDK.Interfaces
{
    /// <remarks/>
    public interface ISupplierInvoiceFileConnectionConnector : IEntityConnector
	{

        SupplierInvoiceFileConnection Create(SupplierInvoiceFileConnection supplierInvoiceFileConnection);
		SupplierInvoiceFileConnection Get(string id);
		void Delete(string id);
		EntityCollection<SupplierInvoiceFileConnection> Find(SupplierInvoiceFileConnectionSearch searchSettings);

        Task<SupplierInvoiceFileConnection> CreateAsync(SupplierInvoiceFileConnection supplierInvoiceFileConnection);
		Task<SupplierInvoiceFileConnection> GetAsync(string id);
		Task DeleteAsync(string id);
		Task<EntityCollection<SupplierInvoiceFileConnection>> FindAsync(SupplierInvoiceFileConnectionSearch searchSettings);
	}
}
