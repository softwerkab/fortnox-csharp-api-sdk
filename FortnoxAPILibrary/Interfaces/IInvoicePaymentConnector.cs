using FortnoxAPILibrary.Entities;
using System.Threading.Tasks;

// ReSharper disable UnusedMember.Global
namespace FortnoxAPILibrary.Connectors
{
    /// <remarks/>
    public interface IInvoicePaymentConnector : IEntityConnector
	{

		InvoicePayment Update(InvoicePayment invoicePayment);
		InvoicePayment Create(InvoicePayment invoicePayment);
		InvoicePayment Get(long? id);
		void Delete(long? id);
		EntityCollection<InvoicePaymentSubset> Find(InvoicePaymentSearch searchSettings);
        void Bookkeep(long? id);

		Task<InvoicePayment> UpdateAsync(InvoicePayment invoicePayment);
		Task<InvoicePayment> CreateAsync(InvoicePayment invoicePayment);
		Task<InvoicePayment> GetAsync(long? id);
		Task DeleteAsync(long? id);
        Task<EntityCollection<InvoicePaymentSubset>> FindAsync(InvoicePaymentSearch searchSettings);
        Task BookkeepAsync(long? id);

    }
}
