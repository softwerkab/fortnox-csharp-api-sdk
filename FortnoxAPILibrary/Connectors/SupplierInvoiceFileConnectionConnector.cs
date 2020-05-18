using FortnoxAPILibrary.Entities;

using System.Threading.Tasks;

// ReSharper disable UnusedMember.Global

namespace FortnoxAPILibrary.Connectors
{
	/// <remarks/>
	public class SupplierInvoiceFileConnectionConnector : EntityConnector<SupplierInvoiceFileConnection, EntityCollection<SupplierInvoiceFileConnection>, Sort.By.SupplierInvoiceFileConnection?>, ISupplierInvoiceFileConnectionConnector
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
			return GetAsync(id).Result;
		}

		/// <summary>
		/// Creates a new supplierInvoiceFileConnection
		/// </summary>
		/// <param name="supplierInvoiceFileConnection">The supplierInvoiceFileConnection to create</param>
		/// <returns>The created supplierInvoiceFileConnection</returns>
		public SupplierInvoiceFileConnection Create(SupplierInvoiceFileConnection supplierInvoiceFileConnection)
		{
			return CreateAsync(supplierInvoiceFileConnection).Result;
		}

		/// <summary>
		/// Deletes a supplierInvoiceFileConnection
		/// </summary>
		/// <param name="id">Identifier of the supplierInvoiceFileConnection to delete</param>
		public void Delete(string id)
		{
			DeleteAsync(id).Wait();
		}

		/// <summary>
		/// Gets a list of supplierInvoiceFileConnections
		/// </summary>
		/// <returns>A list of supplierInvoiceFileConnections</returns>
		public EntityCollection<SupplierInvoiceFileConnection> Find()
		{
			return FindAsync().Result;
		}

		public async Task<EntityCollection<SupplierInvoiceFileConnection>> FindAsync()
		{
			return await BaseFind();
		}
		public async Task DeleteAsync(string id)
		{
			await BaseDelete(id);
		}
		public async Task<SupplierInvoiceFileConnection> CreateAsync(SupplierInvoiceFileConnection supplierInvoiceFileConnection)
		{
			return await BaseCreate(supplierInvoiceFileConnection);
		}
		public async Task<SupplierInvoiceFileConnection> GetAsync(string id)
		{
			return await BaseGet(id);
		}
	}
}
