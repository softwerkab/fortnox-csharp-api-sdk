using FortnoxAPILibrary.Entities;
using System.Threading.Tasks;

// ReSharper disable UnusedMember.Global
namespace FortnoxAPILibrary.Connectors
{
    /// <remarks/>
    public interface IInvoiceAccrualConnector : IEntityConnector
	{
		InvoiceAccrualSearch Search { get; set; }


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
