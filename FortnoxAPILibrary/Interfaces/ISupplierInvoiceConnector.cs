using FortnoxAPILibrary.Entities;
using System.Threading.Tasks;

// ReSharper disable UnusedMember.Global
namespace FortnoxAPILibrary.Connectors
{
    /// <remarks/>
    public interface ISupplierInvoiceConnector : IConnector
	{
		Sort.Order? SortOrder { get; set; }
		Sort.By.SupplierInvoice? SortBy { get; set; }
		Filter.SupplierInvoice? FilterBy { get; set; }

		string CostCenter { get; set; }
		string OCR { get; set; }
		string Project { get; set; }
		string SupplierNumber { get; set; }

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
