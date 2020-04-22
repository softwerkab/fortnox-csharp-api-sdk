using FortnoxAPILibrary;
using FortnoxAPILibrary.Entities;
// ReSharper disable UnusedMember.Global
namespace FortnoxAPILibrary.Connectors
{
    /// <remarks/>
    public interface IInvoiceFileConnectionConnector : IConnector
	{
		Sort.Order? SortOrder { get; set; }
		Sort.By.InvoiceFileConnection? SortBy { get; set; }
		Filter.InvoiceFileConnection? FilterBy { get; set; }


		InvoiceFileConnection Update(InvoiceFileConnection invoiceFileConnection);
		InvoiceFileConnection Create(InvoiceFileConnection invoiceFileConnection);
		InvoiceFileConnection Get(string id);
		void Delete(string id);
		EntityCollection<InvoiceFileConnectionSubset> Find();
	}
}
