using FortnoxAPILibrary.Entities;
using System.Threading.Tasks;

// ReSharper disable UnusedMember.Global
namespace FortnoxAPILibrary.Connectors
{
    /// <remarks/>
    public interface IInvoiceConnector : IEntityConnector
	{
		Sort.Order? SortOrder { get; set; }
		Sort.By.Invoice? SortBy { get; set; }
		Filter.Invoice? FilterBy { get; set; }

		string Credit { get; set; }
		string CostCenter { get; set; }
		string Currency { get; set; }
		string CustomerName { get; set; }
		string CustomerNumber { get; set; }
		string DocumentNumber { get; set; }
		string ExternalInvoiceReference1 { get; set; }
		string ExternalInvoiceReference2 { get; set; }
		string InvoiceType { get; set; }
		string NotCompleted { get; set; }
		string OCR { get; set; }
		string OurReference { get; set; }
		string Project { get; set; }
		string Sent { get; set; }
		string YourOrderNumber { get; set; }
		string YourReference { get; set; }

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
