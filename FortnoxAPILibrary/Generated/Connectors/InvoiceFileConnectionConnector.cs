using FortnoxAPILibrary;
using FortnoxAPILibrary.Entities;

// ReSharper disable UnusedMember.Global

namespace FortnoxAPILibrary.Connectors
{
    /// <remarks/>
    public class InvoiceFileConnectionConnector : EntityConnector<InvoiceFileConnection, EntityCollection<InvoiceFileConnectionSubset>, Sort.By.InvoiceFileConnection?>
	{
	    /// <summary>
        /// Use with Find() to limit the search result
        /// </summary>
        [SearchParameter("filter")]
		public Filter.InvoiceFileConnection? FilterBy { get; set; }


		/// <remarks/>
		public InvoiceFileConnectionConnector()
		{
			Resource = "invoicefileconnections";
		}
		/// <summary>
		/// Gets a list of invoiceFileConnections
		/// </summary>
		/// <returns>A list of invoiceFileConnections</returns>
		public EntityCollection<InvoiceFileConnectionSubset> Find()
		{
			return BaseFind();
		}
	}
}
