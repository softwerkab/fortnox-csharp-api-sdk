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
		public Filter.InvoiceFileConnection FilterBy { get; set; }


		/// <remarks/>
		public InvoiceFileConnectionConnector()
		{
			Resource = "invoicefileconnections";
		}

		/// <summary>
		/// Find a invoiceFileConnection based on invoiceFileConnectionnumber
		/// </summary>
		/// <param name="invoiceFileConnectionNumber">The invoiceFileConnectionnumber to find</param>
		/// <returns>The found invoiceFileConnection</returns>
		public InvoiceFileConnection Get(string invoiceFileConnectionNumber)
		{
			return BaseGet(invoiceFileConnectionNumber);
		}

		/// <summary>
		/// Updates a invoiceFileConnection
		/// </summary>
		/// <param name="invoiceFileConnection">The invoiceFileConnection to update</param>
		/// <returns>The updated invoiceFileConnection</returns>
		public InvoiceFileConnection Update(InvoiceFileConnection invoiceFileConnection)
		{
			return BaseUpdate(invoiceFileConnection, invoiceFileConnection.InvoiceFileConnectionNumber);
		}

		/// <summary>
		/// Create a new invoiceFileConnection
		/// </summary>
		/// <param name="invoiceFileConnection">The invoiceFileConnection to create</param>
		/// <returns>The created invoiceFileConnection</returns>
		public InvoiceFileConnection Create(InvoiceFileConnection invoiceFileConnection)
		{
			return BaseCreate(invoiceFileConnection);
		}

		/// <summary>
		/// Deletes a invoiceFileConnection
		/// </summary>
		/// <param name="invoiceFileConnectionNumber">The invoiceFileConnectionnumber to delete</param>
		public void Delete(string invoiceFileConnectionNumber)
		{
			BaseDelete(invoiceFileConnectionNumber);
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
