using System.Threading.Tasks;
using Fortnox.SDK.Entities;
using Fortnox.SDK.Search;

// ReSharper disable UnusedMember.Global
namespace Fortnox.SDK.Interfaces
{
    /// <remarks/>
    public interface ISupplierInvoicePaymentConnector : IEntityConnector
	{

		SupplierInvoicePayment Update(SupplierInvoicePayment supplierInvoicePayment);
		SupplierInvoicePayment Create(SupplierInvoicePayment supplierInvoicePayment);
		SupplierInvoicePayment Get(long? id);
		void Delete(long? id);
		EntityCollection<SupplierInvoicePaymentSubset> Find(SupplierInvoicePaymentSearch searchSettings);
        public void Bookkeep(long? id);

        Task<SupplierInvoicePayment> UpdateAsync(SupplierInvoicePayment supplierInvoicePayment);
		Task<SupplierInvoicePayment> CreateAsync(SupplierInvoicePayment supplierInvoicePayment);
		Task<SupplierInvoicePayment> GetAsync(long? id);
		Task DeleteAsync(long? id);
		Task<EntityCollection<SupplierInvoicePaymentSubset>> FindAsync(SupplierInvoicePaymentSearch searchSettings);
        public Task BookkeepAsync(long? id);
	}
}
