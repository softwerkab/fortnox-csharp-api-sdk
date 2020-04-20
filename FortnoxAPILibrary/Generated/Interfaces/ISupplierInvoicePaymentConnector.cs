using FortnoxAPILibrary;
using FortnoxAPILibrary.Entities;

// ReSharper disable UnusedMember.Global

namespace FortnoxAPILibrary.Connectors
{
    /// <remarks/>
    public interface ISupplierInvoicePaymentConnector
	{
        [SearchParameter("filter")]
		Filter.SupplierInvoicePayment? FilterBy { get; set; }

        [SearchParameter]
		string InvoiceNumber { get; set; }

		SupplierInvoicePayment Update(SupplierInvoicePayment supplierInvoicePayment);

		SupplierInvoicePayment Create(SupplierInvoicePayment supplierInvoicePayment);

		SupplierInvoicePayment Get(int? id);

		void Delete(int? id);

		EntityCollection<SupplierInvoicePaymentSubset> Find();

	}
}
