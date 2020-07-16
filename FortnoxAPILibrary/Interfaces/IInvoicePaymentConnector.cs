using FortnoxAPILibrary.Entities;
using System.Threading.Tasks;

// ReSharper disable UnusedMember.Global
namespace FortnoxAPILibrary.Connectors
{
    /// <remarks/>
    public interface IInvoicePaymentConnector : IEntityConnector
	{
		Sort.Order? SortOrder { get; set; }
		Sort.By.InvoicePayment? SortBy { get; set; }
		Filter.InvoicePayment? FilterBy { get; set; }

		string InvoiceNumber { get; set; }

		InvoicePayment Update(InvoicePayment invoicePayment);
		InvoicePayment Create(InvoicePayment invoicePayment);
		InvoicePayment Get(long? id);
		void Delete(long? id);
		EntityCollection<InvoicePaymentSubset> Find();

		Task<InvoicePayment> UpdateAsync(InvoicePayment invoicePayment);
		Task<InvoicePayment> CreateAsync(InvoicePayment invoicePayment);
		Task<InvoicePayment> GetAsync(long? id);
		Task DeleteAsync(long? id);
		Task<EntityCollection<InvoicePaymentSubset>> FindAsync();
	}
}
