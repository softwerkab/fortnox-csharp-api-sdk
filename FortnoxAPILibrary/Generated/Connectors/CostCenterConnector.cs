using FortnoxAPILibrary;
using FortnoxAPILibrary.Entities;

// ReSharper disable UnusedMember.Global

namespace FortnoxAPILibrary.Connectors
{
    /// <remarks/>
    public class CostCenterConnector : EntityConnector<CostCenter, EntityCollection<CostCenterSubset>, Sort.By.CostCenter?>
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
			return BaseGet(id);
		}

		/// <summary>
		/// Updates a costCenter
		/// </summary>
		/// <param name="costCenter">The costCenter to update</param>
		/// <returns>The updated costCenter</returns>
		public CostCenter Update(CostCenter costCenter)
		{
			return BaseUpdate(costCenter, costCenter.Id.ToString());
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
			BaseDelete(id);
		}

		/// <summary>
		/// Gets a list of costCenters
		/// </summary>
		/// <returns>A list of costCenters</returns>
		public EntityCollection<CostCenterSubset> Find()
		{
			return BaseFind();
		}
	}
}
