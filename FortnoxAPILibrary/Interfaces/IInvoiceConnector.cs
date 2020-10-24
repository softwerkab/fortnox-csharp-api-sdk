using FortnoxAPILibrary.Entities;
using System.Threading.Tasks;

// ReSharper disable UnusedMember.Global
namespace FortnoxAPILibrary.Connectors
{
    /// <remarks/>
    public interface IInvoiceConnector : IEntityConnector
	{
		InvoiceSearch Search { get; set; }

		Sort.Order? SortOrder { get; set; }
		Sort.By.Invoice? SortBy { get; set; }
		Filter.Invoice? FilterBy { get; set; }

		Invoice Update(Invoice invoice);
		Invoice Create(Invoice invoice);
		Invoice Get(long? id);
        EntityCollection<InvoiceSubset> Find();
		Invoice Bookkeep(long? id);
		Invoice Cancel(long? id);
		Invoice CreditInvoice(long? id);
		Invoice Email(long? id);
		Invoice EInvoice(long? id);
        byte[] Print(long? id);
        byte[] PrintReminder(long? id);
		Invoice ExternalPrint(long? id);
		byte[] Preview(long? id);

		Task<Invoice> UpdateAsync(Invoice invoice);
		Task<Invoice> CreateAsync(Invoice invoice);
		Task<Invoice> GetAsync(long? id);
        Task<EntityCollection<InvoiceSubset>> FindAsync();
	}
}
