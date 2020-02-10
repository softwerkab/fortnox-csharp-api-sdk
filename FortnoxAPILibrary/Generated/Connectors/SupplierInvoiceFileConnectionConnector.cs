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
		public Filter.SupplierInvoiceFileConnection FilterBy { get; set; }


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
		/// Find a supplierInvoiceFileConnection based on supplierInvoiceFileConnectionnumber
		/// </summary>
		/// <param name="supplierInvoiceFileConnectionNumber">The supplierInvoiceFileConnectionnumber to find</param>
		/// <returns>The found supplierInvoiceFileConnection</returns>
		public SupplierInvoiceFileConnection Get(string supplierInvoiceFileConnectionNumber)
		{
			return BaseGet(supplierInvoiceFileConnectionNumber);
		}

		/// <summary>
		/// Updates a supplierInvoiceFileConnection
		/// </summary>
		/// <param name="supplierInvoiceFileConnection">The supplierInvoiceFileConnection to update</param>
		/// <returns>The updated supplierInvoiceFileConnection</returns>
		public SupplierInvoiceFileConnection Update(SupplierInvoiceFileConnection supplierInvoiceFileConnection)
		{
			return BaseUpdate(supplierInvoiceFileConnection, supplierInvoiceFileConnection.SupplierInvoiceFileConnectionNumber);
		}

		/// <summary>
		/// Create a new supplierInvoiceFileConnection
		/// </summary>
		/// <param name="supplierInvoiceFileConnection">The supplierInvoiceFileConnection to create</param>
		/// <returns>The created supplierInvoiceFileConnection</returns>
		public SupplierInvoiceFileConnection Create(SupplierInvoiceFileConnection supplierInvoiceFileConnection)
		{
			return BaseCreate(supplierInvoiceFileConnection);
		}

		/// <summary>
		/// Deletes a supplierInvoiceFileConnection
		/// </summary>
		/// <param name="supplierInvoiceFileConnectionNumber">The supplierInvoiceFileConnectionnumber to delete</param>
		public void Delete(string supplierInvoiceFileConnectionNumber)
		{
			BaseDelete(supplierInvoiceFileConnectionNumber);
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
