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
    public class CostCenterConnector : SearchableEntityConnector<CostCenter, CostCenter, CostCenterSearch>, ICostCenterConnector
	{


		/// <remarks/>
		public CostCenterConnector()
		{
			Resource = "costcenters";
		}
		/// <summary>
		/// Find a costCenter based on id
		/// </summary>
		/// <param name="id">Identifier of the costCenter to find</param>
		/// <returns>The found costCenter</returns>
		public CostCenter Get(string id)
		{
			return GetAsync(id).GetResult();
		}

		/// <summary>
		/// Updates a costCenter
		/// </summary>
		/// <param name="costCenter">The costCenter to update</param>
		/// <returns>The updated costCenter</returns>
		public CostCenter Update(CostCenter costCenter)
		{
			return UpdateAsync(costCenter).GetResult();
		}

		/// <summary>
		/// Creates a new costCenter
		/// </summary>
		/// <param name="costCenter">The costCenter to create</param>
		/// <returns>The created costCenter</returns>
		public CostCenter Create(CostCenter costCenter)
		{
			return CreateAsync(costCenter).GetResult();
		}

		/// <summary>
		/// Deletes a costCenter
		/// </summary>
		/// <param name="id">Identifier of the costCenter to delete</param>
		public void Delete(string id)
		{
			DeleteAsync(id).GetResult();
		}

		/// <summary>
		/// Gets a list of costCenters
		/// </summary>
		/// <returns>A list of costCenters</returns>
		public EntityCollection<CostCenter> Find(CostCenterSearch searchSettings)
		{
			return FindAsync(searchSettings).GetResult();
		}

		public async Task<EntityCollection<CostCenter>> FindAsync(CostCenterSearch searchSettings)
		{
			return await BaseFind(searchSettings).ConfigureAwait(false);
		}
		public async Task DeleteAsync(string id)
		{
			await BaseDelete(id).ConfigureAwait(false);
		}
		public async Task<CostCenter> CreateAsync(CostCenter costCenter)
		{
			return await BaseCreate(costCenter).ConfigureAwait(false);
		}
		public async Task<CostCenter> UpdateAsync(CostCenter costCenter)
		{
			return await BaseUpdate(costCenter, costCenter.Code).ConfigureAwait(false);
		}
		public async Task<CostCenter> GetAsync(string id)
		{
			return await BaseGet(id).ConfigureAwait(false);
		}
	}
}
