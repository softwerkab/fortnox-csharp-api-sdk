using FortnoxAPILibrary.Entities;

using System.Threading.Tasks;

// ReSharper disable UnusedMember.Global

namespace FortnoxAPILibrary.Connectors
{
	/// <remarks/>
	public class SupplierInvoiceAccrualConnector : EntityConnector<SupplierInvoiceAccrual, EntityCollection<SupplierInvoiceAccrualSubset>, Sort.By.SupplierInvoiceAccrual?>, ISupplierInvoiceAccrualConnector
	{
		/// <summary>
		/// Use with Find() to limit the search result
		/// </summary>
		[SearchParameter("filter")]
		public Filter.SupplierInvoiceAccrual? FilterBy { get; set; }


		/// <remarks/>
		public SupplierInvoiceAccrualConnector()
		{
			Resource = "supplierinvoiceaccruals";
		}

		/// <summary>
		/// Find a supplierInvoiceAccrual based on id
		/// </summary>
		/// <param name="id">Identifier of the supplierInvoiceAccrual to find</param>
		/// <returns>The found supplierInvoiceAccrual</returns>
		public SupplierInvoiceAccrual Get(int? id)
		{
			return GetAsync(id).Result;
		}

		/// <summary>
		/// Updates a supplierInvoiceAccrual
		/// </summary>
		/// <param name="supplierInvoiceAccrual">The supplierInvoiceAccrual to update</param>
		/// <returns>The updated supplierInvoiceAccrual</returns>
		public SupplierInvoiceAccrual Update(SupplierInvoiceAccrual supplierInvoiceAccrual)
		{
			return UpdateAsync(supplierInvoiceAccrual).Result;
		}

		/// <summary>
		/// Creates a new supplierInvoiceAccrual
		/// </summary>
		/// <param name="supplierInvoiceAccrual">The supplierInvoiceAccrual to create</param>
		/// <returns>The created supplierInvoiceAccrual</returns>
		public SupplierInvoiceAccrual Create(SupplierInvoiceAccrual supplierInvoiceAccrual)
		{
			return CreateAsync(supplierInvoiceAccrual).Result;
		}

		/// <summary>
		/// Deletes a supplierInvoiceAccrual
		/// </summary>
		/// <param name="id">Identifier of the supplierInvoiceAccrual to delete</param>
		public void Delete(int? id)
		{
			DeleteAsync(id).Wait();
		}

		/// <summary>
		/// Gets a list of supplierInvoiceAccruals
		/// </summary>
		/// <returns>A list of supplierInvoiceAccruals</returns>
		public EntityCollection<SupplierInvoiceAccrualSubset> Find()
		{
			return FindAsync().Result;
		}

		public async Task<EntityCollection<SupplierInvoiceAccrualSubset>> FindAsync()
		{
			return await BaseFind();
		}
		public async Task DeleteAsync(int? id)
		{
			await BaseDelete(id.ToString());
		}
		public async Task<SupplierInvoiceAccrual> CreateAsync(SupplierInvoiceAccrual supplierInvoiceAccrual)
		{
			return await BaseCreate(supplierInvoiceAccrual);
		}
		public async Task<SupplierInvoiceAccrual> UpdateAsync(SupplierInvoiceAccrual supplierInvoiceAccrual)
		{
			return await BaseUpdate(supplierInvoiceAccrual, supplierInvoiceAccrual.SupplierInvoiceNumber.ToString());
		}
		public async Task<SupplierInvoiceAccrual> GetAsync(int? id)
		{
			return await BaseGet(id.ToString());
		}
	}
}
