using FortnoxAPILibrary.Entities;
using System.Threading.Tasks;

// ReSharper disable UnusedMember.Global
namespace FortnoxAPILibrary.Connectors
{
    /// <remarks/>
    public interface ISupplierInvoiceFileConnectionConnector : IConnector
	{
		Sort.Order? SortOrder { get; set; }
		Sort.By.SupplierInvoiceFileConnection? SortBy { get; set; }
		Filter.SupplierInvoiceFileConnection? FilterBy { get; set; }

		string SupplierInvoiceNumber { get; set; }

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
