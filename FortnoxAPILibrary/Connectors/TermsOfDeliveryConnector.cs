using FortnoxAPILibrary.Entities;

using System.Threading.Tasks;

// ReSharper disable UnusedMember.Global

namespace FortnoxAPILibrary.Connectors
{
    /// <remarks/>
    public class TermsOfDeliveryConnector : SearchableEntityConnector<TermsOfDelivery, TermsOfDelivery, TermsOfDeliverySearch>, ITermsOfDeliveryConnector
	{


		/// <remarks/>
		public TermsOfDeliveryConnector()
		{
			Resource = "termsofdeliveries";
		}
		/// <summary>
		/// Find a termsOfDelivery based on id
		/// </summary>
		/// <param name="id">Identifier of the termsOfDelivery to find</param>
		/// <returns>The found termsOfDelivery</returns>
		public TermsOfDelivery Get(string id)
		{
			return GetAsync(id).GetResult();
		}

		/// <summary>
		/// Updates a termsOfDelivery
		/// </summary>
		/// <param name="termsOfDelivery">The termsOfDelivery to update</param>
		/// <returns>The updated termsOfDelivery</returns>
		public TermsOfDelivery Update(TermsOfDelivery termsOfDelivery)
		{
			return UpdateAsync(termsOfDelivery).GetResult();
		}

		/// <summary>
		/// Creates a new termsOfDelivery
		/// </summary>
		/// <param name="termsOfDelivery">The termsOfDelivery to create</param>
		/// <returns>The created termsOfDelivery</returns>
		public TermsOfDelivery Create(TermsOfDelivery termsOfDelivery)
		{
			return CreateAsync(termsOfDelivery).GetResult();
		}

		/// <summary>
		/// Deletes a termsOfDelivery
		/// </summary>
		/// <param name="id">Identifier of the termsOfDelivery to delete</param>
		public void Delete(string id)
		{
			DeleteAsync(id).GetResult();
		}

		/// <summary>
		/// Gets a list of termsOfDeliverys
		/// </summary>
		/// <returns>A list of termsOfDeliverys</returns>
		public EntityCollection<TermsOfDelivery> Find(TermsOfDeliverySearch searchSettings)
		{
			return FindAsync(searchSettings).GetResult();
		}

		public async Task<EntityCollection<TermsOfDelivery>> FindAsync(TermsOfDeliverySearch searchSettings)
		{
			return await BaseFind(searchSettings).ConfigureAwait(false);
		}
		public async Task DeleteAsync(string id)
		{
			await BaseDelete(id).ConfigureAwait(false);
		}
		public async Task<TermsOfDelivery> CreateAsync(TermsOfDelivery termsOfDelivery)
		{
			return await BaseCreate(termsOfDelivery).ConfigureAwait(false);
		}
		public async Task<TermsOfDelivery> UpdateAsync(TermsOfDelivery termsOfDelivery)
		{
			return await BaseUpdate(termsOfDelivery, termsOfDelivery.Code).ConfigureAwait(false);
		}
		public async Task<TermsOfDelivery> GetAsync(string id)
		{
			return await BaseGet(id).ConfigureAwait(false);
		}
	}
}
