using FortnoxAPILibrary.Entities;
using System.Threading.Tasks;

// ReSharper disable UnusedMember.Global
namespace FortnoxAPILibrary.Connectors
{
    /// <remarks/>
    public interface ISupplierInvoiceFileConnectionConnector : IEntityConnector
	{
		SupplierInvoiceFileConnectionSearch Search { get; set; }

        SupplierInvoiceFileConnection Create(SupplierInvoiceFileConnection supplierInvoiceFileConnection);
		SupplierInvoiceFileConnection Get(string id);
		void Delete(string id);
		EntityCollection<SupplierInvoiceFileConnection> Find();

        Task<SupplierInvoiceFileConnection> CreateAsync(SupplierInvoiceFileConnection supplierInvoiceFileConnection);
		Task<SupplierInvoiceFileConnection> GetAsync(string id);
		Task DeleteAsync(string id);
		Task<EntityCollection<SupplierInvoiceFileConnection>> FindAsync();
	}
}
