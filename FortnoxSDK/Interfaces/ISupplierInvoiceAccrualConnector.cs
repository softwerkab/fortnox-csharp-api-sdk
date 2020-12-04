using System.Threading.Tasks;
using Fortnox.SDK.Entities;
using Fortnox.SDK.Search;

// ReSharper disable UnusedMember.Global
namespace Fortnox.SDK.Interfaces
{
    /// <remarks/>
    public interface ISupplierInvoiceAccrualConnector : IEntityConnector
	{


		SupplierInvoiceAccrual Update(SupplierInvoiceAccrual supplierInvoiceAccrual);
		SupplierInvoiceAccrual Create(SupplierInvoiceAccrual supplierInvoiceAccrual);
		SupplierInvoiceAccrual Get(long? id);
		void Delete(long? id);
		EntityCollection<SupplierInvoiceAccrualSubset> Find(SupplierInvoiceAccrualSearch searchSettings);

		Task<SupplierInvoiceAccrual> UpdateAsync(SupplierInvoiceAccrual supplierInvoiceAccrual);
		Task<SupplierInvoiceAccrual> CreateAsync(SupplierInvoiceAccrual supplierInvoiceAccrual);
		Task<SupplierInvoiceAccrual> GetAsync(long? id);
		Task DeleteAsync(long? id);
		Task<EntityCollection<SupplierInvoiceAccrualSubset>> FindAsync(SupplierInvoiceAccrualSearch searchSettings);
	}
}
