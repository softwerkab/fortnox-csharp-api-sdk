using FortnoxAPILibrary.Entities;

using System.Threading.Tasks;

// ReSharper disable UnusedMember.Global

namespace FortnoxAPILibrary.Connectors
{
    /// <remarks/>
    public class ContractConnector : SearchableEntityConnector<Contract, ContractSubset, ContractSearch>, IContractConnector
	{


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
		public Contract Get(long? id)
		{
			return GetAsync(id).GetResult();
		}

		/// <summary>
		/// Updates a contract
		/// </summary>
		/// <param name="contract">The contract to update</param>
		/// <returns>The updated contract</returns>
		public Contract Update(Contract contract)
		{
			return UpdateAsync(contract).GetResult();
		}

		/// <summary>
		/// Creates a new contract
		/// </summary>
		/// <param name="contract">The contract to create</param>
		/// <returns>The created contract</returns>
		public Contract Create(Contract contract)
		{
			return CreateAsync(contract).GetResult();
		}

		/// <summary>
		/// Gets a list of contracts
		/// </summary>
		/// <returns>A list of contracts</returns>
		public EntityCollection<ContractSubset> Find()
		{
			return FindAsync().GetResult();
		}
		
		/// <summary>
		/// Set a contract as finished
		/// <param name="id"></param>
		/// <returns></returns>
		/// </summary>
		public Contract Finish(long? id)
		{
			return DoAction(id.ToString(), Action.Finish);
		}
		
		/// <summary>
		/// Create invoice from contract
		/// <param name="id"></param>
		/// <returns></returns>
		/// </summary>
		public Contract CreateInvoice(long? id)
		{
			return DoAction(id.ToString(), Action.CreateInvoice);
		}
		
		/// <summary>
		/// Increases the invoice count without creating an invoice
		/// <param name="id"></param>
		/// <returns></returns>
		/// </summary>
		public Contract IncreaseInvoiceCount(long? id)
		{
			return DoAction(id.ToString(), Action.IncreaseInvoiceCount);
		}

		public async Task<EntityCollection<ContractSubset>> FindAsync()
		{
			return await BaseFind().ConfigureAwait(false);
		}
		public async Task<Contract> CreateAsync(Contract contract)
		{
			return await BaseCreate(contract).ConfigureAwait(false);
		}
		public async Task<Contract> UpdateAsync(Contract contract)
		{
			return await BaseUpdate(contract, contract.DocumentNumber.ToString()).ConfigureAwait(false);
		}
		public async Task<Contract> GetAsync(long? id)
		{
			return await BaseGet(id.ToString()).ConfigureAwait(false);
		}
	}
}
