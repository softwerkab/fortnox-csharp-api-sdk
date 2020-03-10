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
		/// Find a invoiceFileConnection based on id
		/// </summary>
		/// <param name="id">Identifier of the invoiceFileConnection to find</param>
		/// <returns>The found invoiceFileConnection</returns>
		public InvoiceFileConnection Get(string id)
		{
			return BaseGet(id);
		}

		/// <summary>
		/// Updates a invoiceFileConnection
		/// </summary>
		/// <param name="invoiceFileConnection">The invoiceFileConnection to update</param>
		/// <returns>The updated invoiceFileConnection</returns>
		public InvoiceFileConnection Update(InvoiceFileConnection invoiceFileConnection)
		{
			return BaseUpdate(invoiceFileConnection, invoiceFileConnection.Id);
		}

		/// <summary>
		/// Creates a new invoiceFileConnection
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
		/// <param name="id">Identifier of the invoiceFileConnection to delete</param>
		public void Delete(string id)
		{
			BaseDelete(id);
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
