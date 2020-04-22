using FortnoxAPILibrary;
using FortnoxAPILibrary.Entities;

// ReSharper disable UnusedMember.Global

namespace FortnoxAPILibrary.Connectors
{
    /// <remarks/>
    public interface ISupplierInvoiceConnector : IConnector
	{
		Sort.Order? SortOrder { get; set; }
		Sort.By.SupplierInvoice? SortBy { get; set; }

        [SearchParameter("filter")]
		Filter.SupplierInvoice? FilterBy { get; set; }

        [SearchParameter]
		string CostCenter { get; set; }

        [SearchParameter]
		string OCR { get; set; }

        [SearchParameter]
		string Project { get; set; }

        [SearchParameter]
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
	}
}
