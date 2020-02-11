using FortnoxAPILibrary;
using FortnoxAPILibrary.Entities;

// ReSharper disable UnusedMember.Global

namespace FortnoxAPILibrary.Connectors
{
    /// <remarks/>
    public class SupplierInvoiceFileConnectionConnector : EntityConnector<SupplierInvoiceFileConnection, EntityCollection<SupplierInvoiceFileConnectionSubset>, Sort.By.SupplierInvoiceFileConnection?>
	{
	    /// <summary>
        /// Use with Find() to limit the search result
        /// </summary>
        [SearchParameter("filter")]
		public Filter.SupplierInvoiceFileConnection? FilterBy { get; set; }


        /// <summary>
        /// Use with Find() to limit the search result
        /// </summary>
        [SearchParameter]
		public string SupplierInvoiceNumber { get; set; }

		/// <remarks/>
		public SupplierInvoiceFileConnectionConnector()
		{
			Resource = "supplierinvoicefileconnections";
		}
		/// <summary>
		/// Gets a list of supplierInvoiceFileConnections
		/// </summary>
		/// <returns>A list of supplierInvoiceFileConnections</returns>
		public EntityCollection<SupplierInvoiceFileConnectionSubset> Find()
		{
			return BaseFind();
		}
	}
}
