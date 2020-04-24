using FortnoxAPILibrary;
using FortnoxAPILibrary.Entities;

using System.Threading.Tasks;

// ReSharper disable UnusedMember.Global

namespace FortnoxAPILibrary.Connectors
{
	/// <remarks/>
	public class InvoiceFileConnectionConnector : EntityConnector<InvoiceFileConnection, EntityCollection<InvoiceFileConnectionSubset>, Sort.By.InvoiceFileConnection?>, IInvoiceFileConnectionConnector
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
			return GetAsync(id).Result;
		}

		/// <summary>
		/// Updates a invoiceFileConnection
		/// </summary>
		/// <param name="invoiceFileConnection">The invoiceFileConnection to update</param>
		/// <returns>The updated invoiceFileConnection</returns>
		public InvoiceFileConnection Update(InvoiceFileConnection invoiceFileConnection)
		{
			return UpdateAsync(invoiceFileConnection).Result;
		}

		/// <summary>
		/// Creates a new invoiceFileConnection
		/// </summary>
		/// <param name="invoiceFileConnection">The invoiceFileConnection to create</param>
		/// <returns>The created invoiceFileConnection</returns>
		public InvoiceFileConnection Create(InvoiceFileConnection invoiceFileConnection)
		{
			return CreateAsync(invoiceFileConnection).Result;
		}

		/// <summary>
		/// Deletes a invoiceFileConnection
		/// </summary>
		/// <param name="id">Identifier of the invoiceFileConnection to delete</param>
		public void Delete(string id)
		{
			DeleteAsync(id).Wait();
		}

		/// <summary>
		/// Gets a list of invoiceFileConnections
		/// </summary>
		/// <returns>A list of invoiceFileConnections</returns>
		public EntityCollection<InvoiceFileConnectionSubset> Find()
		{
			return FindAsync().Result;
		}

		public async Task<EntityCollection<InvoiceFileConnectionSubset>> FindAsync()
		{
			return await BaseFind();
		}
		public async Task DeleteAsync(string id)
		{
			await BaseDelete(id);
		}
		public async Task<InvoiceFileConnection> CreateAsync(InvoiceFileConnection invoiceFileConnection)
		{
			return await BaseCreate(invoiceFileConnection);
		}
		public async Task<InvoiceFileConnection> UpdateAsync(InvoiceFileConnection invoiceFileConnection)
		{
			return await BaseUpdate(invoiceFileConnection, invoiceFileConnection.Id);
		}
		public async Task<InvoiceFileConnection> GetAsync(string id)
		{
			return await BaseGet(id);
		}
	}
}
