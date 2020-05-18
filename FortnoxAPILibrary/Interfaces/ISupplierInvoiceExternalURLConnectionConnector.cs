using FortnoxAPILibrary.Entities;
using System.Threading.Tasks;

// ReSharper disable UnusedMember.Global
namespace FortnoxAPILibrary.Connectors
{
    /// <remarks/>
    public interface ISupplierInvoiceExternalURLConnectionConnector : IConnector
	{
		Sort.Order? SortOrder { get; set; }
		Sort.By.SupplierInvoiceExternalURLConnection? SortBy { get; set; }
		Filter.SupplierInvoiceExternalURLConnection? FilterBy { get; set; }


		SupplierInvoiceExternalURLConnection Update(SupplierInvoiceExternalURLConnection supplierInvoiceExternalURLConnection);
		SupplierInvoiceExternalURLConnection Create(SupplierInvoiceExternalURLConnection supplierInvoiceExternalURLConnection);
		SupplierInvoiceExternalURLConnection Get(int? id);
		void Delete(int? id);
		EntityCollection<SupplierInvoiceExternalURLConnection> Find();

		Task<SupplierInvoiceExternalURLConnection> UpdateAsync(SupplierInvoiceExternalURLConnection supplierInvoiceExternalURLConnection);
		Task<SupplierInvoiceExternalURLConnection> CreateAsync(SupplierInvoiceExternalURLConnection supplierInvoiceExternalURLConnection);
		Task<SupplierInvoiceExternalURLConnection> GetAsync(int? id);
		Task DeleteAsync(int? id);
		Task<EntityCollection<SupplierInvoiceExternalURLConnection>> FindAsync();
	}
}
