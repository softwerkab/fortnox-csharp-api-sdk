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
		public Filter.CostCenter FilterBy { get; set; }


		/// <remarks/>
		public CostCenterConnector()
		{
			Resource = "costcenters";
		}

		/// <summary>
		/// Find a costCenter based on costCenternumber
		/// </summary>
		/// <param name="costCenterNumber">The costCenternumber to find</param>
		/// <returns>The found costCenter</returns>
		public CostCenter Get(string costCenterNumber)
		{
			return BaseGet(costCenterNumber);
		}

		/// <summary>
		/// Updates a costCenter
		/// </summary>
		/// <param name="costCenter">The costCenter to update</param>
		/// <returns>The updated costCenter</returns>
		public CostCenter Update(CostCenter costCenter)
		{
			return BaseUpdate(costCenter, costCenter.CostCenterNumber);
		}

		/// <summary>
		/// Create a new costCenter
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
		/// <param name="costCenterNumber">The costCenternumber to delete</param>
		public void Delete(string costCenterNumber)
		{
			BaseDelete(costCenterNumber);
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
