using FortnoxAPILibrary;
using FortnoxAPILibrary.Entities;

using System.Threading.Tasks;

// ReSharper disable UnusedMember.Global

namespace FortnoxAPILibrary.Connectors
{
    /// <remarks/>
    public class ContractConnector : EntityConnector<Contract, EntityCollection<ContractSubset>, Sort.By.Contract?>, IContractConnector
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
		/// Gets a list of contracts
		/// </summary>
		/// <returns>A list of contracts</returns>
		public EntityCollection<ContractSubset> Find()
		{
			return BaseFind();
		}
		
		/// <summary>
		/// Set a contract as finished
		/// <param name="id"></param>
		/// <returns></returns>
		/// </summary>
		public Contract Finish(int? id)
		{
			return DoAction(id.ToString(), "finish");
		}
		
		/// <summary>
		/// Create invoice from contract
		/// <param name="id"></param>
		/// <returns></returns>
		/// </summary>
		public Contract CreateInvoice(int? id)
		{
			return DoAction(id.ToString(), "createinvoice");
		}
		
		/// <summary>
		/// Increases the invoice count without creating an invoice
		/// <param name="id"></param>
		/// <returns></returns>
		/// </summary>
		public Contract IncreaseInvoiceCount(int? id)
		{
			return DoAction(id.ToString(), "increaseinvoicecount");
		}

		public async Task<EntityCollection<ContractSubset>> FindAsync()
		{
			return await BaseFind();
		}
		public async Task<Contract> CreateAsync(Contract contract)
		{
			return await BaseCreate(contract);
		}
		public async Task<Contract> UpdateAsync(Contract contract)
		{
			return await BaseUpdate(contract, contract.DocumentNumber.ToString());
		}
		public async Task<Contract> GetAsync(int? id)
		{
			return await BaseGet(id.ToString());
		}
	}
}
