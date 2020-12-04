using System.Threading.Tasks;
using Fortnox.SDK.Entities;
using Fortnox.SDK.Search;

// ReSharper disable UnusedMember.Global
namespace Fortnox.SDK.Interfaces
{
    /// <remarks/>
    public interface IInvoiceAccrualConnector : IEntityConnector
	{


		InvoiceAccrual Update(InvoiceAccrual invoiceAccrual);
		InvoiceAccrual Create(InvoiceAccrual invoiceAccrual);
		InvoiceAccrual Get(long? id);
		void Delete(long? id);
		EntityCollection<InvoiceAccrualSubset> Find(InvoiceAccrualSearch searchSettings);

		Task<InvoiceAccrual> UpdateAsync(InvoiceAccrual invoiceAccrual);
		Task<InvoiceAccrual> CreateAsync(InvoiceAccrual invoiceAccrual);
		Task<InvoiceAccrual> GetAsync(long? id);
		Task DeleteAsync(long? id);
		Task<EntityCollection<InvoiceAccrualSubset>> FindAsync(InvoiceAccrualSearch searchSettings);
	}
}
