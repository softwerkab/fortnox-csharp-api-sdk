using FortnoxAPILibrary.Entities;
using System.Threading.Tasks;

// ReSharper disable UnusedMember.Global
namespace FortnoxAPILibrary.Connectors
{
    /// <remarks/>
    public interface ISupplierInvoiceAccrualConnector : IEntityConnector
	{
		SupplierInvoiceAccrualSearch Search { get; set; }


		SupplierInvoiceAccrual Update(SupplierInvoiceAccrual supplierInvoiceAccrual);
		SupplierInvoiceAccrual Create(SupplierInvoiceAccrual supplierInvoiceAccrual);
		SupplierInvoiceAccrual Get(long? id);
		void Delete(long? id);
		EntityCollection<SupplierInvoiceAccrualSubset> Find();

		Task<SupplierInvoiceAccrual> UpdateAsync(SupplierInvoiceAccrual supplierInvoiceAccrual);
		Task<SupplierInvoiceAccrual> CreateAsync(SupplierInvoiceAccrual supplierInvoiceAccrual);
		Task<SupplierInvoiceAccrual> GetAsync(long? id);
		Task DeleteAsync(long? id);
		Task<EntityCollection<SupplierInvoiceAccrualSubset>> FindAsync();
	}
}
