using FortnoxAPILibrary;
using FortnoxAPILibrary.Entities;

// ReSharper disable UnusedMember.Global

namespace FortnoxAPILibrary.Connectors
{
    /// <remarks/>
    public interface ISupplierInvoiceExternalURLConnectionConnector : IConnector
	{
		Sort.Order? SortOrder { get; set; }
		Sort.By.SupplierInvoiceExternalURLConnection? SortBy { get; set; }

        [SearchParameter("filter")]
		Filter.SupplierInvoiceExternalURLConnection? FilterBy { get; set; }

		SupplierInvoiceExternalURLConnection Update(SupplierInvoiceExternalURLConnection supplierInvoiceExternalURLConnection);

		SupplierInvoiceExternalURLConnection Create(SupplierInvoiceExternalURLConnection supplierInvoiceExternalURLConnection);

		SupplierInvoiceExternalURLConnection Get(int? id);

		void Delete(int? id);

		EntityCollection<SupplierInvoiceExternalURLConnection> Find();

	}
}
