using FortnoxAPILibrary;
using FortnoxAPILibrary.Entities;
using System.Threading.Tasks;

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

		Task<InvoiceFileConnection> UpdateAsync(InvoiceFileConnection invoiceFileConnection);
		Task<InvoiceFileConnection> CreateAsync(InvoiceFileConnection invoiceFileConnection);
		Task<InvoiceFileConnection> GetAsync(string id);
		Task DeleteAsync(string id);
		Task<EntityCollection<InvoiceFileConnectionSubset>> FindAsync();
	}
}
