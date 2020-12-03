using FortnoxAPILibrary.Entities;

using System.Threading.Tasks;

// ReSharper disable UnusedMember.Global

namespace FortnoxAPILibrary.Connectors
{
    /// <remarks/>
    public class SupplierInvoiceExternalURLConnectionConnector : SearchableEntityConnector<SupplierInvoiceExternalURLConnection, SupplierInvoiceExternalURLConnection, SupplierInvoiceExternalURLConnectionSearch>, ISupplierInvoiceExternalURLConnectionConnector
	{


		/// <remarks/>
		public SupplierInvoiceExternalURLConnectionConnector()
		{
			Resource = "supplierinvoiceexternalurlconnections";
		}
		/// <summary>
		/// Find a supplierInvoiceExternalURLConnection based on id
		/// </summary>
		/// <param name="id">Identifier of the supplierInvoiceExternalURLConnection to find</param>
		/// <returns>The found supplierInvoiceExternalURLConnection</returns>
		public SupplierInvoiceExternalURLConnection Get(long? id)
		{
			return GetAsync(id).GetResult();
		}

		/// <summary>
		/// Updates a supplierInvoiceExternalURLConnection
		/// </summary>
		/// <param name="supplierInvoiceExternalURLConnection">The supplierInvoiceExternalURLConnection to update</param>
		/// <returns>The updated supplierInvoiceExternalURLConnection</returns>
		public SupplierInvoiceExternalURLConnection Update(SupplierInvoiceExternalURLConnection supplierInvoiceExternalURLConnection)
		{
			return UpdateAsync(supplierInvoiceExternalURLConnection).GetResult();
		}

		/// <summary>
		/// Creates a new supplierInvoiceExternalURLConnection
		/// </summary>
		/// <param name="supplierInvoiceExternalURLConnection">The supplierInvoiceExternalURLConnection to create</param>
		/// <returns>The created supplierInvoiceExternalURLConnection</returns>
		public SupplierInvoiceExternalURLConnection Create(SupplierInvoiceExternalURLConnection supplierInvoiceExternalURLConnection)
		{
			return CreateAsync(supplierInvoiceExternalURLConnection).GetResult();
		}

		/// <summary>
		/// Deletes a supplierInvoiceExternalURLConnection
		/// </summary>
		/// <param name="id">Identifier of the supplierInvoiceExternalURLConnection to delete</param>
		public void Delete(long? id)
		{
			DeleteAsync(id).GetResult();
		}

		/// <summary>
		/// Gets a list of supplierInvoiceExternalURLConnections
		/// </summary>
		/// <returns>A list of supplierInvoiceExternalURLConnections</returns>
		public EntityCollection<SupplierInvoiceExternalURLConnection> Find(SupplierInvoiceExternalURLConnectionSearch searchSettings)
		{
			return FindAsync(searchSettings).GetResult();
		}

		public async Task<EntityCollection<SupplierInvoiceExternalURLConnection>> FindAsync(SupplierInvoiceExternalURLConnectionSearch searchSettings)
		{
			return await BaseFind(searchSettings).ConfigureAwait(false);
		}
		public async Task DeleteAsync(long? id)
		{
			await BaseDelete(id.ToString()).ConfigureAwait(false);
		}
		public async Task<SupplierInvoiceExternalURLConnection> CreateAsync(SupplierInvoiceExternalURLConnection supplierInvoiceExternalURLConnection)
		{
			return await BaseCreate(supplierInvoiceExternalURLConnection).ConfigureAwait(false);
		}
		public async Task<SupplierInvoiceExternalURLConnection> UpdateAsync(SupplierInvoiceExternalURLConnection supplierInvoiceExternalURLConnection)
		{
			return await BaseUpdate(supplierInvoiceExternalURLConnection, supplierInvoiceExternalURLConnection.Id.ToString()).ConfigureAwait(false);
		}
		public async Task<SupplierInvoiceExternalURLConnection> GetAsync(long? id)
		{
			return await BaseGet(id.ToString()).ConfigureAwait(false);
		}
	}
}
