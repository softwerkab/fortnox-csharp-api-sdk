using FortnoxAPILibrary;
using FortnoxAPILibrary.Entities;

using System.Threading.Tasks;

// ReSharper disable UnusedMember.Global

namespace FortnoxAPILibrary.Connectors
{
    /// <remarks/>
    public class CostCenterConnector : EntityConnector<CostCenter, EntityCollection<CostCenter>, Sort.By.CostCenter?>, ICostCenterConnector
	{
	    /// <summary>
        /// Use with Find() to limit the search result
        /// </summary>
        [SearchParameter("filter")]
		public Filter.CostCenter? FilterBy { get; set; }


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
			return BaseGet(id.ToString());
		}

		/// <summary>
		/// Updates a costCenter
		/// </summary>
		/// <param name="costCenter">The costCenter to update</param>
		/// <returns>The updated costCenter</returns>
		public CostCenter Update(CostCenter costCenter)
		{
			return BaseUpdate(costCenter, costCenter.Code.ToString());
		}

		/// <summary>
		/// Creates a new costCenter
		/// </summary>
		/// <param name="costCenter">The costCenter to create</param>
		/// <returns>The created costCenter</returns>
		public CostCenter Create(CostCenter costCenter)
		{
			return BaseCreate(costCenter);
		}

		/// <summary>
		/// Deletes a costCenter
		/// </summary>
		/// <param name="id">Identifier of the costCenter to delete</param>
		public void Delete(string id)
		{
			BaseDelete(id.ToString());
		}

		/// <summary>
		/// Gets a list of costCenters
		/// </summary>
		/// <returns>A list of costCenters</returns>
		public EntityCollection<CostCenter> Find()
		{
			return BaseFind();
		}

		public async Task<EntityCollection<CostCenter>> FindAsync()
		{
			return await BaseFind();
		}
		public async Task DeleteAsync(string id)
		{
			await BaseDelete(id.ToString());
		}
		public async Task<CostCenter> CreateAsync(CostCenter costCenter)
		{
			return await BaseCreate(costCenter);
		}
		public async Task<CostCenter> UpdateAsync(CostCenter costCenter)
		{
			return await BaseUpdate(costCenter, costCenter.Code.ToString());
		}
		public async Task<CostCenter> GetAsync(string id)
		{
			return await BaseGet(id.ToString());
		}
	}
}
