using FortnoxAPILibrary;
using FortnoxAPILibrary.Entities;

// ReSharper disable UnusedMember.Global

namespace FortnoxAPILibrary.Connectors
{
    /// <remarks/>
    public interface IInvoicePaymentConnector : IConnector
	{
		Sort.Order? SortOrder { get; set; }
		Sort.By.InvoicePayment? SortBy { get; set; }

        [SearchParameter("filter")]
		Filter.InvoicePayment? FilterBy { get; set; }


        [SearchParameter]
		string InvoiceNumber { get; set; }
		InvoicePayment Update(InvoicePayment invoicePayment);

		InvoicePayment Create(InvoicePayment invoicePayment);

		InvoicePayment Get(int? id);

		void Delete(int? id);

		EntityCollection<InvoicePaymentSubset> Find();

	}
}
