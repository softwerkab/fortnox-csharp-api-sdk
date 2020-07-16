using FortnoxAPILibrary.Entities;
using System.Threading.Tasks;

// ReSharper disable UnusedMember.Global
namespace FortnoxAPILibrary.Connectors
{
    /// <remarks/>
    public interface IInvoiceAccrualConnector : IEntityConnector
	{
		Sort.Order? SortOrder { get; set; }
		Sort.By.InvoiceAccrual? SortBy { get; set; }
		Filter.InvoiceAccrual? FilterBy { get; set; }


		InvoiceAccrual Update(InvoiceAccrual invoiceAccrual);
		InvoiceAccrual Create(InvoiceAccrual invoiceAccrual);
		InvoiceAccrual Get(long? id);
		void Delete(long? id);
		EntityCollection<InvoiceAccrualSubset> Find();

		Task<InvoiceAccrual> UpdateAsync(InvoiceAccrual invoiceAccrual);
		Task<InvoiceAccrual> CreateAsync(InvoiceAccrual invoiceAccrual);
		Task<InvoiceAccrual> GetAsync(long? id);
		Task DeleteAsync(long? id);
		Task<EntityCollection<InvoiceAccrualSubset>> FindAsync();
	}
}
