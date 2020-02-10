using FortnoxAPILibrary;
using FortnoxAPILibrary.Entities;

// ReSharper disable UnusedMember.Global

namespace FortnoxAPILibrary.Connectors
{
    /// <remarks/>
    public class SupplierInvoiceExternalURLConnectionConnector : EntityConnector<SupplierInvoiceExternalURLConnection, EntityCollection<SupplierInvoiceExternalURLConnectionSubset>, Sort.By.SupplierInvoiceExternalURLConnection?>
	{
	    /// <summary>
        /// Use with Find() to limit the search result
        /// </summary>
        [SearchParameter("filter")]
		public Filter.SupplierInvoiceExternalURLConnection FilterBy { get; set; }


		/// <remarks/>
		public SupplierInvoiceExternalURLConnectionConnector()
		{
			Resource = "supplierinvoiceexternalurlconnections";
		}

		/// <summary>
		/// Find a supplierInvoiceExternalURLConnection based on supplierInvoiceExternalURLConnectionnumber
		/// </summary>
		/// <param name="supplierInvoiceExternalURLConnectionNumber">The supplierInvoiceExternalURLConnectionnumber to find</param>
		/// <returns>The found supplierInvoiceExternalURLConnection</returns>
		public SupplierInvoiceExternalURLConnection Get(string supplierInvoiceExternalURLConnectionNumber)
		{
			return BaseGet(supplierInvoiceExternalURLConnectionNumber);
		}

		/// <summary>
		/// Updates a supplierInvoiceExternalURLConnection
		/// </summary>
		/// <param name="supplierInvoiceExternalURLConnection">The supplierInvoiceExternalURLConnection to update</param>
		/// <returns>The updated supplierInvoiceExternalURLConnection</returns>
		public SupplierInvoiceExternalURLConnection Update(SupplierInvoiceExternalURLConnection supplierInvoiceExternalURLConnection)
		{
			return BaseUpdate(supplierInvoiceExternalURLConnection, supplierInvoiceExternalURLConnection.SupplierInvoiceExternalURLConnectionNumber);
		}

		/// <summary>
		/// Create a new supplierInvoiceExternalURLConnection
		/// </summary>
		/// <param name="supplierInvoiceExternalURLConnection">The supplierInvoiceExternalURLConnection to create</param>
		/// <returns>The created supplierInvoiceExternalURLConnection</returns>
		public SupplierInvoiceExternalURLConnection Create(SupplierInvoiceExternalURLConnection supplierInvoiceExternalURLConnection)
		{
			return BaseCreate(supplierInvoiceExternalURLConnection);
		}

		/// <summary>
		/// Deletes a supplierInvoiceExternalURLConnection
		/// </summary>
		/// <param name="supplierInvoiceExternalURLConnectionNumber">The supplierInvoiceExternalURLConnectionnumber to delete</param>
		public void Delete(string supplierInvoiceExternalURLConnectionNumber)
		{
			BaseDelete(supplierInvoiceExternalURLConnectionNumber);
		}

		/// <summary>
		/// Gets a list of supplierInvoiceExternalURLConnections
		/// </summary>
		/// <returns>A list of supplierInvoiceExternalURLConnections</returns>
		public EntityCollection<SupplierInvoiceExternalURLConnectionSubset> Find()
		{
			return BaseFind();
		}
	}
}
