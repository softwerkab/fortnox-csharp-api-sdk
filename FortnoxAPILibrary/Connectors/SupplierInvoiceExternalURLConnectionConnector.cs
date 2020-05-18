using FortnoxAPILibrary.Entities;

using System.Threading.Tasks;

// ReSharper disable UnusedMember.Global

namespace FortnoxAPILibrary.Connectors
{
    /// <remarks/>
    public class SupplierInvoiceExternalURLConnectionConnector : EntityConnector<SupplierInvoiceExternalURLConnection, EntityCollection<SupplierInvoiceExternalURLConnection>, Sort.By.SupplierInvoiceExternalURLConnection?>, ISupplierInvoiceExternalURLConnectionConnector
	{
	    /// <summary>
        /// Use with Find() to limit the search result
        /// </summary>
        [SearchParameter("filter")]
		public Filter.SupplierInvoiceExternalURLConnection? FilterBy { get; set; }


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
		public SupplierInvoiceExternalURLConnection Get(int? id)
		{
			return GetAsync(id).Result;
		}

		/// <summary>
		/// Updates a supplierInvoiceExternalURLConnection
		/// </summary>
		/// <param name="supplierInvoiceExternalURLConnection">The supplierInvoiceExternalURLConnection to update</param>
		/// <returns>The updated supplierInvoiceExternalURLConnection</returns>
		public SupplierInvoiceExternalURLConnection Update(SupplierInvoiceExternalURLConnection supplierInvoiceExternalURLConnection)
		{
			return UpdateAsync(supplierInvoiceExternalURLConnection).Result;
		}

		/// <summary>
		/// Creates a new supplierInvoiceExternalURLConnection
		/// </summary>
		/// <param name="supplierInvoiceExternalURLConnection">The supplierInvoiceExternalURLConnection to create</param>
		/// <returns>The created supplierInvoiceExternalURLConnection</returns>
		public SupplierInvoiceExternalURLConnection Create(SupplierInvoiceExternalURLConnection supplierInvoiceExternalURLConnection)
		{
			return CreateAsync(supplierInvoiceExternalURLConnection).Result;
		}

		/// <summary>
		/// Deletes a supplierInvoiceExternalURLConnection
		/// </summary>
		/// <param name="id">Identifier of the supplierInvoiceExternalURLConnection to delete</param>
		public void Delete(int? id)
		{
			DeleteAsync(id).Wait();
		}

		/// <summary>
		/// Gets a list of supplierInvoiceExternalURLConnections
		/// </summary>
		/// <returns>A list of supplierInvoiceExternalURLConnections</returns>
		public EntityCollection<SupplierInvoiceExternalURLConnection> Find()
		{
			return FindAsync().Result;
		}

		public async Task<EntityCollection<SupplierInvoiceExternalURLConnection>> FindAsync()
		{
			return await BaseFind();
		}
		public async Task DeleteAsync(int? id)
		{
			await BaseDelete(id.ToString());
		}
		public async Task<SupplierInvoiceExternalURLConnection> CreateAsync(SupplierInvoiceExternalURLConnection supplierInvoiceExternalURLConnection)
		{
			return await BaseCreate(supplierInvoiceExternalURLConnection);
		}
		public async Task<SupplierInvoiceExternalURLConnection> UpdateAsync(SupplierInvoiceExternalURLConnection supplierInvoiceExternalURLConnection)
		{
			return await BaseUpdate(supplierInvoiceExternalURLConnection, supplierInvoiceExternalURLConnection.Id.ToString());
		}
		public async Task<SupplierInvoiceExternalURLConnection> GetAsync(int? id)
		{
			return await BaseGet(id.ToString());
		}
	}
}
