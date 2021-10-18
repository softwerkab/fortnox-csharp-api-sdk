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
    internal class ContractConnector : SearchableEntityConnector<Contract, ContractSubset, ContractSearch>, IContractConnector
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
        public EntityCollection<ContractSubset> Find(ContractSearch searchSettings)
        {
            return FindAsync(searchSettings).GetResult();
        }

        /// <summary>
        /// Set a contract as finished
        /// <param name="id"></param>
        /// <returns></returns>
        /// </summary>
        public Contract Finish(long? id)
        {
            return FinishAsync(id).GetResult();
        }

        /// <summary>
        /// Create invoice from contract
        /// <param name="id"></param>
        /// <returns></returns>
        /// </summary>
        public Contract CreateInvoice(long? id)
        {
            return CreateInvoiceAsync(id).GetResult();
        }

        /// <summary>
        /// Increases the invoice count without creating an invoice
        /// <param name="id"></param>
        /// <returns></returns>
        /// </summary>
        public Contract IncreaseInvoiceCount(long? id)
        {
            return IncreaseInvoiceCountAsync(id).GetResult();
        }

        public async Task<EntityCollection<ContractSubset>> FindAsync(ContractSearch searchSettings)
        {
            return await BaseFind(searchSettings).ConfigureAwait(false);
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

        public async Task<Contract> FinishAsync(long? id)
        {
            return await DoActionAsync(id.ToString(), Action.Finish).ConfigureAwait(false);
        }

        public async Task<Contract> CreateInvoiceAsync(long? id)
        {
            return await DoActionAsync(id.ToString(), Action.CreateInvoice).ConfigureAwait(false);
        }

        public async Task<Contract> IncreaseInvoiceCountAsync(long? id)
        {
            return await DoActionAsync(id.ToString(), Action.IncreaseInvoiceCount).ConfigureAwait(false);
        }
    }
}
