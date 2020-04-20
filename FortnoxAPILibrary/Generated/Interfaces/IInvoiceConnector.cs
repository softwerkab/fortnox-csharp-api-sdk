using FortnoxAPILibrary;
using FortnoxAPILibrary.Entities;

// ReSharper disable UnusedMember.Global

namespace FortnoxAPILibrary.Connectors
{
    /// <remarks/>
    public interface IInvoiceConnector : IConnector
	{
        [SearchParameter("filter")]
		Filter.Invoice? FilterBy { get; set; }

        [SearchParameter]
		string Credit { get; set; }

        [SearchParameter]
		string CostCenter { get; set; }

        [SearchParameter]
		string Currency { get; set; }

        [SearchParameter]
		string CustomerName { get; set; }

        [SearchParameter]
		string CustomerNumber { get; set; }

        [SearchParameter]
		string DocumentNumber { get; set; }

        [SearchParameter]
		string ExternalInvoiceReference1 { get; set; }

        [SearchParameter]
		string ExternalInvoiceReference2 { get; set; }

        [SearchParameter]
		string InvoiceType { get; set; }

        [SearchParameter]
		string NotCompleted { get; set; }

        [SearchParameter]
		string OCR { get; set; }

        [SearchParameter]
		string OurReference { get; set; }

        [SearchParameter]
		string Project { get; set; }

        [SearchParameter]
		string Sent { get; set; }

        [SearchParameter]
		string YourOrderNumber { get; set; }

        [SearchParameter]
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
		
		Invoice Print(int? id);
		
		Invoice PrintReminder(int? id);
		
		Invoice ExternalPrint(int? id);
		
		Invoice Preview(int? id);
	}
}
