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
    public class ContractAccrualConnector : SearchableEntityConnector<ContractAccrual, ContractAccrualSubset, ContractAccrualSearch>, IContractAccrualConnector
	{


		/// <remarks/>
		public ContractAccrualConnector()
		{
			Resource = "contractaccruals";
		}
		/// <summary>
		/// Find a contractAccrual based on id
		/// </summary>
		/// <param name="id">Identifier of the contractAccrual to find</param>
		/// <returns>The found contractAccrual</returns>
		public ContractAccrual Get(long? id)
		{
			return GetAsync(id).GetResult();
		}

		/// <summary>
		/// Updates a contractAccrual
		/// </summary>
		/// <param name="contractAccrual">The contractAccrual to update</param>
		/// <returns>The updated contractAccrual</returns>
		public ContractAccrual Update(ContractAccrual contractAccrual)
		{
			return UpdateAsync(contractAccrual).GetResult();
		}

		/// <summary>
		/// Creates a new contractAccrual
		/// </summary>
		/// <param name="contractAccrual">The contractAccrual to create</param>
		/// <returns>The created contractAccrual</returns>
		public ContractAccrual Create(ContractAccrual contractAccrual)
		{
			return CreateAsync(contractAccrual).GetResult();
		}

		/// <summary>
		/// Deletes a contractAccrual
		/// </summary>
		/// <param name="id">Identifier of the contractAccrual to delete</param>
		public void Delete(long? id)
		{
			DeleteAsync(id).GetResult();
		}

		/// <summary>
		/// Gets a list of contractAccruals
		/// </summary>
		/// <returns>A list of contractAccruals</returns>
		public EntityCollection<ContractAccrualSubset> Find(ContractAccrualSearch searchSettings)
		{
			return FindAsync(searchSettings).GetResult();
		}

		public async Task<EntityCollection<ContractAccrualSubset>> FindAsync(ContractAccrualSearch searchSettings)
		{
			return await BaseFind(searchSettings).ConfigureAwait(false);
		}
		public async Task DeleteAsync(long? id)
		{
			await BaseDelete(id.ToString()).ConfigureAwait(false);
		}
		public async Task<ContractAccrual> CreateAsync(ContractAccrual contractAccrual)
		{
			return await BaseCreate(contractAccrual).ConfigureAwait(false);
		}
		public async Task<ContractAccrual> UpdateAsync(ContractAccrual contractAccrual)
		{
			return await BaseUpdate(contractAccrual, contractAccrual.DocumentNumber.ToString()).ConfigureAwait(false);
		}
		public async Task<ContractAccrual> GetAsync(long? id)
		{
			return await BaseGet(id.ToString()).ConfigureAwait(false);
		}
	}
}
