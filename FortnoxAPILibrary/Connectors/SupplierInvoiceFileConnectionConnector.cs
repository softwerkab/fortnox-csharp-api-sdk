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
        [SearchParameter]
		public string SupplierInvoiceNumber { get; set; }

		/// <remarks/>
		public SupplierInvoiceFileConnectionConnector()
		{
			Resource = "supplierinvoicefileconnections";
		}

		/// <summary>
		/// Get a supplier invoice file connection based on fileId
		/// </summary>
		/// <param name="fileId">The id of the file to find.</param>
		/// <returns>The found supplier invoice file connection</returns>
		public SupplierInvoiceFileConnection Get(string fileId)
		{
			return BaseGet(fileId);
		}

		/// <summary>
		/// Creates a new connection between a file and a supplier invoice.
		/// </summary>
		/// <param name="supplierInvoiceFileConnection">The supplier invoice file connection to create</param>
		/// <returns>The created supplier invoice file connection</returns>
		public SupplierInvoiceFileConnection Create(SupplierInvoiceFileConnection supplierInvoiceFileConnection)
		{
			return BaseCreate(supplierInvoiceFileConnection);
		}

		/// <summary>
		/// Deletes a connected file from a supplier invoice
		/// </summary>
		/// <param name="fileId">The id of the file to delete</param>
		public void Delete(string fileId)
		{
			BaseDelete(fileId);
		}

		/// <summary>
		/// Gets a list of supplier invoice file Connections
		/// </summary>
		/// <returns></returns>
		public EntityCollection<SupplierInvoiceFileConnectionSubset> Find()
		{
			return BaseFind();
		}
	}
}
