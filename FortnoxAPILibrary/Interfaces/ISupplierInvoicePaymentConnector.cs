using FortnoxAPILibrary.Entities;
using System.Threading.Tasks;

// ReSharper disable UnusedMember.Global
namespace FortnoxAPILibrary.Connectors
{
    /// <remarks/>
    public interface ISupplierInvoicePaymentConnector : IEntityConnector
	{
		Sort.Order? SortOrder { get; set; }
		Sort.By.SupplierInvoicePayment? SortBy { get; set; }
		Filter.SupplierInvoicePayment? FilterBy { get; set; }

		string InvoiceNumber { get; set; }

		SupplierInvoicePayment Update(SupplierInvoicePayment supplierInvoicePayment);
		SupplierInvoicePayment Create(SupplierInvoicePayment supplierInvoicePayment);
		SupplierInvoicePayment Get(long? id);
		void Delete(long? id);
		EntityCollection<SupplierInvoicePaymentSubset> Find();

		Task<SupplierInvoicePayment> UpdateAsync(SupplierInvoicePayment supplierInvoicePayment);
		Task<SupplierInvoicePayment> CreateAsync(SupplierInvoicePayment supplierInvoicePayment);
		Task<SupplierInvoicePayment> GetAsync(long? id);
		Task DeleteAsync(long? id);
		Task<EntityCollection<SupplierInvoicePaymentSubset>> FindAsync();
	}
}
