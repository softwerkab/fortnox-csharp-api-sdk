using FortnoxAPILibrary.Entities;
using System.Threading.Tasks;

// ReSharper disable UnusedMember.Global
namespace FortnoxAPILibrary.Connectors
{
    /// <remarks/>
    public interface ISupplierInvoicePaymentConnector : IConnector
	{
		Sort.Order? SortOrder { get; set; }
		Sort.By.SupplierInvoicePayment? SortBy { get; set; }
		Filter.SupplierInvoicePayment? FilterBy { get; set; }

		string InvoiceNumber { get; set; }

		SupplierInvoicePayment Update(SupplierInvoicePayment supplierInvoicePayment);
		SupplierInvoicePayment Create(SupplierInvoicePayment supplierInvoicePayment);
		SupplierInvoicePayment Get(int? id);
		void Delete(int? id);
		EntityCollection<SupplierInvoicePaymentSubset> Find();

		Task<SupplierInvoicePayment> UpdateAsync(SupplierInvoicePayment supplierInvoicePayment);
		Task<SupplierInvoicePayment> CreateAsync(SupplierInvoicePayment supplierInvoicePayment);
		Task<SupplierInvoicePayment> GetAsync(int? id);
		Task DeleteAsync(int? id);
		Task<EntityCollection<SupplierInvoicePaymentSubset>> FindAsync();
	}
}
