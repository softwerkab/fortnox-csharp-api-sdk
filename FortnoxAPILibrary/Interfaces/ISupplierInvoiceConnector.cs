using FortnoxAPILibrary.Entities;
using System.Threading.Tasks;

// ReSharper disable UnusedMember.Global
namespace FortnoxAPILibrary.Connectors
{
    /// <remarks/>
    public interface ISupplierInvoiceConnector : IEntityConnector
	{
		SupplierInvoiceSearch Search { get; set; }

		SupplierInvoice Update(SupplierInvoice supplierInvoice);
		SupplierInvoice Create(SupplierInvoice supplierInvoice);
		SupplierInvoice Get(long? id);
        EntityCollection<SupplierInvoiceSubset> Find();
		SupplierInvoice Bookkeep(long? id);
		SupplierInvoice Cancel(long? id);
		SupplierInvoice Credit(long? id);
		SupplierInvoice ApprovalPayment(long? id);
		SupplierInvoice ApprovalBookkeep(long? id);

		Task<SupplierInvoice> UpdateAsync(SupplierInvoice supplierInvoice);
		Task<SupplierInvoice> CreateAsync(SupplierInvoice supplierInvoice);
		Task<SupplierInvoice> GetAsync(long? id);
        Task<EntityCollection<SupplierInvoiceSubset>> FindAsync();
	}
}
