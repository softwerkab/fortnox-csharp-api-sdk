using FortnoxAPILibrary;
using FortnoxAPILibrary.Entities;

// ReSharper disable UnusedMember.Global

namespace FortnoxAPILibrary.Connectors
{
	/// <remarks/>
	public class SupplierInvoiceFileConnectionConnector : EntityConnector<SupplierInvoiceFileConnection, EntityCollection<SupplierInvoiceFileConnection>, Sort.By.SupplierInvoiceFileConnection?>
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
		/// Find a supplierInvoiceFileConnection based on id
		/// </summary>
		/// <param name="id">Identifier of the supplierInvoiceFileConnection to find</param>
		/// <returns>The found supplierInvoiceFileConnection</returns>
		public SupplierInvoiceFileConnection Get(string id)
		{
			return BaseGet(id.ToString());
		}

		/// <summary>
		/// Creates a new supplierInvoiceFileConnection
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
		/// <param name="id">Identifier of the supplierInvoiceFileConnection to delete</param>
		public void Delete(string id)
		{
			BaseDelete(id.ToString());
		}

		/// <summary>
		/// Gets a list of supplierInvoiceFileConnections
		/// </summary>
		/// <returns>A list of supplierInvoiceFileConnections</returns>
		public EntityCollection<SupplierInvoiceFileConnection> Find()
		{
			return BaseFind();
		}
	}
}
