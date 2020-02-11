using FortnoxAPILibrary;
using FortnoxAPILibrary.Entities;

// ReSharper disable UnusedMember.Global

namespace FortnoxAPILibrary.Connectors
{
    /// <remarks/>
    public class SupplierInvoiceAccrualConnector : EntityConnector<SupplierInvoiceAccrual, EntityCollection<SupplierInvoiceAccrualSubset>, Sort.By.SupplierInvoiceAccrual?>
	{
	    /// <summary>
        /// Use with Find() to limit the search result
        /// </summary>
        [SearchParameter("filter")]
		public Filter.SupplierInvoiceAccrual? FilterBy { get; set; }


		/// <remarks/>
		public SupplierInvoiceAccrualConnector()
		{
			Resource = "supplierinvoiceaccruals";
		}
		/// <summary>
		/// Gets a list of supplierInvoiceAccruals
		/// </summary>
		/// <returns>A list of supplierInvoiceAccruals</returns>
		public EntityCollection<SupplierInvoiceAccrualSubset> Find()
		{
			return BaseFind();
		}
	}
}
