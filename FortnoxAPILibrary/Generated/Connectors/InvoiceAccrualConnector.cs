using FortnoxAPILibrary;
using FortnoxAPILibrary.Entities;

// ReSharper disable UnusedMember.Global

namespace FortnoxAPILibrary.Connectors
{
    /// <remarks/>
    public class InvoiceAccrualConnector : EntityConnector<InvoiceAccrual, EntityCollection<InvoiceAccrualSubset>, Sort.By.InvoiceAccrual?>
	{
	    /// <summary>
        /// Use with Find() to limit the search result
        /// </summary>
        [SearchParameter("filter")]
		public Filter.InvoiceAccrual? FilterBy { get; set; }


		/// <remarks/>
		public InvoiceAccrualConnector()
		{
			Resource = "invoiceaccruals";
		}
		/// <summary>
		/// Gets a list of invoiceAccruals
		/// </summary>
		/// <returns>A list of invoiceAccruals</returns>
		public EntityCollection<InvoiceAccrualSubset> Find()
		{
			return BaseFind();
		}
	}
}
