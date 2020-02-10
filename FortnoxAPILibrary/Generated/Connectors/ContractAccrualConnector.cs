using FortnoxAPILibrary;
using FortnoxAPILibrary.Entities;

// ReSharper disable UnusedMember.Global

namespace FortnoxAPILibrary.Connectors
{
    /// <remarks/>
    public class ContractAccrualConnector : EntityConnector<ContractAccrual, EntityCollection<ContractAccrualSubset>, Sort.By.ContractAccrual?>
	{
	    /// <summary>
        /// Use with Find() to limit the search result
        /// </summary>
        [SearchParameter("filter")]
		public Filter.ContractAccrual FilterBy { get; set; }


		/// <remarks/>
		public ContractAccrualConnector()
		{
			Resource = "contractaccruals";
		}

		/// <summary>
		/// Find a contractAccrual based on contractAccrualnumber
		/// </summary>
		/// <param name="contractAccrualNumber">The contractAccrualnumber to find</param>
		/// <returns>The found contractAccrual</returns>
		public ContractAccrual Get(string contractAccrualNumber)
		{
			return BaseGet(contractAccrualNumber);
		}

		/// <summary>
		/// Updates a contractAccrual
		/// </summary>
		/// <param name="contractAccrual">The contractAccrual to update</param>
		/// <returns>The updated contractAccrual</returns>
		public ContractAccrual Update(ContractAccrual contractAccrual)
		{
			return BaseUpdate(contractAccrual, contractAccrual.ContractAccrualNumber);
		}

		/// <summary>
		/// Create a new contractAccrual
		/// </summary>
		/// <param name="contractAccrual">The contractAccrual to create</param>
		/// <returns>The created contractAccrual</returns>
		public ContractAccrual Create(ContractAccrual contractAccrual)
		{
			return BaseCreate(contractAccrual);
		}

		/// <summary>
		/// Deletes a contractAccrual
		/// </summary>
		/// <param name="contractAccrualNumber">The contractAccrualnumber to delete</param>
		public void Delete(string contractAccrualNumber)
		{
			BaseDelete(contractAccrualNumber);
		}

		/// <summary>
		/// Gets a list of contractAccruals
		/// </summary>
		/// <returns>A list of contractAccruals</returns>
		public EntityCollection<ContractAccrualSubset> Find()
		{
			return BaseFind();
		}
	}
}
