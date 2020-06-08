using FortnoxAPILibrary.Entities;
using System.Threading.Tasks;

// ReSharper disable UnusedMember.Global
namespace FortnoxAPILibrary.Connectors
{
    /// <remarks/>
    public interface IInvoiceConnector : IConnector
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
		Invoice Get(int? id);
        EntityCollection<InvoiceSubset> Find();
		Invoice Bookkeep(int? id);
		Invoice Cancel(int? id);
		Invoice CreditInvoice(int? id);
		Invoice Email(int? id);
		Invoice EInvoice(int? id);
        byte[] Print(int? id);
        byte[] PrintReminder(int? id);
		Invoice ExternalPrint(int? id);
		byte[] Preview(int? id);

		Task<Invoice> UpdateAsync(Invoice invoice);
		Task<Invoice> CreateAsync(Invoice invoice);
		Task<Invoice> GetAsync(int? id);
        Task<EntityCollection<InvoiceSubset>> FindAsync();
	}
}
