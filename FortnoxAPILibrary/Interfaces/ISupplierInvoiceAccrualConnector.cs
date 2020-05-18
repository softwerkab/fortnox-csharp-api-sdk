using FortnoxAPILibrary.Entities;
using System.Threading.Tasks;

// ReSharper disable UnusedMember.Global
namespace FortnoxAPILibrary.Connectors
{
    /// <remarks/>
    public interface ISupplierInvoiceAccrualConnector : IConnector
	{
		Sort.Order? SortOrder { get; set; }
		Sort.By.SupplierInvoiceAccrual? SortBy { get; set; }
		Filter.SupplierInvoiceAccrual? FilterBy { get; set; }


		SupplierInvoiceAccrual Update(SupplierInvoiceAccrual supplierInvoiceAccrual);
		SupplierInvoiceAccrual Create(SupplierInvoiceAccrual supplierInvoiceAccrual);
		SupplierInvoiceAccrual Get(int? id);
		void Delete(int? id);
		EntityCollection<SupplierInvoiceAccrualSubset> Find();

		Task<SupplierInvoiceAccrual> UpdateAsync(SupplierInvoiceAccrual supplierInvoiceAccrual);
		Task<SupplierInvoiceAccrual> CreateAsync(SupplierInvoiceAccrual supplierInvoiceAccrual);
		Task<SupplierInvoiceAccrual> GetAsync(int? id);
		Task DeleteAsync(int? id);
		Task<EntityCollection<SupplierInvoiceAccrualSubset>> FindAsync();
	}
}
