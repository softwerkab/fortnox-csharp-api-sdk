using FortnoxAPILibrary;
using FortnoxAPILibrary.Entities;

// ReSharper disable UnusedMember.Global

namespace FortnoxAPILibrary.Connectors
{
    /// <remarks/>
    public class ContractConnector : EntityConnector<Contract, EntityCollection<ContractSubset>, Sort.By.Contract?>
	{
	    /// <summary>
        /// Use with Find() to limit the search result
        /// </summary>
        [SearchParameter("filter")]
		public Filter.Contract? FilterBy { get; set; }


        /// <summary>
        /// Use with Find() to limit the search result
        /// </summary>
        [SearchParameter]
		public string CustomerNumber { get; set; }

        /// <summary>
        /// Use with Find() to limit the search result
        /// </summary>
        [SearchParameter]
		public string DocumentNumber { get; set; }

        /// <summary>
        /// Use with Find() to limit the search result
        /// </summary>
        [SearchParameter]
		public string InvoicesRemaining { get; set; }

        /// <summary>
        /// Use with Find() to limit the search result
        /// </summary>
        [SearchParameter]
		public string PeriodEnd { get; set; }

        /// <summary>
        /// Use with Find() to limit the search result
        /// </summary>
        [SearchParameter]
		public string PeriodStart { get; set; }

        /// <summary>
        /// Use with Find() to limit the search result
        /// </summary>
        [SearchParameter]
		public string TemplateNumber { get; set; }

		/// <remarks/>
		public ContractConnector()
		{
			Resource = "contracts";
		}
		/// <summary>
		/// Find a contract based on id
		/// </summary>
		/// <param name="id">Identifier of the contract to find</param>
		/// <returns>The found contract</returns>
		public Contract Get(int? id)
		{
			return BaseGet(id.ToString());
		}

		/// <summary>
		/// Updates a contract
		/// </summary>
		/// <param name="contract">The contract to update</param>
		/// <returns>The updated contract</returns>
		public Contract Update(Contract contract)
		{
			return BaseUpdate(contract, contract.DocumentNumber.ToString());
		}

		/// <summary>
		/// Creates a new contract
		/// </summary>
		/// <param name="contract">The contract to create</param>
		/// <returns>The created contract</returns>
		public Contract Create(Contract contract)
		{
			return BaseCreate(contract);
		}

		/// <summary>
		/// Deletes a contract
		/// </summary>
		/// <param name="id">Identifier of the contract to delete</param>
		public void Delete(int? id)
		{
			BaseDelete(id.ToString());
		}

		/// <summary>
		/// Gets a list of contracts
		/// </summary>
		/// <returns>A list of contracts</returns>
		public EntityCollection<ContractSubset> Find()
		{
			return BaseFind();
		}

        /// <summary>
        /// Finish a contract
        /// </summary>
        /// <param name="id">The document number of the contract to finish.</param>
        /// <returns>The finished contract</returns>
        public Contract Finish(int? id)
        {
            return DoAction(id.ToString(), "finish");
        }
	}
}
