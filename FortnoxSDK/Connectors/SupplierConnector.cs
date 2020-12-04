using System.Threading.Tasks;
using Fortnox.SDK.Connectors.Base;
using Fortnox.SDK.Entities;
using Fortnox.SDK.Interfaces;
using Fortnox.SDK.Search;
using Fortnox.SDK.Utility;

// ReSharper disable UnusedMember.Global

namespace Fortnox.SDK.Connectors
{
    /// <remarks/>
    public class SupplierConnector : SearchableEntityConnector<Supplier, SupplierSubset, SupplierSearch>, ISupplierConnector
	{


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
			return GetAsync(id).GetResult();
		}

		/// <summary>
		/// Updates a supplier
		/// </summary>
		/// <param name="supplier">The supplier to update</param>
		/// <returns>The updated supplier</returns>
		public Supplier Update(Supplier supplier)
		{
			return UpdateAsync(supplier).GetResult();
		}

		/// <summary>
		/// Creates a new supplier
		/// </summary>
		/// <param name="supplier">The supplier to create</param>
		/// <returns>The created supplier</returns>
		public Supplier Create(Supplier supplier)
		{
			return CreateAsync(supplier).GetResult();
		}

		/// <summary>
		/// Deletes a supplier
		/// </summary>
		/// <param name="id">Identifier of the supplier to delete</param>
		public void Delete(string id)
		{
			DeleteAsync(id).GetResult();
		}

		/// <summary>
		/// Gets a list of suppliers
		/// </summary>
		/// <returns>A list of suppliers</returns>
		public EntityCollection<SupplierSubset> Find(SupplierSearch searchSettings)
		{
			return FindAsync(searchSettings).GetResult();
		}

		public async Task<EntityCollection<SupplierSubset>> FindAsync(SupplierSearch searchSettings)
		{
			return await BaseFind(searchSettings).ConfigureAwait(false);
		}
		public async Task DeleteAsync(string id)
		{
			await BaseDelete(id).ConfigureAwait(false);
		}
		public async Task<Supplier> CreateAsync(Supplier supplier)
		{
			return await BaseCreate(supplier).ConfigureAwait(false);
		}
		public async Task<Supplier> UpdateAsync(Supplier supplier)
		{
			return await BaseUpdate(supplier, supplier.SupplierNumber).ConfigureAwait(false);
		}
		public async Task<Supplier> GetAsync(string id)
		{
			return await BaseGet(id).ConfigureAwait(false);
		}
	}
}
