using FortnoxAPILibrary;
using FortnoxAPILibrary.Entities;

// ReSharper disable UnusedMember.Global

namespace FortnoxAPILibrary.Connectors
{
    /// <remarks/>
    public interface ISupplierInvoiceAccrualConnector : IConnector
	{
		Sort.Order? SortOrder { get; set; }
		Sort.By.SupplierInvoiceAccrual? SortBy { get; set; }

        [SearchParameter("filter")]
		Filter.SupplierInvoiceAccrual? FilterBy { get; set; }

		SupplierInvoiceAccrual Update(SupplierInvoiceAccrual supplierInvoiceAccrual);

		SupplierInvoiceAccrual Create(SupplierInvoiceAccrual supplierInvoiceAccrual);

		SupplierInvoiceAccrual Get(int? id);

		void Delete(int? id);

		EntityCollection<SupplierInvoiceAccrualSubset> Find();

	}
}
