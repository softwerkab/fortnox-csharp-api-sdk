using FortnoxAPILibrary.Entities;

using System.Threading.Tasks;

// ReSharper disable UnusedMember.Global

namespace FortnoxAPILibrary.Connectors
{
    /// <remarks/>
    public class SupplierConnector : EntityConnector<Supplier, EntityCollection<SupplierSubset>, Sort.By.Supplier?>, ISupplierConnector
	{
	    /// <summary>
        /// Use with Find() to limit the search result
        /// </summary>
        [SearchParameter("filter")]
		public Filter.Supplier? FilterBy { get; set; }


        /// <summary>
        /// Use with Find() to limit the search result
        /// </summary>
        [SearchParameter]
		public string City { get; set; }

        /// <summary>
        /// Use with Find() to limit the search result
        /// </summary>
        [SearchParameter]
		public string Email { get; set; }

        /// <summary>
        /// Use with Find() to limit the search result
        /// </summary>
        [SearchParameter]
		public string Name { get; set; }

        /// <summary>
        /// Use with Find() to limit the search result
        /// </summary>
        [SearchParameter]
		public string OrganisationNumber { get; set; }

        /// <summary>
        /// Use with Find() to limit the search result
        /// </summary>
        [SearchParameter]
		public string Phone1 { get; set; }

        /// <summary>
        /// Use with Find() to limit the search result
        /// </summary>
        [SearchParameter]
		public string Phone2 { get; set; }

        /// <summary>
        /// Use with Find() to limit the search result
        /// </summary>
        [SearchParameter]
		public string SupplierNumber { get; set; }

        /// <summary>
        /// Use with Find() to limit the search result
        /// </summary>
        [SearchParameter]
		public string ZipCode { get; set; }

		/// <remarks/>
		public SupplierConnector()
		{
			Resource = "suppliers";
		}
		/// <summary>
		/// Find a supplier based on id
		/// </summary>
		/// <param name="id">Identifier of the supplier to find</param>
		/// <returns>The found supplier</returns>
		public Supplier Get(string id)
		{
			return GetAsync(id).Result;
		}

		/// <summary>
		/// Updates a supplier
		/// </summary>
		/// <param name="supplier">The supplier to update</param>
		/// <returns>The updated supplier</returns>
		public Supplier Update(Supplier supplier)
		{
			return UpdateAsync(supplier).Result;
		}

		/// <summary>
		/// Creates a new supplier
		/// </summary>
		/// <param name="supplier">The supplier to create</param>
		/// <returns>The created supplier</returns>
		public Supplier Create(Supplier supplier)
		{
			return CreateAsync(supplier).Result;
		}

		/// <summary>
		/// Deletes a supplier
		/// </summary>
		/// <param name="id">Identifier of the supplier to delete</param>
		public void Delete(string id)
		{
			DeleteAsync(id).Wait();
		}

		/// <summary>
		/// Gets a list of suppliers
		/// </summary>
		/// <returns>A list of suppliers</returns>
		public EntityCollection<SupplierSubset> Find()
		{
			return FindAsync().Result;
		}

		public async Task<EntityCollection<SupplierSubset>> FindAsync()
		{
			return await BaseFind();
		}
		public async Task DeleteAsync(string id)
		{
			await BaseDelete(id);
		}
		public async Task<Supplier> CreateAsync(Supplier supplier)
		{
			return await BaseCreate(supplier);
		}
		public async Task<Supplier> UpdateAsync(Supplier supplier)
		{
			return await BaseUpdate(supplier, supplier.SupplierNumber);
		}
		public async Task<Supplier> GetAsync(string id)
		{
			return await BaseGet(id);
		}
	}
}
