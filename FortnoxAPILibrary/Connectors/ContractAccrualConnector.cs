using FortnoxAPILibrary.Entities;

using System.Threading.Tasks;

// ReSharper disable UnusedMember.Global

namespace FortnoxAPILibrary.Connectors
{
    /// <remarks/>
    public class ContractAccrualConnector : EntityConnector<ContractAccrual, EntityCollection<ContractAccrualSubset>>, IContractAccrualConnector
	{
		public ContractAccrualSearch Search { get; set; } = new ContractAccrualSearch();


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
			return GetAsync(id).Result;
		}

		/// <summary>
		/// Updates a contractAccrual
		/// </summary>
		/// <param name="contractAccrual">The contractAccrual to update</param>
		/// <returns>The updated contractAccrual</returns>
		public ContractAccrual Update(ContractAccrual contractAccrual)
		{
			return UpdateAsync(contractAccrual).Result;
		}

		/// <summary>
		/// Creates a new contractAccrual
		/// </summary>
		/// <param name="contractAccrual">The contractAccrual to create</param>
		/// <returns>The created contractAccrual</returns>
		public ContractAccrual Create(ContractAccrual contractAccrual)
		{
			return CreateAsync(contractAccrual).Result;
		}

		/// <summary>
		/// Deletes a contractAccrual
		/// </summary>
		/// <param name="id">Identifier of the contractAccrual to delete</param>
		public void Delete(long? id)
		{
			DeleteAsync(id).Wait();
		}

		/// <summary>
		/// Gets a list of contractAccruals
		/// </summary>
		/// <returns>A list of contractAccruals</returns>
		public EntityCollection<ContractAccrualSubset> Find()
		{
			return FindAsync().Result;
		}

		public async Task<EntityCollection<ContractAccrualSubset>> FindAsync()
		{
			return await BaseFind().ConfigureAwait(false);
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
