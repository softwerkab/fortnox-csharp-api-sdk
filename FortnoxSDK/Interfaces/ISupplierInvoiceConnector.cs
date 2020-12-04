using System.Threading.Tasks;
using Fortnox.SDK.Entities;
using Fortnox.SDK.Search;

// ReSharper disable UnusedMember.Global
namespace Fortnox.SDK.Interfaces
{
    /// <remarks/>
    public interface ISupplierInvoiceConnector : IEntityConnector
	{

		SupplierInvoice Update(SupplierInvoice supplierInvoice);
		SupplierInvoice Create(SupplierInvoice supplierInvoice);
		SupplierInvoice Get(long? id);
        EntityCollection<SupplierInvoiceSubset> Find(SupplierInvoiceSearch searchSettings);
		SupplierInvoice Bookkeep(long? id);
		SupplierInvoice Cancel(long? id);
		SupplierInvoice Credit(long? id);
		SupplierInvoice ApprovalPayment(long? id);
		SupplierInvoice ApprovalBookkeep(long? id);

		Task<SupplierInvoice> UpdateAsync(SupplierInvoice supplierInvoice);
		Task<SupplierInvoice> CreateAsync(SupplierInvoice supplierInvoice);
		Task<SupplierInvoice> GetAsync(long? id);
        Task<EntityCollection<SupplierInvoiceSubset>> FindAsync(SupplierInvoiceSearch searchSettings);
        Task<SupplierInvoice> BookkeepAsync(long? id);
        Task<SupplierInvoice> CancelAsync(long? id);
        Task<SupplierInvoice> CreditAsync(long? id);
        Task<SupplierInvoice> ApprovalPaymentAsync(long? id);
        Task<SupplierInvoice> ApprovalBookkeepAsync(long? id);
	}
}
