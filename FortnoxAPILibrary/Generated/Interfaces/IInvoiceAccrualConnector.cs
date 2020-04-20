using FortnoxAPILibrary;
using FortnoxAPILibrary.Entities;

// ReSharper disable UnusedMember.Global

namespace FortnoxAPILibrary.Connectors
{
    /// <remarks/>
    public interface IInvoiceAccrualConnector
	{
        [SearchParameter("filter")]
		Filter.InvoiceAccrual? FilterBy { get; set; }

		InvoiceAccrual Update(InvoiceAccrual invoiceAccrual);

		InvoiceAccrual Create(InvoiceAccrual invoiceAccrual);

		InvoiceAccrual Get(int? id);

		void Delete(int? id);

		EntityCollection<InvoiceAccrualSubset> Find();

	}
}
