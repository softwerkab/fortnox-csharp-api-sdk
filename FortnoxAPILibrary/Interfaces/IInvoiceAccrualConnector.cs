using FortnoxAPILibrary.Entities;
using System.Threading.Tasks;

// ReSharper disable UnusedMember.Global
namespace FortnoxAPILibrary.Connectors
{
    /// <remarks/>
    public interface IInvoiceAccrualConnector : IConnector
	{
		Sort.Order? SortOrder { get; set; }
		Sort.By.InvoiceAccrual? SortBy { get; set; }
		Filter.InvoiceAccrual? FilterBy { get; set; }


		InvoiceAccrual Update(InvoiceAccrual invoiceAccrual);
		InvoiceAccrual Create(InvoiceAccrual invoiceAccrual);
		InvoiceAccrual Get(int? id);
		void Delete(int? id);
		EntityCollection<InvoiceAccrualSubset> Find();

		Task<InvoiceAccrual> UpdateAsync(InvoiceAccrual invoiceAccrual);
		Task<InvoiceAccrual> CreateAsync(InvoiceAccrual invoiceAccrual);
		Task<InvoiceAccrual> GetAsync(int? id);
		Task DeleteAsync(int? id);
		Task<EntityCollection<InvoiceAccrualSubset>> FindAsync();
	}
}
